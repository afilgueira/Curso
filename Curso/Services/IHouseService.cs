using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;

namespace Services
{
    public interface IHouseService
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Manager].
        /// </returns>
        IList<House> GetAll();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Domain.Manager.
        /// </returns>
        House Get(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        void Create(Realty realty, string address, string details);

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
        void Update(int id, string address, string details);
        void Update(int id, Interested interested);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
        void Delete(int id,int intest);
    }
}
