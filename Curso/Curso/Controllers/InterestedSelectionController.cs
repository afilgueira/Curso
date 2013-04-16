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
            IList<Interested> interesteds = this.interestedService.GetAll();
            IList<Interested> interestedsFiltereds = this.interestedService.GetAll(houseId);
            //foreach (var interested in interesteds)
            //{
            //    foreach (var home in interested.Homes)
            //    {
            //        if (home.Id==houseId)
            //        {
            //            interestedsFiltereds.Add(interested);
            //            break;
            //        }
            //    }
            //}
            List<InterestedViewModel> model = interestedsFiltereds.Select(m => new InterestedViewModel(m.Id, m.Name, m.Phone,houseId)).ToList();
            return this.View(model);
            
        }

        public ActionResult Edit(int id)
        {
            var model = new HouseViewModel();


            if (id != 0)
            {
                var house = this.houseService.Get(id);
                model = new HouseViewModel(house.Id, house.Realty,house.Address, house.Details);
            }
            //aca meti mano para cargar la lista
            var interesteds = this.interestedService.GetAll().Select(interested => new SelectListItem { Value = interested.Id.ToString(), Text = interested.Name }).ToList();
            model.InterestedsList = interesteds;
            //
            return this.View(model);
        }

        public ActionResult Update( HouseViewModel model)
        {

            var interested = this.interestedService.Get(model.InterestedId);

            this.houseService.Update(model.Id, interested);

            
            return this.RedirectToAction("Index", new { houseId = model.Id });

        }

        public ActionResult Delete(int id, int houseId)
        {
            

           

            this.houseService.Delete(houseId,id);

            return this.RedirectToAction("Index", new { houseId = houseId });
        }
    }
}
