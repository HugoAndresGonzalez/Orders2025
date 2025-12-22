using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Repositories.Implementations;
using Order.Backend.Repositories.Interfaces;
using Order.Backend.UnitsOfWork.Implementations;
using Order.Backend.UnitsOfWork.Interfaces;
using Orders.Backend.Repositories.Implementations;
using Orders.Backend.UnitsOfWork.Implementations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name= OrderDatabase"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitsOfWork<>), typeof(GenericUnitsOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<ICitiesRepository, CityRepository>();
builder.Services.AddScoped<ICitiesUnitsOfWork, CitiesUnitsOfWork>();
builder.Services.AddScoped<ICountriesRepository, CountryRepository>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitsOfWork>();
builder.Services.AddScoped<IStatesUnitsOfWork, StatesUnitOfWork>();

var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedDbAsync().Wait();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();