using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class VehicleStatusUI
    {
        private readonly Garage r_Garage;

        public VehicleStatusUI(Garage i_SharedGarage)
        {
            r_Garage = i_SharedGarage;
        }

        public void ChangeVehicleStatus()
        {
            List<string> licensePlatesToDisplay = new List<string>(r_Garage.GetAllLicensePlates());
            eVehicleStatus[] availableStatuses = (eVehicleStatus[])Enum.GetValues(typeof(eVehicleStatus));
            
            printOptions(licensePlatesToDisplay);

            string userLicensePlate = Console.ReadLine();
            Console.WriteLine("Pick your required Car License");

            if (!licensePlatesToDisplay.Contains(userLicensePlate))
            {
                throw new ArgumentException($"License plate '{userLicensePlate}' wasn't found.");
            }

            GarageTask selectedtask = r_Garage.GetTask(userLicensePlate);
            Console.WriteLine("Your car status is {0} , you can change to", selectedtask.VehicleStatus);

            printFilterOptions(availableStatuses);
            int userFilterChoice = int.Parse(Console.ReadLine());
            
            if (userFilterChoice - 1 < 0 || userFilterChoice - 1 > availableStatuses.Length + 1)
            {
                throw new ArgumentException("Invalid filter choice.");
            }
            eVehicleStatus actualChosenFilter = availableStatuses[userFilterChoice - 1];
            selectedtask.VehicleStatus = actualChosenFilter;


        }
        private void printOptions(List<string> i_options)
        {
            for (int i = 0; i < i_options.Count; i++)
            {
                Console.WriteLine("{0}.", i_options[i]);
            }
        }
        private void printFilterOptions(eVehicleStatus[] i_AvailableStatuses)
        {

            for (int i = 0; i < i_AvailableStatuses.Length; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, i_AvailableStatuses[i]);
            }

        }
    }
}
