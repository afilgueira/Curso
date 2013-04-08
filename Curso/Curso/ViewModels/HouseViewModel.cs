using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Domain;

namespace Curso.ViewModels
{
    public class HouseViewModel
    {
        private int p;
        private string p_2;
        private string p_3;

         public virtual Realty Realty { get; set; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets the details.
        /// </summary>
        public virtual string Details { get; set; }

        /// <summary>
        /// Gets the interested people.
        /// </summary>
        public virtual IList<Interested> InterestedPeople { get; private set; }

        public virtual int RealtyId { get; set; }

        public int InterestedId { get; set; }

        public List<SelectListItem> InterestedsList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="House"/> class.
        /// </summary>
        /// <param name="realty">
        /// The realty.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="details">
        /// The details.
        /// </param>
        public virtual int Id { get; set; }
        public HouseViewModel(int id,Realty realty, string address, string details)
        {
            this.Id = id;
            this.Assign(realty);
            this.Address = address;
            this.Details = details;
            this.InterestedPeople = new List<Interested>();
        }

        public HouseViewModel() { }

       
        private void Assign(Realty realty)
        {
            this.Realty = realty;
            
        }
       
    }
}