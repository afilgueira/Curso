using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

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
        public string Name { get; private set; }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// Gets the homes.
        /// </summary>
        public List<Home> Homes { get; private set; }

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
            this.Homes = new List<Home>();
        }

        public InterestedViewModel() { }
    }
}