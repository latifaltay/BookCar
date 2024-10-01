using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Domain.Entities
{
    public class RentACar
    {
        public int RentACarId { get; set; }
        public int PickUpLocationId { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
        public List<RentACar> RentACars { get; set; }

    }
}
