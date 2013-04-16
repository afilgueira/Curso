namespace Domain.NH.Mappings
{
    using FluentNHibernate.Mapping;

    /// <summary>
    /// The realty mapping.
    /// </summary>
    public class RealtyMapping : ClassMap<Realty>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtyMapping"/> class. 
        /// </summary>
        public RealtyMapping()
        {
            this.Id(realty => realty.Id).GeneratedBy.Identity();
            this.Map(realty => realty.Address).Not.Nullable().Length(50).Not.LazyLoad();
            this.Map(realty => realty.Details).Not.Nullable().Length(200).Not.LazyLoad();
            this.References(realty => realty.Manager).Not.Nullable().Not.LazyLoad();
            this.HasMany(realty => realty.Homes).AsBag().Table("Home").KeyColumn("Realty_Id").Inverse().LazyLoad();
        }
    }
}
