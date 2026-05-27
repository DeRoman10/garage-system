namespace Ex03
{
    public class Car : Vehicle
    {
        private eColor m_CarColor;
        private readonly eNumberOfDoors m_NumberOfDoors;
        private const int k_NumberOfWheels = 5;

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentage, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentage, k_NumberOfWheels)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }
    }
}
