using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageTask> m_Tasks = new Dictionary<string, GarageTask>();

        public Dictionary<string, string> AddVehicle(string i_ModelName, string i_LicenseNumber, string i_VehicleType, string i_OwnerName, string i_OwnerPhoneNumber)
        {

            if (m_Tasks.ContainsKey(i_LicenseNumber))
            {
                m_Tasks[i_LicenseNumber].VehicleStatus = eVehicleStatus.OnRepair;
                throw new ArgumentException("Car is already in garage.");
            }

            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_ModelName);
            GarageTask newTask = new GarageTask(i_OwnerName, i_OwnerPhoneNumber, newVehicle);
            m_Tasks.Add(i_LicenseNumber, newTask);

            return newVehicle.GetRequiredPropertiesNames();
        }

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            validateVehicleInGarage(i_LicenseNumber);

            return m_Tasks[i_LicenseNumber].Vehicle;
        }

        public GarageTask GetTask(string i_LicenseNumber)
        {
            validateVehicleInGarage(i_LicenseNumber);

            return m_Tasks[i_LicenseNumber];
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

        public void SetWheelProperties(string i_LicenseNumber, string i_ManufacturerName, float i_AirPressure)
        {
            //I thought of adding validity check here but not sure how

            foreach (Wheel wheel in m_Tasks[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrentAirPressure = i_AirPressure;
            }
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

        public void SetInitialEnergyByPercentage(string i_LicenseNumber, float i_EnergyPercentage)
        {
            if (i_EnergyPercentage < 0 || i_EnergyPercentage > 100)
            {
                throw new ArgumentException("Please enter values between 0 to 100.");
            }

            m_Tasks[i_LicenseNumber].Vehicle.SetInitialEnergyByPercentage(i_EnergyPercentage);
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
