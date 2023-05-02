using IdentityService.Domain;
using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Infrastructure;

public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<User> _userManager;

    public IdentityRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<SignInResult> CheckForLoginAsync(User user, string password)
    {
        if (await _userManager.IsLockedOutAsync(user))
        {
            return SignInResult.LockedOut;
        }

        if (await _userManager.CheckPasswordAsync(user, password) == true)
        {
            await _userManager.ResetAccessFailedCountAsync(user);
            return SignInResult.Success;
        }
        else
        {
            _ = await _userManager.AccessFailedAsync(user);
            return SignInResult.Failed;
        }
    }

    public Task<User?> FindUserByUserNameAsync(string userName)
    {
        return _userManager.FindByNameAsync(userName)!;
    }

    public async Task<long> GetJWTVersionAsync(string userId)
    {
        User? user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("为了其他服务获取服务端JWTVersion时用户不存在");
        }
        return user.JWTVersion;
    }

    public Task<IList<string>> GetRolesOfUserAsync(User user)
    {
        return _userManager.GetRolesAsync(user);
    }

    public Task UpdateJWTVersionAsync(User user)
    {
        user.UpdateJWTVersion();
        return _userManager.UpdateAsync(user);
    }
}
