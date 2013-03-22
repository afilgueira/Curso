using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;
using Domain;


namespace Services
{
    public class InterestedService:IInterestedService
    {
        /// <summary>
        /// The interested repository.
        /// </summary>
        private readonly IInterestedRepository interestedRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedService"/> class.
        /// </summary>
        /// <param name="interestedRepository">
        /// The interested repository.
        /// </param>
        public InterestedService(IInterestedRepository interestedRepository)
        {
            this.interestedRepository = interestedRepository;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Interested].
        /// </returns>
        public List<Interested> GetAll()
        {
            return this.interestedRepository.GetAll();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Domain.Manager.
        /// </returns>
        public Interested Get(int id)
        {
            return this.interestedRepository.Get(id);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        public void Create(string name, string phone) // TIP: Que pasaria si en vez de 2 parametros, el manager tuviera 100???
        {
            var interested = new Interested(name, phone);
            this.interestedRepository.Add(interested);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        public void Update(int id, string name, string phone)
        {
            var interested = this.interestedRepository.Get(id);
            interested.Update(name, phone);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var interested = this.interestedRepository.Get(id);
            interested.Delete();
            this.interestedRepository.Delete(id);
        }
    }
}
