﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Class1
    {
        public void CalculateConcession(string name, int age)

        {

            const int TotalFare = 500;

            int fare_cost = TotalFare - (TotalFare * 30) / 100;

            if (age <= 5)

            {

                Console.WriteLine("Little Champs - Free Ticket");

            }

            else if (age > 60)

            {

                Console.WriteLine("Senior Citizen" + " " + "Calculated Fare:" + fare_cost);

            }

            else

            {

                Console.WriteLine("Ticket Booked  " + TotalFare);

            }

        }

    }
}
