using RentHouse.Data;
using RentHouse.Models;
using RentHouse.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Repository.Interface
{
    public class LandOwnerRepository : Repository<int, LandOwner>, ILandOwnerRepository
    {
        public LandOwnerRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }


    }
}
