using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class RefillingUI
    {
        private readonly Garage r_Garage;

        public RefillingUI(Garage i_SharedGarage)
        {
            r_Garage = i_SharedGarage;
        }

        public void RefuelVehicle()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Enter the required fuel type:");

            eFuelType[] fuelTypes = (eFuelType[])Enum.GetValues(typeof(eFuelType));
            int index = ConsoleUtils.ChooseOption(new List<eFuelType>(fuelTypes));

            eFuelType chosenFuelType = fuelTypes[index];

            Console.WriteLine("Enter amount of liters to refuel:");
            float liters = float.Parse(Console.ReadLine());

            r_Garage.Refuel(licensePlate, chosenFuelType, liters);

            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("Vehicle refueled successfully!");
            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        public void ChargeVehicle()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Enter the amount of minutes to charge:");
            float minutesToCharge = int.Parse(Console.ReadLine());

            r_Garage.Charge(licensePlate, minutesToCharge);

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("Vehicle charged successfully!");
            Console.WriteLine("=============================");
            Console.WriteLine();
        }
    }
}
