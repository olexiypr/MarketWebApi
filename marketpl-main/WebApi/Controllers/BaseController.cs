using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers;

public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    internal int UserID => !User.Identity.IsAuthenticated ? 0 :
        int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
}