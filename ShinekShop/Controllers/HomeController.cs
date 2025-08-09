using Microsoft.AspNetCore.Mvc;

namespace ShinekShopWeb.Controllers
{
    public class HomeController : SiteBaseController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
