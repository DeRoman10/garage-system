using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
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

        public override List<VehiclePropertyInfo> GetRequiredProperties()
        {
            List<VehiclePropertyInfo> motorcycleSpecificProperties = new List<VehiclePropertyInfo>();

            motorcycleSpecificProperties.Add(new VehiclePropertyInfo("LicenseType", "License Type", Enum.GetNames(typeof(eVehicleLicenseType))));

            motorcycleSpecificProperties.Add(new VehiclePropertyInfo("EngineVolume", "Engine Volume", new string[0]));

            return motorcycleSpecificProperties;
        }

        public override Dictionary<string, string> GetUniqueVehicleDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();

            details.Add("License Type", m_LicenseType.ToString());
            details.Add("Engine Volume", m_EngineVolume.ToString());

            return details;
        }

        public override void SetRequiredProperties(Dictionary<string, string> i_Properties)
        {
            m_LicenseType = (eVehicleLicenseType)Enum.Parse(typeof(eVehicleLicenseType), i_Properties["LicenseType"]);
            m_EngineVolume = int.Parse(i_Properties["EngineVolume"]);
        }

        public override string ToString()
        {
            return string.Format("Model: {0}, License: {1}, Energy: {2}%, License Type: {3}, Engine: {4}cc",
                ModelName, LicenseNumber, EnergyPercentage, m_LicenseType, m_EngineVolume);
        }
    }
}

