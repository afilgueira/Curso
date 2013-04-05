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
<<<<<<< .mine
            IList<Interested> interesteds = this.interestedService.GetAll();
            IList<Interested> interestedsFiltereds = new List<Interested>();
            foreach (var interested in interesteds)
            {
                foreach (var home in interested.Homes)
                {
                    if (home.Id==houseId)
                    {
                        interestedsFiltereds.Add(interested);
                        break;
                    }
                }
            }
            List<InterestedViewModel> model = interestedsFiltereds.Select(m => new InterestedViewModel(m.Id, m.Name, m.Phone)).ToList();


=======
            IList<Interested> interesteds = this.interestedService.GetAll();
            IList<Interested> interestedsFiltereds = new List<Interested>();
            foreach (var interested in interesteds)
            {
                foreach (var home in interested.Homes)
                {
                    if (home.Id==houseId)
                    {
                        interestedsFiltereds.Add(interested);
                        break;
                    }
                }
            }
            List<InterestedViewModel> model = interestedsFiltereds.Select(m => new InterestedViewModel(m.Id, m.Name, m.Phone)).ToList();
            return this.View(interesteds);
            
>>>>>>> .theirs
        }

    }
}
