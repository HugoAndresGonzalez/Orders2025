using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Shared.Entidades;

namespace Order.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly DataContext _context;

    public CountriesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }
}