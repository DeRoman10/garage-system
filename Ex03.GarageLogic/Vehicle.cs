using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        protected const float k_EmptyEnergy = 0f;
        protected EnergySource m_EnergySource;
        protected Wheel[] m_Wheels;

        public abstract List<VehiclePropertyInfo> GetRequiredProperties();
        public abstract void SetRequiredProperties(Dictionary<string, string> i_Properties);

        public Vehicle(string i_ModelName, string i_LicenseNumber, EnergySource i_EnergySource, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergySource = i_EnergySource;
            m_Wheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel("", i_MaxAirPressure);
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return (m_EnergySource.EnergyLeft / m_EnergySource.MaxEnergyCapacity) * 100f;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public void SetInitialEnergyByPercentage(float i_EnergyPercentage)
        {
            float convertedAmount = (i_EnergyPercentage / 100f) * m_EnergySource.MaxEnergyCapacity;

            m_EnergySource.AddEnergy(convertedAmount);
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
        {
            FuelSource fuelSource = m_EnergySource as FuelSource;

            if (fuelSource == null)
            {
                throw new ArgumentException("Vehicle is not fuel based.");
            }

            fuelSource.Refuel(i_FuelType, i_LitersToAdd);
        }

        public void Charge(float i_HoursToCharge)
        {
            ElectricSource electricSource = m_EnergySource as ElectricSource;

            if (electricSource == null)
            {
                throw new ArgumentException("Vehicle is not electric.");
            }

            electricSource.ChargeBattery(i_HoursToCharge);
        }
    }
}
