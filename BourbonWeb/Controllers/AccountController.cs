using Microsoft.AspNetCore.Mvc;

namespace BourbonWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }
    }
}
