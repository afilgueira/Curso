﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Domain;

namespace Curso.ViewModels
{
    public class RealtyViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public virtual string Details { get; set; }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public virtual Manager Manager { get; set; }

        public virtual string ManagerName { get; set; }
        /// <summary>
        /// Gets or sets the homes.
        /// </summary>
        public virtual IList<Home> Homes { get; set; }

        /// <summary>
        /// Only for NHibernate
        /// </summary>
        public RealtyViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Realty"/> class.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="details">
        /// The details.
        /// </param>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public RealtyViewModel(int id,string address, string details, Manager manager)
        {
            this.Id = id;
            this.Address = address;
            this.Details = details;
            this.Hire(manager);
            this.ManagerName = manager.Name;
            this.Homes = new List<Home>();
        }

        private void Hire(Manager manager)
        {
            this.Manager = manager;
            //FIXME
            //this.Manager.Realties.Add(this);
        }
    }
}