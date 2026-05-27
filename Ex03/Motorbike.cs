
namespace Ex03
{
    public class Motorbike : Vehicle
    {
        private eVehicleLicenseType m_LicenseType;
        private const int k_NumberOfWheels = 2;
        private readonly int m_EngineVolume;
        public Motorbike(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentage, eVehicleLicenseType i_LicenseType, int i_EngineVolume) 
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentage, k_NumberOfWheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }
    }
}
