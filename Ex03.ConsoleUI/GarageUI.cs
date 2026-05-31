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

        public GarageUI()
        {
            r_AddVehicleUI = new AddVehicleUI(r_Garage);
            r_InventoryUI = new InventoryUI(r_Garage);
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
                    changeVehicleStatus();
                    break;
                case eMenuOptions.InflateWheelsToMax:
                    inflateWheelsToMax();
                    break;
                case eMenuOptions.RefuelVehicle:
                    refuelVehicle();
                    break;
                case eMenuOptions.ChargeVehicle:
                    chargeVehicle();
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

        private void changeVehicleStatus() { }
        private void inflateWheelsToMax() { }
        private void refuelVehicle() { }
        private void chargeVehicle() { }
        private void displayVehicleInfo() { }
    }
}
