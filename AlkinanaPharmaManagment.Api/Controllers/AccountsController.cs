using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagment.Api.Controllers;

//[Authorize(Roles ="Administrator")]
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;
    private readonly IUserService userService;

    public AccountsController(
        IAuthenticationService authenticationService,
        IUserService userService)
    {
        this.authenticationService = authenticationService;
        this.userService = userService;
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticationRequest request) =>
        Ok(await authenticationService.LogIn(request));
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request) =>
        Ok(await authenticationService.Register(request));

    
    [HttpGet]
    public async Task<IActionResult> GetUsers() => Ok(await userService.GetAccountRepos());

    
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUser(string Id) => Ok(await userService.GetAccountRepo(Id));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteRole(string Id) =>
       Ok(await userService.DeleteRole(Id));

    [HttpPut]
    public async Task<IActionResult> UpdateAccount(AccountRepo accountRepo) =>
        Ok(await userService.UpdateAccount(accountRepo));
}
