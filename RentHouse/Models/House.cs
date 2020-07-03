using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Models
{
    public class House
    {
        public House()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HouseArea { get; set; }
        public string Address { get; set; }
        public Situation situation { get; set; }
        public int OwnerID { get; set; }



    }
    public enum Situation
    {
        Northern = 0,
        Southern = 1,
    }
}
