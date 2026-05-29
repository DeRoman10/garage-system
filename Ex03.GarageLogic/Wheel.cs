namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaximumAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaximumAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaximumAirPressure = i_MaximumAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public void AddAir(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaximumAirPressure)
            {
                throw new ValueRangeException(0, m_MaximumAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = m_MaximumAirPressure;
        }
    }
}
