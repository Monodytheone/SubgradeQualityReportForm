using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure;

public class FormRepository
{
    private readonly FormDbContext _dbContext;

    public FormRepository(FormDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<FormInfo>> PaginatlyGetFormInfosInStatusAsync(bool isQualified, int page, int pageSize)
    {
        int skip = pageSize * (page - 1);
        return _dbContext.Forms
            .AsNoTracking()  // 不进行不必要的跟踪
            .Where(form => form.SupervisorOpinion.IsQualified == isQualified)
            .OrderByDescending(form => form.SubmitTime)
            .Skip(skip).Take(pageSize)
            .Select(form => new FormInfo(form.Id, form.ProjectName, isQualified, form.SubmitTime))  // 只查需要的列
            .ToListAsync();
    }
}
