using HotelZ.Module.Identity.Services;
using HotelZ.Module.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelZ.Module.Identity.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IAuthService _authService;

        public HelloWorldController(IAuthService authService)
        {
            this._authService = authService;
        }

        public IActionResult Index()
        {
            _authService.Auth();
            return View();
        }
    }
}