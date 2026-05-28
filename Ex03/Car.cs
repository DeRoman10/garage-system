namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_CarColor;
        private readonly eNumberOfDoors m_NumberOfDoors;
        private const int k_NumberOfWheels = 5;
        private const float k_MaximumAirPressure = 31f;

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_EnergySource)
            : base(i_ModelName, i_LicenseNumber, i_EnergySource, k_NumberOfWheels, k_MaximumAirPressure)
        {
        }

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }
    }

}
