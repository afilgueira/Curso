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
    public class RealtyController : Controller
    {
        //
        // GET: /Realty/

        private readonly IRealtyService realtyService;
        private readonly IManagerService managerService;
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerController"/> class.
        /// </summary>
        /// <param name="managerService">
        /// The manager service.
        /// </param>
        public RealtyController(IRealtyService realtyService,IManagerService managerService)
        {
            this.realtyService = realtyService;
            this.managerService = managerService;
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
            //aca meti mano para cargar la lista
            var managers = this.managerService.GetAll().Select(manager => new SelectListItem { Value = manager.Id.ToString(), Text = manager.Name }).ToList();
            model.ManagersList = managers;
            //
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
        public ActionResult Update(RealtyViewModel model)
        {
            var manager = this.managerService.Get(model.ManagerId);
            if (model.Id == 0)
            {
                
                this.realtyService.Create(model.Address, model.Details, manager);
            }
            else
            {
                this.realtyService.Update(model.Id, model.Address, model.Details, manager);
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
