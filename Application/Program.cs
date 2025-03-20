using AutoMapper;
using Application.Mappers;
using DomeinService.Interfaces;
using DomeinService.Mappers;
using DomeinService.Services;
using Infrastructyre.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructyre.Data;
using Infrastructyre.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TreeDBContext>(config =>
{
    config.UseNpgsql(connection);
});

builder.Services.AddAutoMapper(typeof(ViewMapping).Assembly, typeof(Mapping).Assembly);
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<IJornalExeptionRepository, JornalExeptionRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TreeDBContext>();
}

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.MapControllers();

app.Run();