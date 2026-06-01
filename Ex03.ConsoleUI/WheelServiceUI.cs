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

        public void inflateWheelsToMax()
        {
            Console.WriteLine("Pick your required Car License");
            string userLicensePlate = Console.ReadLine();
            
            Vehicle selectedVehicle = r_Garage.GetVehicle(userLicensePlate);
            selectedVehicle.InflateWheelsToMax();
            

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("your wheel pressure is now {0}", selectedVehicle.Wheels[0].MaximumAirPressure);
            Console.WriteLine("=============================");
            Console.WriteLine();
        }
    }
}
