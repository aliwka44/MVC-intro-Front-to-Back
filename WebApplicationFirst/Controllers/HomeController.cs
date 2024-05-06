using Microsoft.AspNetCore.Mvc;
  

namespace WebApplicationFirst.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            return new ViewResult();
        }

        public async Task<IActionResult> Contact()
        {
            return new ViewResult();
        }
    }
}
