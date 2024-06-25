﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualElevator.Validation
{
    public class Validate
    {

        public int ValidateMenuOption(string? option)
        {
            if (!int.TryParse(option, out int result))
            {
                Console.WriteLine("Wrong input!");
                return -1;
            }

            return result;
        }

        public int ValidateFloor(string? option)
        {
            if (!int.TryParse(option, out int result))
            {
                Console.WriteLine("Wrong input!");
                return -1;
            }

            return result;
        }
    }
}
