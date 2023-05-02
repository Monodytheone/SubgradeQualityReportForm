namespace FormService.Domain.Entities.ValueObjects;

/// <summary>
/// 施工日期
/// </summary>
public class ConstructionDate
{
    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    private ConstructionDate() { }

    public ConstructionDate(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}
