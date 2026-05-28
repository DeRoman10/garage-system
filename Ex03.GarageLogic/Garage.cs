using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageTask> m_Tasks = new Dictionary<string, GarageTask>();

        public Dictionary<string, string> AddVehicle(string i_LicenseNumber, string i_VehicleType, string i_OwnerName, string i_OwnerPhoneNumber)
        {

            if (m_Tasks.ContainsKey(i_LicenseNumber))
            {
                m_Tasks[i_LicenseNumber].VehicleStatus = eVehicleStatus.OnRepair;
                throw new ArgumentException("Car is already in garage.");
            }

            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, "");
            GarageTask newTask = new GarageTask(i_OwnerName, i_OwnerPhoneNumber, newVehicle);
            m_Tasks.Add(i_LicenseNumber, newTask);

            return newVehicle.GetRequiredPropertiesNames();
        }

        public Vehicle GetVehicle(String i_LicenseNumber)
        {
            validateVehicleInGarage(i_LicenseNumber);

            return m_Tasks[i_LicenseNumber].Vehicle;
        }

        public void SetVehicleProperties(string i_LicenseNumber, Dictionary<string, string> i_Properties)
        {
            validateVehicleInGarage(i_LicenseNumber);

            m_Tasks[i_LicenseNumber].Vehicle.SetRequiredProperties(i_Properties);
        }

        public void ChangeStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            validateVehicleInGarage(i_LicenseNumber);

            m_Tasks[i_LicenseNumber].VehicleStatus = i_NewStatus;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            validateVehicleInGarage(i_LicenseNumber);

            m_Tasks[i_LicenseNumber].Vehicle.InflateWheelsToMax();
        }

        public void Refuel(string i_LicenseNumber, eFuelType i_FuelType, float i_LitersToAdd)
        {
            validateVehicleInGarage(i_LicenseNumber);

            m_Tasks[i_LicenseNumber].Vehicle.Refuel(i_FuelType, i_LitersToAdd);
        }

        public void Charge(string i_LicenseNumber, float i_MinutesToCharge)
        {
            validateVehicleInGarage(i_LicenseNumber);

            float hoursToCharge = i_MinutesToCharge / 60f;

            m_Tasks[i_LicenseNumber].Vehicle.Charge(hoursToCharge);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_Tasks.ContainsKey(i_LicenseNumber);
        }

        private void validateVehicleInGarage(string i_LicenseNumber)
        {
            if (!m_Tasks.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in garage.");
            }
        }
    }
}
