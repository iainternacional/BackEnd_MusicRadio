using MusicRadio.BackEnd.Application;
using MusicRadio.BackEnd.Infrastructure.Framework;
using Microsoft.Extensions.DependencyInjection;
using MusicRadio.BackEnd.Application.Services.Seguridad;
using System.Security.Principal;
using MusicRadio.BackEnd.Infrastructure.Framework.RepositoryPattern;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IServicioSeguridad, ServicioSeguridad>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SupportNonNullableReferenceTypes();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicRadio API v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
