using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Domain;

public interface IIdentityRepository
{
    Task<User?> FindUserByUserNameAsync(string userName);

    Task<SignInResult> CheckForLoginAsync(User user, string password);

    Task UpdateJWTVersionAsync(User user);

    Task<IList<string>> GetRolesOfUserAsync(User user);

    Task<long> GetJWTVersionAsync(string userId);
}
