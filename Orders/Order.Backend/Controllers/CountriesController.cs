using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;

namespace Order.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : GenericController<Country>
{
    public CountriesController(IGenericUnitsOfWork<Country> UnitsOfWork) : base(UnitsOfWork)
    {
    }
}