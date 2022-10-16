using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Auth;
using Business.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApi.Models;

namespace WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper) => (_mediator, _mapper) = (mediator, mapper);
    
    [HttpPost]
    [ActionName("token")]
    public async Task<IActionResult> Token([FromBody]UserModel user)
    {
        var command = _mapper.Map<IdentityCommand>(user);
        var token = await _mediator.Send(command);
        var response = new
        {
            access_token = token,
        };
        return Json(response);
    }

    [HttpPost]
    [ActionName("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserModel user) //date format in request: "BirthDate" : "2008-05-01"
    {
        var command = _mapper.Map<RegisterUserCommand>(user);
        var token = await _mediator.Send(command);
        var response = new
        {
            access_token = token,
        };
        return Json(response);
    }
}