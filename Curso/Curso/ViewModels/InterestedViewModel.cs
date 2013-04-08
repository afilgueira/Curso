using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.Web.Mvc;

namespace Curso.ViewModels
{
    public class InterestedViewModel
    {
         /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets the homes.
        /// </summary>
        public List<House> Homes { get; set; }

        public virtual Interested Interested { get; set; }

        public virtual int HouseId { get; set; }

      

        /// <summary>
        /// Initializes a new instance of the <see cref="Interested"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        public InterestedViewModel(int id,string name, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Homes = new List<House>();
        }

        public InterestedViewModel(int id, string name, string phone,int houseId)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Homes = new List<House>();
            this.HouseId = houseId;
        }

        

        public InterestedViewModel() { }
    }
}