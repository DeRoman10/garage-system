namespace Ex03
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 3f;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName)
            : base(i_ModelName, i_LicenseID, new ElectricSource(k_emptyEnergy, k_MaxBatteryTime))
        {
        }


    }
}
