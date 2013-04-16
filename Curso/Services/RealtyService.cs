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
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerService"/> class.
        /// </summary>
        /// <param name="managerRepository">
        /// The manager repository.
        /// </param>
        public RealtyService(IRealtyRepository realtyRepository, IManagerRepository managerRepository)
        {
            this.realtyRepository = realtyRepository;
            this.managerRepository = managerRepository;
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
                result = this.realtyRepository.GetAll();
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
                realty.Delete();
                this.realtyRepository.Delete(realty);
            });
        }
    }
}
