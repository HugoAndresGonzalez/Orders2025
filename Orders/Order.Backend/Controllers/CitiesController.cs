using Microsoft.AspNetCore.Mvc;
using Order.Backend.Controllers;
using Order.Backend.UnitsOfWork.Implementations;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.DTO;
using Order.Shared.Entidades;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    private readonly ICitiesUnitsOfWork _citiesUnitsOfWork;

    public CitiesController(IGenericUnitsOfWork<City> unitOfWork, ICitiesUnitsOfWork citiesUnitsOfWork) : base(unitOfWork)
    {
        _citiesUnitsOfWork = citiesUnitsOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _citiesUnitsOfWork.GetAsync(pagination);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _citiesUnitsOfWork.GetTotalRecordsAsync(pagination);
        if (action.IsSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}