using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Models
{
    public class LandOwner
    {
        public LandOwner()
        {

        }
        [Key]
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}
