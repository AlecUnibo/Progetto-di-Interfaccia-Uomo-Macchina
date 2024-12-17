using GestioneAccessi.Web.Infrastructure;
using GestioneAccessi.Web.SignalR;
using GestioneAccessi.Web.SignalR.Hubs.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using GestioneAccessi.Infrastructure;
using GestioneAccessi.Services.Shared;

namespace GestioneAccessi.Web.Areas.Accessi.Giornalieri
{
    [Area("Accessi")]
    public partial class GiornalieriController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public GiornalieriController(SharedService sharedService, IPublishDomainEvents publisher, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            _sharedLocalizer = sharedLocalizer;

            //ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            throw new NotImplementedException();
            //var users = await _sharedService.Query(model.ToUsersIndexQuery());
            //model.SetUsers(users);

            //return View(object o);
        }

      
    }
}
