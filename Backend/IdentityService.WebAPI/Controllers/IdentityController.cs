using Commons.JWTRevoke;
using FluentValidation;
using IdentityService.Domain;
using IdentityService.WebAPI.Controllers.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IdentityService.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IIdentityRepository _repository;
    private readonly IdentityDomainService _domainService;

    // Validators of FluentValidation:
    private readonly IValidator<LoginRequest> _loginValidator;

    public IdentityController(IIdentityRepository repository, IValidator<LoginRequest> loginRequest, IdentityDomainService domainService)
    {
        _repository = repository;
        _loginValidator = loginRequest;
        _domainService = domainService;
    }

    [HttpPost]
    [NotCheckJWT]
    public async Task<ActionResult<string>> Login(LoginRequest request)
    {
        var validationResult = await _loginValidator.ValidateAsync(request);
        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
        }

        (Microsoft.AspNetCore.Identity.SignInResult result, string? token)
            = await _domainService.LoginAsync(request.UserName, request.Password);
        if (result.Succeeded)
        {
            return token!;
        }
        else if (result.IsLockedOut)
        {
            return StatusCode((int)HttpStatusCode.Locked, "账号已锁定，请稍后再试");
        }
        else
        {
            return StatusCode((int)HttpStatusCode.BadRequest, "用户名或密码错误");
        }
    }

    [HttpGet]
    public Task<long> GetServerJWTVersion(string userId)
    {
        return _repository.GetJWTVersionAsync(userId);
    }
}
