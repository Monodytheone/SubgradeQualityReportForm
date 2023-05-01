namespace FormService.Domain.Entities.ValueObjects;

public class InspectionDetail
{
    /// <summary>
    /// 规定值及允许偏差
    /// </summary>
    public string SpecifiedValueAndAllowableDeviation { get; init; }

    /// <summary>
    /// 检查结果
    /// </summary>
    public string InspectionResult { get; init; }

    /// <summary>
    /// 检验结果附表代码
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// 备注（可空）
    /// </summary>
    public string? Note { get; init; }

    private InspectionDetail() { }

    public InspectionDetail(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
    {
        SpecifiedValueAndAllowableDeviation = specifiedValueAndAllowableDeviation;
        InspectionResult = inspectionResult;
        Code = code;
        Note = note;
    }
}
