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
        private int RealtyId { get; set; }
        private readonly IRealtyService realtyService;
        private Realty Realty { get; set; }
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
            this.RealtyId = realtyId;

            this.Realty = this.realtyService.Get(this.RealtyId);
            List<HouseViewModel> model = this.houseService.GetAll().Select(m => new HouseViewModel(m.Id,m.Realty, m.Address, m.Details)).Where(m => m.Realty.Equals(this.Realty)).ToList();
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
        public ActionResult Edit(int id)
        {
            var model = new HouseViewModel();
            
            if (id != 0)
            {
                var house = this.houseService.Get(id);
                model = new HouseViewModel(house.Id, house.Realty, house.Address, house.Details);
            }

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

            if (model.Id == 0)
            {
                this.houseService.Create(this.Realty, model.Address,model.Details);
            }
            else
            {
                this.houseService.Update(model.Id,model.Address, model.Details);
            }

            return this.RedirectToAction("Index");
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
            this.houseService.Delete(id);
            return this.RedirectToAction("Index");
        }
    }
}
