using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;

namespace Domain.NH.Mappings
{
    public class HouseMapping : ClassMap<House>
    {
        public HouseMapping()
        {
            this.Id(house => house.Id).GeneratedBy.Identity();
            this.Map(house => house.Address).Not.Nullable().Length(50).Not.LazyLoad();
            this.Map(house => house.Details).Not.Nullable().Length(200).Not.LazyLoad();
            this.References(house => house.Realty).Not.Nullable().Not.LazyLoad();
            this.HasManyToMany(house => house.Interesteds).AsBag().ParentKeyColumn("House_Id").ChildKeyColumn("Interested_Id").Not.LazyLoad() ;
        }
    }
}
