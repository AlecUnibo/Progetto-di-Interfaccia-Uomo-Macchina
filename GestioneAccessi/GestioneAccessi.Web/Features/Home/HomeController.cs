using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestioneAccessi.Web.Features.Home
{
    public partial class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            // Restituisce la vista Home.cshtml
            return View("Home");
        }

        [HttpGet]
        public virtual IActionResult Stampa()
        {
            // Restituisce la vista Stampa.cshtml
            return View("Stampa");
        }

        [HttpGet]
        public virtual IActionResult Giornaliera()
        {
            // Restituisce la vista Giornaliera.cshtml
            return View("Giornaliera");
        }

        [HttpGet]
        public virtual IActionResult Pianifica()
        {
            // Restituisce la vista Pianifica.cshtml
            return View("Pianifica");
        }

        [HttpPost]
        public virtual IActionResult ChangeLanguageTo(string cultureName)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), Secure = true }    // Secure assicura che il cookie sia inviato solo per connessioni HTTPS
            );

            return Redirect(Request.GetTypedHeaders().Referer.ToString());
        }
    }
}
