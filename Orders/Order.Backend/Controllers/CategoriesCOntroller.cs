using Microsoft.AspNetCore.Mvc;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;

namespace Order.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : GenericController<Category>
{
    public CategoriesController(IGenericUnitsOfWork<Category> UnitsOfWork) : base(UnitsOfWork)
    {
    }
}