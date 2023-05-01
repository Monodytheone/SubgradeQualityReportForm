using FluentValidation;
using FormService.Infrastructure;
using FormService.WebAPI.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FormService.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FormController : ControllerBase
{
    private readonly FormRepository _repository;

    // Validators of FluentValidation:
    private readonly IValidator<SubmitRequest> _submitValidator;

    public FormController(FormRepository repository, IValidator<SubmitRequest> submitValidator)
    {
        _repository = repository;
        _submitValidator = submitValidator;
    }

    [HttpPost]
    public async Task<ActionResult> Submit(SubmitRequest request)
    {
        var validationResult = await _submitValidator.ValidateAsync(request);
        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
        }
    }
}
