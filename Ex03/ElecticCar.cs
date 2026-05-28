namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxBattery = 4.6f;

        public ElectricCar(string i_LicenseID, string i_ModelName)
            : base(i_ModelName, i_LicenseID, new ElectricSource(k_emptyEnergy, k_MaxBattery))
        {
        }
    }
}
