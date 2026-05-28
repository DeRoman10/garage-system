namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_modelName;
        private string m_licenseNumber;
        protected const float k_emptyEnergy = 0f;
        protected EnergySource m_EnergySource;
        protected Wheel[] m_Wheels;
        protected float m_MaxAirPressure;


        public Vehicle(string i_ModelName, string i_LicenseNumber, EnergySource i_EnergySource, int i_NumberOfWheels , float i_MaxAirPressure)
        {
            m_modelName = i_ModelName;
            m_licenseNumber = i_LicenseNumber;
            m_EnergySource = i_EnergySource;
            m_Wheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel("", i_MaxAirPressure);
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return (m_EnergySource.EnergyLeft / m_EnergySource.MaxEnergyCapacity) * 100f;
            }
        }

        public void addAirToWheels(float i_AirToAdd)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.AddAir(i_AirToAdd);
            }
        }
    }
}
