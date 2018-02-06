using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;

namespace BookInfo.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorRepository authorRepo;

        public HomeController(IAuthorRepository repo)
        {
             authorRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Authors()
        {
            var authors = authorRepo.GetAllAuthors();
            return View(authors);
        }
    }
}
