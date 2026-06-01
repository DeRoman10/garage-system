using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void RefillVehicle()
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();
            Vehicle vehicleToRefill = r_Garage.GetVehicle(licensePlate);


            if (vehicleToRefill.EnergySource is FuelSource)
            {
                eFuelType[] availableFuelType = (eFuelType[])Enum.GetValues(typeof(eFuelType));
                Console.WriteLine("This is a fuel based vehicle.");

                printFilterOptions(availableFuelType);
                int userChoosenFuel = int.Parse(Console.ReadLine());

                if (userChoosenFuel - 1 < 0 || userChoosenFuel - 1 > availableFuelType.Length + 1)
                {
                    throw new ArgumentException("Invalid filter choice.");
                }

                eFuelType actualUserChoosenFuel = availableFuelType[userChoosenFuel - 1];
                Console.WriteLine("Enter amount of liters to refuel:");
                float liters = float.Parse(Console.ReadLine());

                vehicleToRefill.Refuel(actualUserChoosenFuel, liters);
                
                Console.WriteLine();
                Console.WriteLine("=============================");
                Console.WriteLine("Vehicle refueled successfully!");
                Console.WriteLine("=============================");
                Console.WriteLine();

            }
            else if (vehicleToRefill.EnergySource is ElectricSource)
            {
                Console.WriteLine("This is an electric vehicle.");

                Console.WriteLine("Enter amount of minutes to charge:");
                float minutes = float.Parse(Console.ReadLine());

                vehicleToRefill.Charge(minutes / 60f);
                
                Console.WriteLine();
                Console.WriteLine("=============================");
                Console.WriteLine("Vehicle charged successfully!");
                Console.WriteLine("=============================");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Unknown energy source.");
            }
        }
        private void printFilterOptions(eFuelType[] i_AvailableFuelType)
        {

            for (int i = 0; i < i_AvailableFuelType.Length; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, i_AvailableFuelType[i]);
            }

        }
    }
}
