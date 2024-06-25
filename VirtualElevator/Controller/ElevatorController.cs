using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualElevator.Models;

namespace VirtualElevator.Controller
{
    public class ElevatorController
    {
        public int GetCurrentLevel(Elevator elevator )
        {
            return elevator.CurrentLevel;
        }

        public void SetDestination(Elevator elevator, int destination)
        {
            elevator.Destination = destination;
        }

        public void SetCurrentLevel(Elevator elevator, int level)
        {
            elevator.CurrentLevel = level;
        }

        public void UpdateTripLevels(Elevator elevator , int level, int destination)
        {
            elevator.TripLevels += Math.Abs(level - destination);
        }

        public void UpdateLifeTimeTripLevels(Elevator elevator, int level, int destination)
        {
            elevator.LifeTimeTripLevels += Math.Abs(level - destination);
        }

        public void ResetTripLevels(Elevator elevator)
        {
            elevator.TripLevels = 0;
        }
    }
}
