using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestioneAccessi.Web.Features.AccessoOspite
{
    public partial class AccessoOspiteController : Controller
    {
        public AccessoOspiteController()
        {
        }

        /// <summary>
        /// Scelta ingresso o uscita in realtà questa pagina sarebbe raggiunta tramite QRCode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Index()
        {
            //TODO: in base a presenza cookie ingresso vado a ingresso o uscita
            return RedirectToAction(MVC.AccessoOspite.Ingresso());
            return RedirectToAction(MVC.AccessoOspite.Uscita());
        }

        /// <summary>
        /// Mostro form ingresso
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public virtual IActionResult Ingresso()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Effettuo ingresso
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        public virtual IActionResult Ingresso(object o)
        {
            // TODO: Salvo cookie ingresso
            throw new NotImplementedException();
        }

        /// <summary>
        /// Comunico esito ingresso
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public virtual IActionResult IngressoRegistrato()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual IActionResult Uscita()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public virtual IActionResult Uscita(object o)
        {
            // TODO: rimuovo cookie ingresso
            throw new NotImplementedException();

        }

        [HttpGet]
        public virtual IActionResult UscitaRegistrata()
        {
            throw new NotImplementedException();
        }
    }
}
