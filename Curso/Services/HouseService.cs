using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Interfaces;
using Domain;

namespace Services
{
    public class HouseService:IHouseService
    {
        private readonly IRepository<House> houseRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerService"/> class.
        /// </summary>
        /// <param name="managerRepository">
        /// The manager repository.
        /// </param>
        public HouseService(IRepository<House> houseRepository)
        {
            this.houseRepository = houseRepository;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Manager].
        /// </returns>
        public IList<House> GetAll()
        {
            IList<House> result = null;
            this.houseRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.houseRepository.GetAll();
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
        public House Get(int id)
        {
            House result = null;
            this.houseRepository.GetSessionFactory().SessionInterceptor(() =>
            {
                result = this.houseRepository.Get(id);
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
        public void Create(Realty realty, string address, string details) 
        {
            this.houseRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var house = new House(realty, address, details);
                this.houseRepository.Add(house);
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
        public void Update(int id, string address, string details)
        {
            this.houseRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var house = this.houseRepository.Get(id);
                house.Update(address, details);
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
            this.houseRepository.GetSessionFactory().TransactionalInterceptor(() =>
            {
                var house = this.houseRepository.Get(id);
                house.Delete();
                this.houseRepository.Delete(house);
            });
        }
    }
}
