namespace Ex03
{
    public class Truck : Vehicle
    {
        private bool m_isCarryingFreezingCargo;
        private float m_CargoVolume;
        private const eFuelType m_FuelType = eFuelType.Soler;
        private const int k_NumberOfWheels = 14;
        private float m_CurrentFuel;
        private const float k_MaximumFuelCapacity = 125;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentage, bool i_isCarryingFreezingCargo, float i_CargoVolume, float i_CurrentFuel)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentage, k_NumberOfWheels)
        {
            m_isCarryingFreezingCargo = i_isCarryingFreezingCargo;
            m_CargoVolume = i_CargoVolume;
            m_CurrentFuel = i_CurrentFuel;

        }

    }
}
