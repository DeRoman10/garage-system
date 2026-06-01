using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private readonly Garage r_Garage = new Garage();

        private readonly AddVehicleUI r_AddVehicleUI;
        private readonly InventoryUI r_InventoryUI;
        private readonly VehicleStatusUI r_VehicleStatusUI;
        private readonly WheelServiceUI r_WheelServiceUI;
        private readonly RefillingUI r_RefuellingUI;


        public GarageUI()
        {
            r_AddVehicleUI = new AddVehicleUI(r_Garage);
            r_InventoryUI = new InventoryUI(r_Garage);
            r_VehicleStatusUI = new VehicleStatusUI(r_Garage);
            r_WheelServiceUI = new WheelServiceUI(r_Garage);
            r_RefuellingUI = new RefillingUI(r_Garage);
        }

        public void Run()
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                try
                {
                    eMenuOptions choice = getMenuChoice();

                    exitRequested = executeMenuOption(choice);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private eMenuOptions getMenuChoice()
        {
            printMenu();

            eMenuOptions choice = (eMenuOptions)Enum.Parse(typeof(eMenuOptions), Console.ReadLine());

            return choice;
        }

        private void printMenu()
        {
            Console.WriteLine("=== Garage Management System ===");
            Console.WriteLine("1. Load vehicles from file");
            Console.WriteLine("2. Add new vehicle");
            Console.WriteLine("3. Display license plates");
            Console.WriteLine("4. Change vehicle status");
            Console.WriteLine("5. Inflate wheels to max");
            Console.WriteLine("6. Refuel vehicle");
            Console.WriteLine("7. Charge electric vehicle");
            Console.WriteLine("8. Display vehicle info");
            Console.WriteLine("9. Exit");
        }

        private bool executeMenuOption(eMenuOptions i_Choice)
        {
            bool exitRequested = false;

            switch (i_Choice)
            {
                case eMenuOptions.LoadFromFile:
                    loadFromFile();
                    break;
                case eMenuOptions.AddVehicle:
                    r_AddVehicleUI.AddVehicle();
                    break;
                case eMenuOptions.DisplayLicensePlates:
                    r_InventoryUI.displayLicensePlatesHandler();
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    r_VehicleStatusUI.ChangeVehicleStatus();
                    break;
                case eMenuOptions.InflateWheelsToMax:
                    r_WheelServiceUI.inflateWheelsToMax();
                    break;
                case eMenuOptions.RefuelVehicle:
                    r_RefuellingUI.RefillVehicle();
                    break;
                case eMenuOptions.ChargeVehicle:
                    r_RefuellingUI.RefillVehicle();
                    break;
                case eMenuOptions.DisplayVehicleInfo:
                    displayVehicleInfo();
                    break;
                case eMenuOptions.Exit:
                    exitRequested = true;
                    break;
            }

            return exitRequested;
        }

        private void loadFromFile() { }
        private void displayVehicleInfo() 
        {
            Console.WriteLine("Enter the license plate of the vehicle:");
            string licensePlate = Console.ReadLine();

            GarageTask task = r_Garage.GetTask(licensePlate);

            Console.WriteLine("======= Garage Record ======");
            Console.WriteLine("Owner name:  {0}" , task.OwnerName);
            Console.WriteLine("Owner phone: {0}", task.OwnerPhone);
            Console.WriteLine("Status:      {0}", task.VehicleStatus);
            Console.WriteLine();

            Console.WriteLine("======= Vehicle Info =======");
            Console.WriteLine("Model name:    {0}" , task.Vehicle.ModelName);
            Console.WriteLine("License plate: {0}", task.Vehicle.LicenseNumber);

            Console.WriteLine("Wheel manufacturer: {0}", task.Vehicle.Wheels[0].ManufacturerName);
            Console.WriteLine("Wheel air pressure: {0}", task.Vehicle.Wheels[0].CurrentAirPressure);

            Dictionary<string, string> energyInfo = task.Vehicle.EnergySource.GetEnergyDetails();
            printDictionaryDetails(energyInfo);

            Dictionary<string, string> uniqueDetails = task.Vehicle.GetUniqueVehicleDetails();
            printDictionaryDetails(uniqueDetails);
            Console.WriteLine();
        }
        private void printDictionaryDetails(Dictionary<string, string> i_Details)
        {
            foreach (string key in i_Details.Keys)
            {
                Console.WriteLine("{0}: {1}", key, i_Details[key]);
            }
        }
    }
}
