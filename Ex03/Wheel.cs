namespace Ex03
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
            m_currentAirPressure = 0;
        }
    }
}
