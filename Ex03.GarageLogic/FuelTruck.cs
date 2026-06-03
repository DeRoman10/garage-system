using System.Collections.Generic;

namespace Ex03.GarageLogic

{
    public class FuelTruck : Vehicle
    {
        private bool m_IsCarryingFreezingCargo;
        private float m_CargoVolume;
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const int k_NumberOfWheels = 14;
        private const float k_MaximumAirPressure = 28f;
        private const float k_MaximumFuelCapacity = 125;

        public FuelTruck(string i_LicenseNumber, string i_ModelName)
            : base(i_ModelName, i_LicenseNumber, new FuelSource(k_EmptyEnergy, k_MaximumFuelCapacity, k_FuelType), k_NumberOfWheels, k_MaximumAirPressure)
        {
        }

        public bool IsCarryingFreezingCargo
        {
            get
            {
                return m_IsCarryingFreezingCargo;
            }
            set
            {
                m_IsCarryingFreezingCargo = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }

        public override List<VehiclePropertyInfo> GetRequiredProperties()
        {
            List<VehiclePropertyInfo> truckSpecificProperties = new List<VehiclePropertyInfo>();
            string[] carryingFreezingCargoOptions = { "true", "false" };

            truckSpecificProperties.Add(new VehiclePropertyInfo("IsCarryingFreezingCargo", "Is Carrying Freezing Cargo?", carryingFreezingCargoOptions));

            truckSpecificProperties.Add(new VehiclePropertyInfo("CargoVolume", "Cargo Volume", new string[0]));

            return truckSpecificProperties;
        }

        public override Dictionary<string, string> GetUniqueVehicleDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();

            details.Add("Is Carrying Freezing Cargo", IsCarryingFreezingCargo ? "Yes" : "No");
            details.Add("Cargo Volume", m_CargoVolume.ToString());

            return details;
        }

        public override void SetRequiredProperties(Dictionary<string, string> i_Properties)
        {
            m_IsCarryingFreezingCargo = bool.Parse(i_Properties["IsCarryingFreezingCargo"]);
            m_CargoVolume = float.Parse(i_Properties["CargoVolume"]);
        }

        public override string ToString()
        {
            return string.Format("Model: {0}, License: {1}, Energy: {2}%, Freezing cargo: {3}, Cargo volume: {4}",
                ModelName, LicenseNumber, EnergyPercentage, m_IsCarryingFreezingCargo, m_CargoVolume);
        }
    }
}
