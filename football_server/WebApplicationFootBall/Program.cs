using FluentValidation.AspNetCore;
using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;
using FootBallWeb.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApplicationFootBall.Common;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var env = builder.Environment;

services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );
services.AddAutoMapper(Assembly.GetExecutingAssembly());
services.AddScoped<ICountryRepository, CountryRepository>();
services.AddMediatR(Assembly.GetExecutingAssembly());
services.ServiceRegisterComon();
services.AddMvcControllers();
services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
services.RegisterValidators();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
});
services.AddCors();

var app = builder.Build();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseRouting();
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
