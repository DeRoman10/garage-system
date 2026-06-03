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
            Console.WriteLine("=============================");
            Console.WriteLine("your wheel pressure is now {0}", selectedVehicle.Wheels[0].MaximumAirPressure);
            Console.WriteLine("=============================");
            Console.WriteLine();
        }
    }
}
