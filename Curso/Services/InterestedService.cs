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

        private readonly IRepository<House> houseRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedService"/> class.
        /// </summary>
        /// <param name="interestedRepository">
        /// The interested repository.
        /// </param>
        public InterestedService(IInterestedRepository interestedRepository, IRepository<House> horepo)
        {
            this.interestedRepository = interestedRepository;
            this.houseRepository = horepo;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Interested].
        /// </returns>
        public IList<Interested> GetAll()
        {
            IList<Interested> result = null;
            this.interestedRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.interestedRepository.GetAll();
            });

            return result;
        }

        public IList<Interested> GetAll(int houseId)
        {
            IList<Interested> result = null;
            this.interestedRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                var house = this.houseRepository.Get(houseId);
                result = this.interestedRepository.GetAll().Where(m => m.Homes.Contains(house)).ToList();
            });

            return result;
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
            Interested result = null;
            this.interestedRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.interestedRepository.Get(id);
            });
            return result;
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
            this.interestedRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var interested = new Interested(name, phone);
                this.interestedRepository.Add(interested);
            });
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
            this.interestedRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var interested = this.interestedRepository.Get(id);
                interested.Update(name, phone);
            });
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.interestedRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var interested = this.interestedRepository.Get(id);
                interested.Delete();
                this.interestedRepository.Delete(interested);
            });
        }
    }
}
