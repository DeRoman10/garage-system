namespace Ex03.GarageLogic
{
    public class FuelTruck : Vehicle
    {
        private bool m_isCarryingFreezingCargo;
        private float m_CargoVolume;
        private const eFuelType m_FuelType = eFuelType.Soler;
        private const int k_NumberOfWheels = 14;
        private const float k_MaximumAirPressure = 28f;
        private const float k_MaximumFuelCapacity = 125;

        public FuelTruck(string i_ModelName, string i_LicenseNumber)
            : base(i_ModelName, i_LicenseNumber, new FuelSource(k_emptyEnergy, k_MaximumFuelCapacity, m_FuelType), k_NumberOfWheels, k_MaximumAirPressure)
        {
        }

        public bool IsCarryingFreezingCargo
        {
            get
            {
                return m_isCarryingFreezingCargo;
            }
            set
            {
                m_isCarryingFreezingCargo = value;
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

    }
}
