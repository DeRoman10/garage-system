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

            Console.WriteLine("Enter the license plate number:");
            
            string licensePlate = Console.ReadLine();

            GarageTask selectedtask = r_Garage.GetTask(licensePlate);
            Console.WriteLine("Your car status is {0} , you can change to", selectedtask.VehicleStatus);

            eVehicleStatus[] vehicleStatusOptions = (eVehicleStatus[])Enum.GetValues(typeof(eVehicleStatus));
            int chosenOptionIndex = ConsoleUtils.chooseOption(new List<eVehicleStatus>(vehicleStatusOptions));
            eVehicleStatus chosenStatus = vehicleStatusOptions[chosenOptionIndex];

            r_Garage.ChangeStatus(licensePlate, chosenStatus);
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("Vehicle status changed successfully!");
            Console.WriteLine("====================================");
            Console.WriteLine();


        }
    }
}
