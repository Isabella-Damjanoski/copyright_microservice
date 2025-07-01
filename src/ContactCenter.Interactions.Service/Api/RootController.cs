using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceTitan.ContactCenter.Interactions.Service.Api;

[Route("")]
[AllowAnonymous]
[Produces(MediaTypeNames.Application.Json)]
public class RootController() : ControllerBase
{

    [HttpGet]
    public ActionResult<HealthCheckDto> Get()
    {
        return Ok();
    }
}
