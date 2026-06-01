using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        private const int k_NumberOfWheels = 5;
        private const float k_MaximumAirPressure = 31f;

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_EnergySource)
            : base(i_ModelName, i_LicenseNumber, i_EnergySource, k_NumberOfWheels, k_MaximumAirPressure)
        {
        }

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override List<VehiclePropertyInfo> GetRequiredProperties()
        {
            List<VehiclePropertyInfo> carSpecificProperties = new List<VehiclePropertyInfo>();

            carSpecificProperties.Add(new VehiclePropertyInfo("eColor", "Color", Enum.GetNames(typeof(eColor))));

            carSpecificProperties.Add(new VehiclePropertyInfo("eNumberOfDoors", "Number of Doors", Enum.GetNames(typeof(eNumberOfDoors))));

            return carSpecificProperties;
        }

        public override Dictionary<string, string> GetUniqueVehicleDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();

            details.Add("Color", m_CarColor.ToString());
            details.Add("Number of Doors", m_NumberOfDoors.ToString());

            return details;
        }

        public override void SetRequiredProperties(Dictionary<string, string> i_Properties)
        {
            m_CarColor = (eColor)Enum.Parse(typeof(eColor), i_Properties["eColor"]);
            m_NumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_Properties["eNumberOfDoors"]);
        }

        public override string ToString()
        {
            return string.Format("Model: {0}, License: {1}, Energy: {2}%, Color: {3}, Doors: {4}",
                ModelName, LicenseNumber, EnergyPercentage, m_CarColor, m_NumberOfDoors);
        }
    }

}
