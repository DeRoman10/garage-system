
namespace Ex03
{
    public class Motorcycle : Vehicle
    {
        private eVehicleLicenseType m_LicenseType;
        private const int k_NumberOfWheels = 2;
        private const float k_MaximumAirPressure = 30f;
        private readonly int m_EngineVolume;

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
        }
    }
}
