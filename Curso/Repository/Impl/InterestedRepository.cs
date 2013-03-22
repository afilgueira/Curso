namespace Repository.Impl
{
    using System.Collections.Generic;

    using Domain;
    using Domain.Exceptions;

    using Repository.Interfaces;

    /// <summary>
    /// The interested repository.
    /// </summary>
    public class InterestedRepository : IInterestedRepository
    {
        /// <summary>
        /// The Interesteds.
        /// </summary>
        private readonly List<Interested> interesteds = new List<Interested>();

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
        /// The Domain.Interested.
        /// </returns>
        /// <exception cref="ObjectNotFoundException"> If the Interested is not found </exception>
        public Interested Get(int id)
        {
            foreach (var interested in this.interesteds)
            {
                if (interested.Id == id)
                {
                    return interested;
                }
            }

            throw new ObjectNotFoundException();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="interested">
        /// The Interested.
        /// </param>
        public void Add(Interested interested)
        {
            interested.Id = this.GetId();
            this.interesteds.Add(interested);
        }
        
        public List<Interested> GetAll()
        {
            return this.interesteds;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var interested = this.Get(id);
            this.interesteds.Remove(interested);
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
        }
    }
}
