using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class AddVehicleUI
    {
        private readonly Garage r_Garage;

        public AddVehicleUI(Garage i_SharedGarage)
        {
            r_Garage = i_SharedGarage;
        }

        public void AddVehicle()
        {
            string modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber, wheelManufacturerName;
            float airPressure = 0, energyPercentage = 0;

            Console.WriteLine("Please enter vehicle's license plate number");
            licenseNumber = Console.ReadLine();
            
            if (r_Garage.IsVehicleInGarage(licenseNumber))
            {
                r_Garage.ChangeStatus(licenseNumber, eVehicleStatus.OnRepair);
                
                return;
            }

            Console.WriteLine("Please enter vehicle model's name");
            modelName = Console.ReadLine();

            Console.WriteLine("Please enter the corresponding number of the vehicle's type:");
            vehicleType = vehicleTypeInputHandler();

            Console.WriteLine("Please enter wheel's manufacturer name:");
            wheelManufacturerName = Console.ReadLine();

            Console.WriteLine("Please enter wheel's current air pressure:");
            airPressure = float.Parse(Console.ReadLine());

            Console.WriteLine("Please enter vehicle's current energy level %:");
            energyPercentage = float.Parse(Console.ReadLine());

            Console.WriteLine("Please enter vehicle owner's full name");
            ownerName = Console.ReadLine();

            Console.WriteLine("Please enter vehicle owner's phone number");
            ownerPhoneNumber = Console.ReadLine();

            List<VehiclePropertyInfo> typeSpecificInfo = r_Garage.AddVehicle(modelName, licenseNumber, vehicleType, ownerName, ownerPhoneNumber);

            Dictionary<string, string> properties = setSpecificPropertiesForAddedVehicle(typeSpecificInfo);

            try
            {
                r_Garage.SetVehicleProperties(licenseNumber, properties);
                r_Garage.SetWheelProperties(licenseNumber, wheelManufacturerName, airPressure);
                r_Garage.SetInitialEnergyByPercentage(licenseNumber, energyPercentage);
            }
            catch
            {
                r_Garage.RemoveVehicle(licenseNumber);
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
            printSupportedVehicleTypes();

            string actualChosenType = string.Empty;

            int userChoice = ConsoleUtils.chooseOption(VehicleCreator.SupportedTypes);

            actualChosenType = VehicleCreator.SupportedTypes[userChoice];

            return actualChosenType;
        }

        private void printSupportedVehicleTypes()
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
    }
}
