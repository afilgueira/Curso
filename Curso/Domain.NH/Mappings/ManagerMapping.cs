namespace Domain.NH.Mappings
{
    using FluentNHibernate.Mapping;

    /// <summary>
    /// The manager mapping.
    /// </summary>
    public class ManagerMapping : ClassMap<Manager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerMapping"/> class.
        /// </summary>
        public ManagerMapping()
        {
            this.Id(manager => manager.Id).GeneratedBy.Identity();
            this.Map(manager => manager.Name).Not.Nullable().Length(50).Not.LazyLoad();
            this.Map(manager => manager.Age).Not.Nullable().Not.LazyLoad();
            this.HasMany(manager => manager.Realties).AsBag().Table("Realty").KeyColumn("Manager_Id").Inverse().LazyLoad();

            // References(manager => manager.Link).Nullable().Not.LazyLoad();
            // HasManyToMany(manager => manager.MuchosAMuchos).AsBag().ParentKeyColumn("Manager_Id").ChildKeyColumn("Otro_Id").Table("UserToRole").LazyLoad();
            // HasMany(user => user.UnoAMuchos).AsBag().Table("Nombre").KeyColumn("Manager_Id").LazyLoad();
        }
    }
}
