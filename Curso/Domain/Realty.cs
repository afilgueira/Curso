namespace Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// The realty.
    /// </summary>
    public class Realty
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

        /// <summary>
        /// Gets or sets the homes.
        /// </summary>
        public virtual IList<House> Homes { get; set; }

        /// <summary>
        /// Only for NHibernate
        /// </summary>
        public Realty()
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
        public Realty(string address, string details, Manager manager)
        {
            this.Address = address;
            this.Details = details;
            this.Hire(manager);
            this.Homes = new List<House>();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="details">
        /// The details.
        /// </param>
        /// <param name="newManager">
        /// The new manager.
        /// </param>
        public virtual void Update(string address, string details, Manager newManager)
        {
            this.Address = address;
            this.Details = details;
            this.Fire();
            this.Hire(newManager);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        public virtual void Delete()
        {
            this.Fire();
            
            //foreach (var home in this.Homes)
            //{
            //    home.Delete();
                
            //}
            for (int i = 0; this.Homes.Count > 0; i++)
            {
                this.Homes[i].Delete();
            }
            
        }

        /// <summary>
        /// The hire.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        private void Hire(Manager manager)
        {
            this.Manager = manager;
            this.Manager.Realties.Add(this);
        }

        /// <summary>
        /// The fire.
        /// </summary>
        private void Fire()
        {
            this.Manager.Realties.Remove(this); // Sacamos al viejo manager
        }
    }
}
