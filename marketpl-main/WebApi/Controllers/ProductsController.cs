using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Commands.AddCommands.AddProduct;
using Business.Commands.DeleteProduct;
using Business.Commands.Queries.GetAllProducts;
using Business.Commands.Queries.GetProductById;
using Business.Commands.UpdateProduct;
using Business.Dto;
using Business.ViewModels;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper) 
        => (_mapper) = (mapper);
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ProductsVm>> GetAllProducts([FromQuery]FilterModel filter)
    {
        var query = _mapper.Map<GetAllProductsQuery>(filter);
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<ProductVm>> GetProductById(int id)
    {
        var query = new GetProductByIdQuery
        {
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Product>> AddProduct([FromBody] AddProductDto addProductDto)
    {
        var command = _mapper.Map<AddProductCommand>(addProductDto);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
    {
        var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
        command.Id = id;
        var productVm = await Mediator.Send(command);
        return Ok(productVm);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var command = new DeleteProductCommand
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }
}