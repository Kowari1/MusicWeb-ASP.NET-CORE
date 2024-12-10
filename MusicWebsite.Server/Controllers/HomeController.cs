using Microsoft.AspNetCore.Mvc;

namespace MusicWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
