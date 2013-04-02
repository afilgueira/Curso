using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;


namespace Services
{
    public interface IInterestedService
    { /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Domain.Interested].
        /// </returns>
        IList<Interested> GetAll();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Domain.Manager.
        /// </returns>
        Interested Get(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        void Create(string name,string phone);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>

        void Update(int id, string name, string phone);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
