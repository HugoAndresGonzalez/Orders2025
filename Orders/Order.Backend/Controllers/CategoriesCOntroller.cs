using Microsoft.AspNetCore.Mvc;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;

namespace Order.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesCOntroller : GenericController<Category>
{
    public CategoriesCOntroller(IGenericUnitsOfWork<Category> UnitsOfWork) : base(UnitsOfWork)
    {
    }
}