using Microsoft.AspNetCore.Identity;

namespace IdentityService.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public long JWTVersion { get; private set; }

    public User(string userName) : base(userName)
    {
        Id = Guid.NewGuid();
    }

    public void UpdateJWTVersion()
    {
        JWTVersion++;
    }
}
