using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;
using Repository.Interfaces;

namespace Repository.Impl
{
    public class HouseRepository : BaseRepository<House>, IHouseRepository
    {
        public HouseRepository(IHibernateSessionFactory hibernateSessionFactory) : base(hibernateSessionFactory)
        {   
        }
    }
}
