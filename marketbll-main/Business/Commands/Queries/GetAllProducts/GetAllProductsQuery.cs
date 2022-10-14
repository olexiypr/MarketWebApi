using System;
using Business.Commands;
using Business.Dto;
using Business.ViewModels;
using Data.Entities;
using MediatR;

namespace Business.Commands.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ProductsVm>
{
    public Func<Product, bool> Predicate { get; set; }
}