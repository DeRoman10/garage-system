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
            List<string> licensePlatesToDisplay = new List<string>(r_Garage.GetAllLicensePlates());
            printOptions(licensePlatesToDisplay);

            string userLicensePlate = Console.ReadLine();
            Console.WriteLine("Pick your required Car License");

            if (!licensePlatesToDisplay.Contains(userLicensePlate))
            {
                throw new ArgumentException($"License plate '{userLicensePlate}' wasn't found.");
            }

            Vehicle selectedVehicle = r_Garage.GetVehicle(userLicensePlate);
            selectedVehicle.InflateWheelsToMax();
            Console.WriteLine("Task done , your wheel pressure is now {0}" , selectedVehicle.Wheels[0].MaximumAirPressure);
        }

        private void printOptions(List<string> i_options)
        {
            for (int i = 0; i < i_options.Count; i++)
            {
                Console.WriteLine("{0}.", i_options[i]);
            }
        }

    }
}
