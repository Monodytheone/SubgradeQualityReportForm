using Commons.JWTRevoke;
using FluentValidation;
using FormService.Domain.Entities;
using FormService.Domain.Entities.ValueObjects;
using FormService.Infrastructure;
using FormService.WebAPI.Controllers.Requests;
using FormService.WebAPI.Controllers.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormService.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FormController : ControllerBase
{
    private readonly FormRepository _repository;
    private readonly FormDbContext _dbContext;

    // Validators of FluentValidation:
    private readonly IValidator<SubmitRequest> _submitValidator;

    public FormController(FormRepository repository, IValidator<SubmitRequest> submitValidator, FormDbContext dbContext)
    {
        _repository = repository;
        _submitValidator = submitValidator;
        _dbContext = dbContext;
    }

    [HttpPost]
    [NotCheckJWT]
    public async Task<ActionResult> Submit(SubmitRequest request)
    {
        var validationResult = await _submitValidator.ValidateAsync(request);
        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
        }

        // 若监理意见是不合格，且不合格项为空 || 若监理意见是合格，但不合格项不为空
        if((request.IsQualified == false) ==  (request.UnqualifiedItems == null || request.UnqualifiedItems == string.Empty))
        {
            if(request.IsQualified == false)
            {
                return BadRequest("监理意见为不合格时，必须填写不合格项");
            }
            else
            {
                return BadRequest("监理意见为合格时，不得填写不合格项");
            }
        }

        List<Deflection> deflections = new();
        for (int i = 7; i < request.Items.Count; i++)  // Items的前7项属于1Δ，故弯沉从第8项开始
        {
            InspectionDetail detail = request.Items[i];
            deflections.Add(new(i - 6, detail.SpecifiedValueAndAllowableDeviation, detail.InspectionResult,
                detail.Code, detail.Note));
        }

        Form.Builder formBuilder = new Form.Builder()
            .ExpresswayName(request.ExpresswayName)
            .ContractorCompany(request.ContractorCompany)
            .SupervisionCompany(request.SupervisionCompany)
            .ContractNumber(request.ContractNumber)
            .SerialNumber(request.SerialNumber)
            .SubgradeType(request.SubgradeType)
            .ProjectName(request.ProjectName)
            .StakeNumberAndLocation(request.StakeNumberAndLocation)
            .StartDate(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day)
            .EndDate(request.EndDate.Year, request.EndDate.Month, request.EndDate.Day)
            .InspectionDate(request.InspectionDate.Year, request.InspectionDate.Month, request.InspectionDate.Day)
            .Row0__ZeroFillingAndCutting_0_0dot80m(request.Items[0])
            .Row1__LightModerateAndHeavy_0_0dot80m(request.Items[1])
            .Row2__LightModerateAndHeavy_0_0dot80m(request.Items[2])
            .Row3__LightModerateAndHeavy_0_0dot80m(request.Items[3])
            .Row4__LightModerateAndHeavy_0_0dot80m(request.Items[4])
            .Row5__LightModerateAndHeavy_0_0dot80m(request.Items[5])
            .Row6__LightModerateAndHeavy_0_0dot80m(request.Items[6])
            .Deflections(deflections);
        Form form;
        if (request.IsQualified)
        {
            form = formBuilder.Qualify(request.SupervisorName, request.SigningDate.Year, request.SigningDate.Month, request.SigningDate.Day)
                .Build();
        }
        else
        {
            form = formBuilder.Unqualify(request.SupervisorName, request.UnqualifiedItems!, request.SigningDate.Year, request.SigningDate.Month, request.SigningDate.Day)
                .Build();
        }

        _dbContext.Forms.Add(form);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }


    /// <summary>
    /// 分页地获取合格/不合格的表单的简略信息
    /// </summary>
    [HttpGet("isQualified/{isQualified}/page/{page}")]
    [Authorize]
    public async Task<ActionResult<List<FormInfo>>> PaginatlyGetFormInfosInStatus(bool isQualified, int page, int pageSize)
    {
        if (page < 1)
        {
            return BadRequest("页码不得小于1");
        }
        if (pageSize < 3)
        {
            return BadRequest("一页至少3个");
        }

        return await _repository.PaginatlyGetFormInfosInStatusAsync(isQualified, page, pageSize);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<FormVM>> GetForm(Guid id)
    {
        Form? form = await _dbContext.Forms
            .Include(form => form.Deflections)
            .AsNoTracking()
            .FirstAsync(form => form.Id == id);
        if (form == null)
        {
            return NotFound();
        }

        List<InspectionDetail> rows = new()
        {
            form.ZeroFillingAndCutting_0_0dot80m_,
            form.LightModerateAndHeavy_0_0dot80m_,
            form.ExtraAndExtremely_0_1dot20m_,
            form.LightModerateAndHeavy_0dot80_1dot50m_,
            form.ExtraAndExtremely_1dot20_1dot90m_,
            form.LightModerateAndHeavy_GreaterThan_1dot50m_,
            form.ExtraAndExtremely_GreaterThan_1dot90m_,
        };
        IEnumerable<InspectionDetail> deflectionDetails = form.Deflections
            .OrderBy(deflection => deflection.SequenceInForm)
            .Select(deflection => deflection.InspectionDetail);
        rows.AddRange(deflectionDetails);

        FormVM formVM = new(form.SubmitTime, form.ExpresswayName, form.ContractorCompany,
            form.SupervisionCompany, form.ContractNumber, form.SerialNumber, form.SubgradeType, form.ProjectName,
            form.StakeNumberAndLocation, form.ConstructionDate.StartDate.ToDateInfo(),
            form.ConstructionDate.EndDate.ToDateInfo(), form.InspectionDate.ToDateInfo(),
            rows,
            form.SupervisorOpinion.IsQualified, form.SupervisorOpinion.UnqualifiedItems,
            form.SupervisorOpinion.SupervisorName, form.SupervisorOpinion.SupervisionDate.ToDateInfo());
        return formVM;
    }
}
