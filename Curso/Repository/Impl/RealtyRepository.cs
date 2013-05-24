namespace Repository.Impl
{
    using System.Collections.Generic;

    using Domain;
    using Domain.Exceptions;

    using Repository.Interfaces;

    /// <summary>
    /// The realty repository.
    /// </summary>
    public class RealtyRepository : BaseRepository<Realty>, IRealtyRepository
    {
        public RealtyRepository(IHibernateSessionFactory hibernateSessionFactory) : base(hibernateSessionFactory)
        {   
        }
        /*
        /// <summary>
        /// The Realties.
        /// </summary>
        private readonly List<Realty> realties = new List<Realty>();

        /// <summary>
        /// The id counter.
        /// </summary>
        private int idCounter = 1000;

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Domain.Realty.
        /// </returns>
        /// <exception cref="ObjectNotFoundException"> If the realty is not found </exception>
        public Realty Get(int id)
        {
            foreach (var realty in this.realties)
            {
                if (realty.Id == id)
                {
                    return realty;
                }
            }

            throw new ObjectNotFoundException();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="realty">
        /// The realty.
        /// </param>
        public void Add(Realty realty)
        {
            realty.Id = this.GetId();
            this.realties.Add(realty);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var realty = this.Get(id);
            this.realties.Remove(realty);
        }

        /// <summary>
        /// The get id.
        /// </summary>
        /// <returns>
        /// The System.Int32.
        /// </returns>
        private int GetId()
        {
            this.idCounter++;
            return this.idCounter;
        }*/
    }
}
