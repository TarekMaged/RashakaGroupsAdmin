using Microsoft.AspNetCore.Mvc;

namespace RashakaGroupsAdmin.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}