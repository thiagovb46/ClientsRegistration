using ClientsRegistration.Application.Converters;
using ClientsRegistration.Application.ExternalServices.Implementations;
using ClientsRegistration.Application.ExternalServices.Interfaces;
using ClientsRegistration.Application.UseCases.Implementations;
using ClientsRegistration.Application.UseCases.Interfaces;
using ClientsRegistration.Infra.Data;
using ClientsRegistration.Infra.Data.Repositories;
using ClientsRegistration.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro de clientes", Version = "v1" });
    c.EnableAnnotations();
    c.ExampleFilters();
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<ICreateClientUseCase, CreateClientUseCase>();
builder.Services.AddScoped<IGetAllClientsUseCase, GetAllClientsUseCase>();
builder.Services.AddScoped<IGetClientUseCase, GetClientUseCase>();
builder.Services.AddScoped<IUpdateClientUseCase, UpdateClientUseCase>();
builder.Services.AddScoped<IDeleteClientUseCase, DeleteClientUseCase>();

builder.Services.AddScoped<IClientConverter, ClientConverter>();
builder.Services.AddScoped<ICepService, CepService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
