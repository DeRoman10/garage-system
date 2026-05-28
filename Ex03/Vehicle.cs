using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        protected const float k_EmptyEnergy = 0f;
        protected EnergySource m_EnergySource;
        protected Wheel[] m_Wheels;

        public abstract Dictionary<string, string> GetRequiredPropertiesNames();
        public abstract void SetRequiredProperties(Dictionary<string, string> i_Properties);

        public Vehicle(string i_ModelName, string i_LicenseNumber, EnergySource i_EnergySource, int i_NumberOfWheels , float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergySource = i_EnergySource;
            m_Wheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel("", i_MaxAirPressure);
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return (m_EnergySource.EnergyLeft / m_EnergySource.MaxEnergyCapacity) * 100f;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }
    }
}
