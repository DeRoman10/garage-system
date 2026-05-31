namespace Ex03.GarageLogic
{
    public class VehiclePropertyInfo
    {
        private readonly string m_InternalName;
        private readonly string m_DisplayName;
        private readonly string[] m_ValidValues;

        public VehiclePropertyInfo(string i_Name, string i_DisplayName, string[] i_ValidValues)
        {
            m_InternalName = i_Name;
            m_DisplayName = i_DisplayName;
            m_ValidValues = i_ValidValues;
        }

        public string InternalName
        {
            get
            {
                return m_InternalName;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
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
