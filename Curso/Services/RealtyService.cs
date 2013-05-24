using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;
using Repository.Interfaces;


namespace Services
{
    public class RealtyService : IRealtyService
    {
        private readonly IRealtyRepository realtyRepository;
        private readonly IManagerRepository managerRepository;
        private readonly IInterestedRepository interestedRepository;
        private readonly IRepository<House> houseRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerService"/> class.
        /// </summary>
        /// <param name="managerRepository">
        /// The manager repository.
        /// </param>
        public RealtyService(IRealtyRepository realtyRepository, IManagerRepository managerRepository, IInterestedRepository intre,IRepository<House> hos)
        {
            this.realtyRepository = realtyRepository;
            this.managerRepository = managerRepository;
            this.interestedRepository = intre;
            this.houseRepository = hos;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Manager].
        /// </returns>
        public IList<Realty> GetAll()
        {
            IList<Realty> result = null;
            this.realtyRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.realtyRepository.GetAll().Where(m => m.Homes.Count>=0).ToList();
                

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
        public Realty Get(int id)
        {
            Realty result = null;
            this.realtyRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.realtyRepository.Get(id);
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
        public void Create(string address, string details, int managerId) 
        {
            this.realtyRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var manager = this.managerRepository.Get(managerId);
                var realty = new Realty(address,details,manager);
                this.realtyRepository.Add(realty);
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
        public void Update(int id,string address, string details, int managerId)
        {
            this.realtyRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var manager = this.managerRepository.Get(managerId);
                var realty = this.realtyRepository.Get(id);
                realty.Update(address,details,manager);
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
            this.realtyRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var realty = this.realtyRepository.Get(id);
                foreach (var home in realty.Homes)
                {
                    this.houseRepository.Delete(home);
                }
                realty.Delete();
                this.realtyRepository.Delete(realty);
            });
        }
    }
}
