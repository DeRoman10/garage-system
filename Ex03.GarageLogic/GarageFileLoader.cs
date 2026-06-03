using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.GarageLogic
{
    public class GarageFileLoader
    {
        private readonly Garage r_Garage;

        public GarageFileLoader(Garage i_Garage)
        {
            r_Garage = i_Garage;
        }

        public void LoadFromFile(string i_FilePath)
        {
            string[] lines = File.ReadAllLines(i_FilePath);

            foreach (string line in lines)
            {
                try
                {
                    loadVehicleFromLine(line);
                }
                catch
                {

                }
            }
        }

        private void loadVehicleFromLine(string i_Line)
        {
            string[] fields = i_Line.Split(',');

            string vehicleType = fields[0];
            string licensePlate = fields[1];
            string modelName = fields[2];
            float energyPercentage = float.Parse(fields[3]);
            string wheelManufacturer = fields[4];
            float wheelPressure = float.Parse(fields[5]);
            string ownerName = fields[6];
            string ownerPhone = fields[7];

            List<VehiclePropertyInfo> requiredProperties = r_Garage.AddVehicle(
                modelName, licensePlate, vehicleType, ownerName, ownerPhone);

            Dictionary<string, string> vehicleProperties = new Dictionary<string, string>();

            for (int i = 0; i < requiredProperties.Count; i++)
            {
                vehicleProperties.Add(requiredProperties[i].InternalName, fields[8 + i]);
            }

            try
            {
                r_Garage.SetVehicleProperties(licensePlate, vehicleProperties);
                r_Garage.SetWheelProperties(licensePlate, wheelManufacturer, wheelPressure);
                r_Garage.SetInitialEnergyByPercentage(licensePlate, energyPercentage);
            }
            catch
            {
                r_Garage.RemoveVehicle(licensePlate);
                throw;
            }
        }
    }
}
