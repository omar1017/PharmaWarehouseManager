using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagment.Api.Controllers;

//[Authorize(Roles ="Administrator")]
[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IUserService userService;

    public RolesController(IUserService userService)
    {
        this.userService = userService;
    }

    public string UserId => throw new NotImplementedException();


    [HttpPost("Assign")]
    public async Task<IActionResult> AssignRole(RoleAssign roleAssign) => 
        Ok(await userService.AssignRole(roleAssign));

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleRequest request) => Ok(await userService.CreateRole(request));

    [HttpDelete("/{RepoId}")]
    public async Task<IActionResult> DeleteAccount(string RepoId) =>
        Ok(await userService.DeleteAccount(RepoId));

    [HttpGet]
    public async Task<IActionResult> GetRoles() =>
        Ok(await userService.GetRolesResponse());
}
