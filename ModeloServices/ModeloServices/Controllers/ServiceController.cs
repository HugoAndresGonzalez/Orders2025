using Microsoft.AspNetCore.Mvc;
using ModeloServices.Context;
using ModeloServices.Managers;

namespace ModeloServices.Controllers
{
    public class ServiceController(ServicesManager _ServiceManager) : Controller
    {
        public IActionResult Index()
        {
            var list = _ServiceManager.GetAll(1, list);
            return View(list);
        }
    }
}