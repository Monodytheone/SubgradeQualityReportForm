namespace Commons.JWTRevoke;

/// <summary>
/// 不检查JWTVersion
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class NotCheckJWTAttribute : Attribute
{
}
