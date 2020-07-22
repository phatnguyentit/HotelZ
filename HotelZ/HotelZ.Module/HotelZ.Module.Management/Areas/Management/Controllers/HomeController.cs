using Microsoft.AspNetCore.Mvc;

namespace HotelZ.Module.Management.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}