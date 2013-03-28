using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Curso.ViewModels;

using Services;

namespace Curso.Controllers
{
    public class RealtyController : Controller
    {
        //
        // GET: /Realty/

        private readonly IRealtyService realtyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerController"/> class.
        /// </summary>
        /// <param name="managerService">
        /// The manager service.
        /// </param>
        public RealtyController(IRealtyService realtyService)
        {
            this.realtyService = realtyService;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Index()
        {
            
            List<RealtyViewModel> model = this.realtyService.GetAll().Select(m => new RealtyViewModel(m.Id, m.Address, m.Details,m.Manager)).ToList();
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
            var model = new RealtyViewModel();
            
            if (id != 0)
            {
                var realty = this.realtyService.Get(id);
                model = new RealtyViewModel(realty.Id, realty.Address, realty.Details,realty.Manager);
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
        public ActionResult Update(RealtyViewModel model)
        {
            if (model.Id == 0)
            {
                this.realtyService.Create(model.Address, model.Details, model.Manager);
            }
            else
            {
                this.realtyService.Update(model.Id, model.Address, model.Details, model.Manager);
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
            this.realtyService.Delete(id);
            return this.RedirectToAction("Index");
        }

    }
}
