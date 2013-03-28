namespace Repository.Interfaces
{
    using Domain;

    /// <summary>
    /// The RealtyRepository interface.
    /// </summary>
    public interface IRealtyRepository : IRepository<Realty> // Tip: Pensar porque no tiene un metodo de "update"
    {
        ///// <summary>
        ///// The get.
        ///// </summary>
        ///// <param name="id">
        ///// The id.
        ///// </param>
        ///// <returns>
        ///// The Domain.Realty.
        ///// </returns>
        //Realty Get(int id);

        ///// <summary>
        ///// The add.
        ///// </summary>
        ///// <param name="realty">
        ///// The realty.
        ///// </param>
        //void Add(Realty realty);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        //void Delete(int id);
    }
}