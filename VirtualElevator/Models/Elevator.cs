using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualElevator.Models
{
    public class Elevator
    {
        public int CurrentLevel { get; set; }
        public int Destination { get; set; }
        public int TripLevels { get; set; }
        public int LifeTimeTripLevels { get; set; }

    }
}
