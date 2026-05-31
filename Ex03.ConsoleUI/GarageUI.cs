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
                    addVehicle();
                    break;
                case eMenuOptions.DisplayLicensePlates:
                    displayLicensePlatesHandler();
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
            string modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber, wheelManufacturerName;
            int airPressure = 0, energyPercentage = 0;

            Console.WriteLine("Please enter vehicle model's name");
            modelName = Console.ReadLine();

            Console.WriteLine("Please enter vehicle's license plate number");
            licenseNumber = Console.ReadLine();

            Console.WriteLine("Please enter the corresponding number of the vehicle's type:");
            vehicleType = vehicleTypeInputHandler();

            Console.WriteLine("Please enter wheel's manufacturer name:");
            wheelManufacturerName = Console.ReadLine();

            Console.WriteLine("Please enter wheel's current air pressure:");
            airPressure = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter vehicle's current energy level %:");
            energyPercentage = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter vehicle owner's full name");
            ownerName = Console.ReadLine();

            Console.WriteLine("Please enter vehicle owner's phone number");
            ownerPhoneNumber = Console.ReadLine();

            List<VehiclePropertyInfo> typeSpecificInfo = m_Garage.AddVehicle(modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber);

            Dictionary<string, string> properties = setSpecificPropertiesForAddedVehicle(typeSpecificInfo);

            try
            {
                m_Garage.SetVehicleProperties(licenseNumber, properties);
                m_Garage.SetWheelProperties(licenseNumber, wheelManufacturerName, airPressure);
                m_Garage.SetInitialEnergyByPercentage(licenseNumber, energyPercentage);
            }
            catch
            {
                m_Garage.RemoveVehicle(licenseNumber);
                throw;
            }

            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine("Vehicle added successfully!");
            Console.WriteLine("===========================");
            Console.WriteLine();
        }

        private string vehicleTypeInputHandler()
        {
            printTypes();

            int userChoice = int.Parse(Console.ReadLine());
            string actualChosenType = string.Empty;

            if (userChoice - 1 < 0 || userChoice - 1 >= VehicleCreator.SupportedTypes.Count)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            actualChosenType = VehicleCreator.SupportedTypes[userChoice - 1];

            return actualChosenType;
        }

        private void printTypes()
        {
            for (int i = 0; i < VehicleCreator.SupportedTypes.Count; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, VehicleCreator.SupportedTypes[i]);
            }
        }

        private Dictionary<string, string> setSpecificPropertiesForAddedVehicle(List<VehiclePropertyInfo> i_TypeSpecificInfo)
        {
            Dictionary<string, string> specificProperties = new Dictionary<string, string>();

            Console.WriteLine("Please enter the following additional information:");

            foreach (VehiclePropertyInfo vehiclePropertyInfo in i_TypeSpecificInfo)
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

        private void displayLicensePlatesHandler()
        {
            eVehicleStatus[] availableStatuses = (eVehicleStatus[])Enum.GetValues(typeof(eVehicleStatus));
            List<string> licensePlatesToDisplay = new List<string>();

            Console.WriteLine("Choose a status to filter by or none for full list:");

            printFilterOptions(availableStatuses);

            int userFilterChoice = int.Parse(Console.ReadLine());
            
            eVehicleStatus actualChosenFilter;

            if (userFilterChoice - 1 < 0 || userFilterChoice - 1 > availableStatuses.Length + 1) 
            {
                throw new ArgumentException("Invalid filter choice.");
            }

            if (userFilterChoice == availableStatuses.Length + 1)
            {
                licensePlatesToDisplay = m_Garage.GetAllLicensePlates();
            }
            else
            {
                actualChosenFilter = availableStatuses[userFilterChoice - 1];
                licensePlatesToDisplay = m_Garage.GetLicensePlatesByStatus(actualChosenFilter);
            }

            foreach (string licenseNumber in licensePlatesToDisplay)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private void printFilterOptions(eVehicleStatus[] i_AvailableStatuses)
        {

            for (int i = 0; i < i_AvailableStatuses.Length; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, i_AvailableStatuses[i]);
            }

            Console.WriteLine("{0}) None", i_AvailableStatuses.Length + 1);

        }

        private void changeVehicleStatus() { }
        private void inflateWheelsToMax() { }
        private void refuelVehicle() { }
        private void chargeVehicle() { }
        private void displayVehicleInfo() { }
    }
}
