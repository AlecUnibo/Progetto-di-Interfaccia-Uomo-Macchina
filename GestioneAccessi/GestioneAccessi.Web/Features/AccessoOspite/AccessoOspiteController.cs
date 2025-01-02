using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestioneAccessi.Web.Features.AccessoOspite
{
    public partial class AccessoOspiteController : Controller
    {
        private const string StatoAccessoCookie = "StatoAccesso"; // Nome del cookie per stato ingresso/uscita

        [HttpGet]
        public virtual IActionResult Index()
        {
            // Recupera il valore del cookie
            var statoAccesso = Request.Cookies[StatoAccessoCookie];

            // Se il cookie è vuoto o indica "Ingresso", reindirizza alla pagina di ingresso
            if (string.IsNullOrEmpty(statoAccesso) || statoAccesso == "Ingresso")
            {
                return RedirectToAction(nameof(Ingresso));
            }

            // Se il cookie indica "Uscita", reindirizza alla pagina di uscita
            return RedirectToAction(nameof(Uscita));
        }

        [HttpGet]
        public virtual IActionResult Ingresso()
        {
            ViewData["Title"] = "Pagina di Ingresso";
            return View();
        }

        [HttpPost]
        public virtual IActionResult Ingresso(string Nome, string Cognome, string Azienda)
        {
            // Validazione dei campi
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Cognome) || string.IsNullOrWhiteSpace(Azienda))
            {
                ModelState.AddModelError(string.Empty, "Tutti i campi sono obbligatori.");
                return View();
            }

            // Imposta il cookie a "Uscita" con TTL di 3 ore
            Response.Cookies.Append(StatoAccessoCookie, "Uscita", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(3),
                HttpOnly = true
            });

            // Reindirizza alla pagina Check-in
            return RedirectToAction(nameof(CheckIn));
        }

        [HttpGet]
        public virtual IActionResult CheckIn()
        {
            return View();
        }

        [HttpGet]
        public virtual IActionResult Uscita()
        {
            ViewData["Title"] = "Pagina di Uscita";

            return View("Uscita");
        }

        [HttpPost]
        public virtual IActionResult Uscita(object o)
        {
            return RedirectToAction(nameof(CheckOut));
        }

        [HttpGet]
       

        [HttpGet]
        public virtual IActionResult CheckOut()
        {
            // Cancella il cookie quando si accede alla pagina di uscita
            Response.Cookies.Delete(StatoAccessoCookie);

            return View();
        }

        [HttpGet]
        public virtual IActionResult PaginaBlu()
        {
            Response.Headers.Add("Refresh", "2; url=" + Url.Action(nameof(Index)));
            return Content("<body style='background-color:blue; color:white; display:flex; justify-content:center; align-items:center; height:100vh;'>" +
                           "<h1>Attendi un secondo!!</h1></body>", "text/html");
        }
    }
}
