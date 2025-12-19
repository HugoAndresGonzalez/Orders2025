using Microsoft.AspNetCore.Mvc;
using Order.Backend.UnitsOfWork.Implementations;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;
using Orders.Backend.UnitsOfWork.Implementations;

namespace Order.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private readonly IStatesUnitsOfWork _statesUnitOfWork;

    public StatesController(IGenericUnitsOfWork<State> unitOfWork, IStatesUnitsOfWork statesUnitOfWork) :
    base(unitOfWork)
    {
        _statesUnitOfWork = statesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _statesUnitOfWork.GetAsync();
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _statesUnitOfWork.GetAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}