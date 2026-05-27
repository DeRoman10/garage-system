namespace Ex03
{
    public abstract class Vehicle
    {
        private string m_modelName;
        private string m_licenseNumber;
        private float m_EnergyPercentage;
        protected Wheel[] m_Wheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentage , int i_NumberOfWheels)
        {
            m_modelName = i_ModelName;
            m_licenseNumber = i_LicenseNumber;
            m_EnergyPercentage = i_EnergyPercentage;
            m_Wheels = new Wheel[i_NumberOfWheels];
        }
    }
}
