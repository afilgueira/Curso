
namespace Curso.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Curso.ViewModels;

    using Services;

    /// <summary>
    /// The manager controller.
    /// </summary>
    public class ManagerController : Controller
    {
        /// <summary>
        /// The manager service.
        /// </summary>
        private readonly IManagerService managerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerController"/> class.
        /// </summary>
        /// <param name="managerService">
        /// The manager service.
        /// </param>
        public ManagerController(IManagerService managerService)
        {
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
            // TIP: Este codigo es equivalente al de abajo
            // List<ManagerViewModel> model = new List<ManagerViewModel>();
            // foreach (var m in managerService.GetAll())
            // {
            //    model.Add(new ManagerViewModel(m.Id, m.Name, m.Age));
            // }

            List<ManagerViewModel> model = this.managerService.GetAll().Select(m => new ManagerViewModel(m.Id, m.Name, m.Age,m.Realties)).ToList(); 
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
            var model = new ManagerViewModel();
            
            if (id != 0)
            {
                var manager = this.managerService.Get(id);
                model = new ManagerViewModel(manager.Id, manager.Name, manager.Age);
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
        public ActionResult Update(ManagerViewModel model)
        {
            if (model.Id == 0)
            {
                this.managerService.Create(model.Name, model.Age);
            }
            else
            {
                this.managerService.Update(model.Id, model.Name, model.Age);
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
            try
            {
                this.managerService.Delete(id);
            }
            catch (Domain.Exceptions.ManagerHasRealtiesException e)
            {
                
            }
                return this.RedirectToAction("Index");
        }
    }
}
