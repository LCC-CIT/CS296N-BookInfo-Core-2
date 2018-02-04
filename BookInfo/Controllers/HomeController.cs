using Microsoft.AspNetCore.Mvc;

namespace BookInfo.Controllers
{
    public class HomeController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

    }
}
