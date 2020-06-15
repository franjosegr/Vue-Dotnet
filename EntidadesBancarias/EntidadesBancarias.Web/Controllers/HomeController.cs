using Microsoft.AspNetCore.Mvc;

namespace EntidadesBancarias.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}