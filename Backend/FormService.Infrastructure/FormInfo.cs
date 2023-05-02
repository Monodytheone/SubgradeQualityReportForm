namespace FormService.Infrastructure;

/// <param name="ProjectName">工程名称</param>
/// <param name="IsQualified">是否合格</param>
/// <param name="SubmitTime">表单提交时间</param>
public record FormInfo(Guid Id, string ProjectName, bool IsQualified, DateTime SubmitTime);
