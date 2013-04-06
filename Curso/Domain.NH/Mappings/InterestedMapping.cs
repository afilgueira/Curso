namespace Domain.NH.Mappings
{
    using FluentNHibernate.Mapping;

    /// <summary>
    /// The realty mapping.
    /// </summary>
    public class InterestedMapping : ClassMap<Interested>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtyMapping"/> class. 
        /// </summary>
        public InterestedMapping()
        {
            this.Id(interested => interested.Id).GeneratedBy.Identity();
            this.Map(interested => interested.Name).Not.Nullable().Length(50).Not.LazyLoad();
            this.Map(interested => interested.Phone).Not.Nullable().Length(20).Not.LazyLoad();
            //this.References(interested => interested.Homes).Not.Nullable().Not.LazyLoad();
            this.HasManyToMany(interested => interested.Homes).AsBag().ParentKeyColumn("Interested_id").ChildKeyColumn("House_id").Inverse().Not.LazyLoad();
        }
    }
}
