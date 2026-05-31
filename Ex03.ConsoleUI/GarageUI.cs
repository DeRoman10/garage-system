using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private readonly Garage m_Garage = new Garage();

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

        public eMenuOptions getMenuChoice()
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
                case eMenuOption.LoadFromFile:
                    loadFromFile();
                    break;
                case eMenuOption.AddVehicle:
                    addVehicle();
                    break;
                case eMenuOption.DisplayLicensePlates:
                    displayLicensePlates();
                    break;
                case eMenuOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eMenuOption.InflateWheelsToMax:
                    inflateWheelsToMax();
                    break;
                case eMenuOption.RefuelVehicle:
                    refuelVehicle();
                    break;
                case eMenuOption.ChargeVehicle:
                    chargeVehicle();
                    break;
                case eMenuOption.DisplayVehicleInfo:
                    displayVehicleInfo();
                    break;
                case eMenuOption.Exit:
                    exitRequested = true;
                    break;
            }

            return exitRequested;
        }

        /*private void loadFromFile() { }
        private void addVehicle() { }
        private void displayLicensePlates() { }
        private void changeVehicleStatus() { }
        private void inflateWheelsToMax() { }
        private void refuelVehicle() { }
        private void chargeVehicle() { }
        private void displayVehicleInfo() { }*/

    }
}
