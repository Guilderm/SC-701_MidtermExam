using BackEnd.Configurations;
using DAL.Interfaces;
using DAL.Repositories;
using Entities;
using Serilog;
using Serilog.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// configures AutoMapper.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

// configures Serilog.
Logger logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Adds dependancy Ingection
builder.Services.AddDbContext<ComercioContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();