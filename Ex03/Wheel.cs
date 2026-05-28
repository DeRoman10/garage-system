namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturerName;
        private float m_currentAirPressure;
        private readonly float m_maximumAirPressure;

        public Wheel(string i_manufacturerName , float i_maximumAirPressure)
        {
            m_manufacturerName = i_manufacturerName;
            m_maximumAirPressure = i_maximumAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_currentAirPressure;
            }
        }

        public void AddAir(float i_AirToAdd)
        {
            if (m_currentAirPressure + i_AirToAdd > m_maximumAirPressure)
            {
                //throw new ValueRangeException();
            }
            else
            {
                m_currentAirPressure += i_AirToAdd;
            }
        }
    }
}
