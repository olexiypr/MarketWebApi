using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper) => (_mediator, _mapper) = (mediator, mapper);
    
    [HttpPost]
    public async Task<IActionResult> Token(UserModel user)
    {
        var command = _mapper.Map<IdentityCommand>(user);
        var token = await _mediator.Send(command);
        var response = new
        {
            access_token = token,
        };
        return Json(response);
    }
}