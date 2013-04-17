using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Curso.Controllers
{
    

    using Curso.ViewModels;

    using Services;
    public class InterestedController : Controller
    {
         /// <summary>
        /// The manager service.
        /// </summary>
        private readonly IInterestedService interestedService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedController"/> class.
        /// </summary>
        /// <param name="interestedService">
        /// The manager service.
        /// </param>
        public InterestedController(IInterestedService interestedService)
        {
            this.interestedService = interestedService;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Index()
        {
            // TIP: Este codigo es equivalente al de abajo
            // List<ManagerViewModel> model = new List<ManagerViewModel>();
            // foreach (var m in managerService.GetAll())
            // {
            //    model.Add(new ManagerViewModel(m.Id, m.Name, m.Age));
            // }

            List<InterestedViewModel> model = this.interestedService.GetAll().Select(m => new InterestedViewModel(m.Id, m.Name, m.Phone,m.Homes)).ToList();
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
            var model = new InterestedViewModel();
            
            if (id != 0)
            {
                var interested = this.interestedService.Get(id);
                model = new InterestedViewModel(interested.Id, interested.Name, interested.Phone);
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
        public ActionResult Update(InterestedViewModel model)
        {
            if (model.Id == 0)
            {
                this.interestedService.Create(model.Name, model.Phone);
            }
            else
            {
                this.interestedService.Update(model.Id, model.Name, model.Phone);
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
            this.interestedService.Delete(id);
            
                return this.RedirectToAction("Index");
        }
    

    }
}
