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
                    eMenuOptions choice = GetMenuChoice();

                    exitRequested = executeMenuOption(choice);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private eMenuOptions GetMenuChoice()
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
                    addVehicle();
                    break;
                case eMenuOptions.DisplayLicensePlates:
                    displayLicensePlates();
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

        private void addVehicle()
        {
            string modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber;

            Console.WriteLine("Please enter vehicle model's name");
            modelName = Console.ReadLine();

            Console.WriteLine("Please enter vehicle's license plate number");
            licenseNumber = Console.ReadLine();

            Console.WriteLine("Please enter vehicle's type");
            vehicleType = Console.ReadLine();

            Console.WriteLine("Please enter vehicle owner's full name");
            ownerName = Console.ReadLine();

            Console.WriteLine("Please enter vehicle owner's phone number");
            ownerPhoneNumber = Console.ReadLine();

            List<VehiclePropertyInfo> typeSpecificInfo = m_Garage.AddVehicle(modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber);
            
            Dictionary<string, string> properties = setSpecificPropertiesForAddedVehicle(typeSpecificInfo);

            m_Garage.SetVehicleProperties(licenseNumber, properties);
        }

        private Dictionary<string, string> setSpecificPropertiesForAddedVehicle(List<VehiclePropertyInfo> typeSpecificInfo)
        {
            Dictionary<string, string> specificProperties = new Dictionary<string, string>();

            Console.WriteLine("Please enter the following additional information:");

            foreach (VehiclePropertyInfo vehiclePropertyInfo in typeSpecificInfo)
            {
                string currentPropertyValidOptions = string.Join("/", vehiclePropertyInfo.ValidValues);
                string currentPropertyName = vehiclePropertyInfo.InternalName;

                if (vehiclePropertyInfo.ValidValues.Length > 0)
                {
                    Console.WriteLine("{0}, options: {1}", vehiclePropertyInfo.DisplayName, currentPropertyValidOptions); ;
                }
                else
                {
                    Console.WriteLine("{0}:", vehiclePropertyInfo.DisplayName);
                }

                string userInput = Console.ReadLine();

                specificProperties.Add(currentPropertyName, userInput);
            }

            return specificProperties;
        }

        private void displayLicensePlates() { }
        private void changeVehicleStatus() { }
        private void inflateWheelsToMax() { }
        private void refuelVehicle() { }
        private void chargeVehicle() { }
        private void displayVehicleInfo() { }
    }
}
