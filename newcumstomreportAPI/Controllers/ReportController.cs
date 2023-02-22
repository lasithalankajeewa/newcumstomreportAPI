using Microsoft.AspNetCore.Mvc;

namespace newcumstomreportAPI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
