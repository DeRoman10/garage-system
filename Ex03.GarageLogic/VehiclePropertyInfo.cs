namespace Ex03.GarageLogic
{
    public class VehiclePropertyInfo
    {
        private readonly string m_Name;
        private readonly string[] m_ValidValues;

        public VehiclePropertyInfo(string i_Name, string[] i_ValidValues)
        {
            m_Name = i_Name;
            m_ValidValues = i_ValidValues;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public string[] ValidValues
        {
            get
            {
                return m_ValidValues;
            }
        }
    }
}
