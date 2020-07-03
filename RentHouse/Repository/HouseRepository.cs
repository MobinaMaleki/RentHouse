using Microsoft.EntityFrameworkCore;
using RentHouse.Data;
using RentHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Repository
{
    public class HouseRepository : Repository<int, House>, IHouseRepository
    {
        public HouseRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

      

        //public async Task<int> UpdateHouse(House house)
        //{
        //Update( house);
        //    return await _dbcontext.SaveChangesAsync();
        //}

    }
}
