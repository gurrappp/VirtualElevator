using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualElevator.Controller;
using VirtualElevator.Models;
using VirtualElevator.Validation;

namespace VirtualElevator.UI
{
    internal class UserInput
    {
        private Elevator elevator;
        private Validate validate;
        private ElevatorController controller;

        public UserInput() 
        { 
            elevator = new Elevator();
            validate = new Validate();
            controller  = new ElevatorController();

        }
        public void Menu()
        {
            bool closeApp = false;

            //Console.Clear();

            while (!closeApp)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Your options:");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - call elevator");
                Console.WriteLine();

                var option = Console.ReadLine();

                var answer = validate.ValidateMenuOption(option);
                if (answer is -1 or 0)
                {
                    Console.Clear();
                    closeApp = true;
                    break;
                }

                if(answer is not 1)
                {
                    Console.WriteLine("Wrong input! choose 0 or 1");
                    Console.WriteLine("--------------------------");
                    Menu();
                }

                var userLevel = GetUserLevel();

                controller.SetDestination(elevator, userLevel);
                
                Console.WriteLine($"\nIm currently at level: {controller.GetCurrentLevel(elevator)}. Traveling to you at level: {userLevel}");
                
                controller.UpdateTripLevels(elevator, elevator.CurrentLevel, userLevel);
                controller.UpdateLifeTimeTripLevels(elevator, elevator.CurrentLevel, userLevel);
                
                controller.SetCurrentLevel(elevator, userLevel);
                var destination = GetUserDestination(userLevel);

                Console.WriteLine($"\nTraveling to: {destination}");
                controller.SetDestination(elevator, destination);

                //controller.SetCurrentLevel(elevator, elevator.Destination);

                controller.UpdateTripLevels(elevator, elevator.CurrentLevel, destination);
                controller.UpdateLifeTimeTripLevels(elevator, elevator.CurrentLevel, destination);
                Console.Clear();
                Console.WriteLine($"\nArrived at destination: {elevator.CurrentLevel}");
                Console.WriteLine($"\nI have travelled {elevator.TripLevels} levels this trip.");
                Console.WriteLine($"\nI have travelled {elevator.LifeTimeTripLevels} levels since I was installed at this facility.\n");
                controller.ResetTripLevels(elevator);
                
            }
        }

        public int GetUserLevel()
        {
            var answer = 0;
            Console.WriteLine("\nPlease write your current level:");
            var correctLevelInput = false;
            while (!correctLevelInput)
            {
                var option = Console.ReadLine();
                answer = validate.ValidateMenuOption(option);
                if (answer is < 0 or > 137)
                {

                    Console.WriteLine("\nPlease enter a number between 0 and 137");

                }
                else
                    correctLevelInput = true;

            }

            return answer;
        }

        public int GetUserDestination(int currentLevel)
        {
            var answer = 0;
            Console.WriteLine("\nWhat level do you want to travel to ?");
            var correctLevelInput = false;
            while (!correctLevelInput)
            {
                var option = Console.ReadLine();
                answer = validate.ValidateMenuOption(option);
                if (answer is < 0 or > 137)
                {

                    Console.WriteLine("\nPlease enter a number between 0 and 137");

                }
                else if(answer == currentLevel)
                {
                    Console.WriteLine($"\nYou are already on {answer}!");
                    Console.WriteLine("\nPlease enter a number between 0 and 137");
                }
                else
                    correctLevelInput = true;

            }

            return answer;
        }
    }
}
