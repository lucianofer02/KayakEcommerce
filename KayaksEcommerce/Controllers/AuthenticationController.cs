
using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KayaksEcommerce.Web.Controllers;


[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ICustomAuthenticationService _customAuthenticationService;

    public AuthenticationController(IConfiguration config, ICustomAuthenticationService authenticationService)
    {
        _config = config;
        _customAuthenticationService = authenticationService;
    }

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequest authenticationRequest)
    {
        string token = _customAuthenticationService.Authenticate(authenticationRequest);

        return Ok(token);
    }
}
