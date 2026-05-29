using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eVehicleLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_NumberOfWheels = 2;
        private const float k_MaximumAirPressure = 30f;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, EnergySource i_Engine)
            : base(i_ModelName, i_LicenseNumber, i_Engine, k_NumberOfWheels, k_MaximumAirPressure)
        {
        }

        public eVehicleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }

        public override Dictionary<string, string> GetRequiredPropertiesNames()
        {
            Dictionary<string, string> motorcycleSpecificProperties = new Dictionary<string, string>();

            motorcycleSpecificProperties.Add("License type (A/A2/B1/AB)", "");
            motorcycleSpecificProperties.Add("Engine volume (cc)", "");

            return motorcycleSpecificProperties;
        }

        public override void SetRequiredProperties(Dictionary<string, string> i_Properties)
        {
            m_LicenseType = (eVehicleLicenseType)Enum.Parse(typeof(eVehicleLicenseType), i_Properties["License type (A/A2/B1/AB)"]);
            m_EngineVolume = int.Parse(i_Properties["Engine volume (cc)"]);
        }

        public override string ToString()
        {
            return string.Format("Model: {0}, License: {1}, Energy: {2}%, License Type: {3}, Engine: {4}cc",
                ModelName, LicenseNumber, EnergyPercentage, m_LicenseType, m_EngineVolume);
        }
    }
}

