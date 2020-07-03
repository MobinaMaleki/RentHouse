using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Repository
{
    public interface IHouseRepository  : IRepository<int, House>
    {
        Task<int> SaveChangesAsync();
       
    }
}
