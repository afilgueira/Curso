namespace Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// The interested.
    /// </summary>
    public class Interested
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name { get;  set; }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        public virtual string Phone { get;  set; }

        /// <summary>
        /// Gets the homes.
        /// </summary>
        public virtual IList<House> Homes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interested"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        public Interested(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
            this.Homes = new List<House>();
        }

        public Interested() { }
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        public virtual void Update(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        public virtual void Delete()
        {
            foreach (var home in this.Homes)
            {
                home.RemoveInterested(this);
            }
        }
    }
}
