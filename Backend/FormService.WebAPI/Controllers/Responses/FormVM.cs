using FormService.Domain.Entities.Enums;
using FormService.Domain.Entities.ValueObjects;
using FormService.WebAPI.Controllers.Requests;

namespace FormService.WebAPI.Controllers.Responses;

public record FormVM(
    DateTime SubmitTime,
    string ExpresswayName,
    string ContractorCompany,
    string SupervisionCompany,
    string ContractNumber,
    string SerialNumber,
    SubgradeType SubgradeType,
    string ProjectName,
    string StakeNumberAndLocation,
    DateInfo StartDate,
    DateInfo EndDate,
    DateInfo InspectionDate,
    List<InspectionDetail> Rows,
    bool IsQualified,
    string? UnqualifiedItems,
    string SupervisorName,
    DateInfo SigningDate
    );
