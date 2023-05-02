namespace FormService.Domain.Entities.ValueObjects;

/// <summary>
/// 监理意见
/// </summary>
public class SupervisorOpinion
{
    /// <summary>
    /// 是否合格
    /// </summary>
    public bool IsQualified { get; init; }

    public string? UnqualifiedItems { get; init; }

    /// <summary>
    /// 监理姓名
    /// </summary>
    public string SupervisorName { get; init; }

    public DateOnly SupervisionDate { get; init; }

    private SupervisorOpinion() { }

    public SupervisorOpinion(bool isQualified, string? unqualifiedItems, string supervisorName, DateOnly supervisionDate)
    {
        IsQualified = isQualified;
        UnqualifiedItems = unqualifiedItems;
        SupervisorName = supervisorName;
        SupervisionDate = supervisionDate;
    }
}
