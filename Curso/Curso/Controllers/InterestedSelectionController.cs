using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Services;
using Domain;
using Curso;
using Curso.ViewModels;

namespace Curso.Controllers
{
    public class InterestedSelectionController : Controller
    {
        //
        // GET: /InterestedSelection/

        private readonly IInterestedService interestedService;
        private readonly IHouseService houseService;

        public InterestedSelectionController(IHouseService houseService, IInterestedService interestedService)
        {
            this.houseService = houseService;
            this.interestedService = interestedService;
        }

        public ActionResult Index(int houseId)
        {
            List<InterestedViewModel> model = this.interestedService.GetAll().Select(m => new InterestedViewModel(m.Id, m.Name, m.Phone)).Where(m => m.Homes.Exists(mo => mo.Id == houseId)).ToList();
            
            return this.View(model);
            
        }

    }
}
