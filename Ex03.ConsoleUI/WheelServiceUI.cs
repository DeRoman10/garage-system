using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class WheelServiceUI
    {
        private readonly Garage r_Garage;

        public WheelServiceUI(Garage i_SharedGarage)
        {
            r_Garage = i_SharedGarage;
        }

        public void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license plate number:");
            string userLicensePlate = Console.ReadLine();

            r_Garage.InflateWheelsToMax(userLicensePlate);
            

            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("All wheels inflated to maximum pressure");
            Console.WriteLine("=======================================");
            Console.WriteLine();
        }
    }
}
