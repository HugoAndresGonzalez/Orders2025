using Microsoft.AspNetCore.Mvc;
using Order.Backend.Controllers;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    public CitiesController(IGenericUnitsOfWork<City> unitOfWork) : base(unitOfWork)
    {
    }
}