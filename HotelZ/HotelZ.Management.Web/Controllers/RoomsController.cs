using Microsoft.AspNetCore.Mvc;

namespace HotelZ.Management.Web.Controllers
{
    public class BetaController : Controller
    {
        // GET: Rooms
        public IActionResult Index()
        {
            return View();
        }

    }
}