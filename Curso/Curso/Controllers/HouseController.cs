using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Curso.ViewModels;

using Services;
using Domain;

namespace Curso.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        
        private readonly IRealtyService realtyService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerController"/> class.
        /// </summary>
        /// <param name="managerService">
        /// The manager service.
        /// </param>
        public HouseController(IHouseService houseService,IRealtyService realtyService)
        {
            this.houseService = houseService;
            this.realtyService = realtyService;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Index(int realtyId)
        {
            

            
            List<HouseViewModel> model = this.houseService.GetAll().Select(m => new HouseViewModel(m.Id,m.Realty, m.Address, m.Details)).Where(m => m.Realty.Id==realtyId).ToList();
            
            return this.View(model);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Edit(int id,int realtyId)
        {
            var model = new HouseViewModel();
            
            if (id != 0)
            {
                var house = this.houseService.Get(id);
                model = new HouseViewModel(house.Id, house.Realty, house.Address, house.Details);
            }

            model.RealtyId = realtyId;
            
            //model.Realty = this.realtyService.Get(realtyId);
            
            return this.View(model);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Update(HouseViewModel model)
        {
            //model.Realty = this.realtyService.Get(model.RealtyId);
            if (model.Id == 0)
            {
                this.houseService.Create(model.RealtyId, model.Address,model.Details);
            }
            else
            {
                this.houseService.Update(model.Id,model.Address, model.Details);
            }

            return this.RedirectToAction("Index", new { realtyId = model.RealtyId });
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Delete(int id)
        {
            int mRealtyId = this.houseService.Get(id).Realty.Id;
            this.houseService.Delete(id);
            return this.RedirectToAction("Index", new { realtyId = mRealtyId });
        }
    }
}
