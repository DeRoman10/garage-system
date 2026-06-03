using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class InventoryUI
    {
        private readonly Garage r_Garage;

        public InventoryUI(Garage i_SharedGarage)
        {
            r_Garage = i_SharedGarage;
        }

        public void DisplayLicensePlatesHandler()
        {
            eVehicleStatus[] availableStatuses = (eVehicleStatus[])Enum.GetValues(typeof(eVehicleStatus));
            List<string> licensePlatesToDisplay = new List<string>();

            Console.WriteLine("Choose a status to filter by or none for full list:");

            printFilterOptions(availableStatuses);

            int userFilterChoice = int.Parse(Console.ReadLine());

            eVehicleStatus actualChosenFilter;

            if (userFilterChoice - 1 < 0 || userFilterChoice > availableStatuses.Length + 1)
            {
                throw new ArgumentException("Invalid filter choice.");
            }

            if (userFilterChoice == availableStatuses.Length + 1)
            {
                licensePlatesToDisplay = r_Garage.GetAllLicensePlates();
            }
            else
            {
                actualChosenFilter = availableStatuses[userFilterChoice - 1];
                licensePlatesToDisplay = r_Garage.GetLicensePlatesByStatus(actualChosenFilter);
            }

            foreach (string licenseNumber in licensePlatesToDisplay)
            {
                Console.WriteLine(licenseNumber);
            }

            Console.WriteLine();
        }

        private void printFilterOptions(eVehicleStatus[] i_AvailableStatuses)
        {

            for (int i = 0; i < i_AvailableStatuses.Length; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, i_AvailableStatuses[i]);
            }

            Console.WriteLine("{0}) None", i_AvailableStatuses.Length + 1);

        }
    }
}
