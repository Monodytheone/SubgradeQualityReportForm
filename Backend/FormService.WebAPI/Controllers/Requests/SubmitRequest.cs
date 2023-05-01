using FluentValidation;
using FormService.Domain.Entities.Enums;
using FormService.Domain.Entities.ValueObjects;

namespace FormService.WebAPI.Controllers.Requests;

public record SubmitRequest(string ExpresswayName, string ContractorCompany, string SupervisionCompany,
    string ContractNumber, string SerialNumber, SubgradeType SubgradeType, string ProjectName,
    string StakeNumberAndLocation, DateInfo StartDate, DateInfo EndDate, DateInfo InspectionDate,
    List<InspectionDetail> Items);

public record DateInfo(int Year, int Month, int Day);


/// <summary>
/// 简单地校验一下请求体数据
/// </summary>
public class SubmitRequestValidator : AbstractValidator<SubmitRequest>
{
    public SubmitRequestValidator()
    {
        RuleFor(x => x.ExpresswayName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ContractorCompany).NotEmpty().MaximumLength(50);
        RuleFor(x => x.SupervisionCompany).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ContractNumber).NotEmpty().MaximumLength(100);
        RuleFor(x => x.SerialNumber).NotEmpty().MaximumLength(100);
        RuleFor(x => x.SubgradeType).NotNull()
            .Must(subgradeType => subgradeType == SubgradeType.Earthwork || subgradeType == SubgradeType.Stone);
        RuleFor(x => x.ProjectName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.StakeNumberAndLocation).NotEmpty().MaximumLength(100);

        RuleFor(x => x.StartDate.Year).NotEmpty();
        RuleFor(x => x.StartDate.Month).NotEmpty();
        RuleFor(x => x.StartDate.Day).NotEmpty();
        RuleFor(x => x.EndDate.Year).NotEmpty();
        RuleFor(x => x.EndDate.Month).NotEmpty();
        RuleFor(x => x.EndDate.Day).NotEmpty();
        RuleFor(x => x.InspectionDate.Year).NotEmpty();
        RuleFor(x => x.InspectionDate.Month).NotEmpty();
        RuleFor(x => x.InspectionDate.Month).NotEmpty();

        RuleForEach(x => x.Items)
            .Must(item => item.SpecifiedValueAndAllowableDeviation.Length >= 0 && item.SpecifiedValueAndAllowableDeviation.Length <= 100)
            .Must(item => item.InspectionResult.Length >= 0 && item.InspectionResult.Length <= 100)
            .Must(item => item.Code.Length >= 0 && item.Code.Length <= 500);
    }
}
