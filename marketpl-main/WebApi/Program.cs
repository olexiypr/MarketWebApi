using Business;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi;
using WebApi.Middleware;
using DependencyInjection = WebApi.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper();
builder.Services.AddBusiness();
builder.Services.AddData(builder.Configuration);
builder.Services.AddControllers();
builder.Services.Add(DependencyInjection.AddAuthentication(builder.Services));
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();

