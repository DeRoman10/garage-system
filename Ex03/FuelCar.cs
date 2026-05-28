namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private const float k_MaxFuel = 51f;
        private const eFuelType k_FuelType = eFuelType.Octan95;

        public FuelCar(string i_LicenseID, string i_ModelName)
            : base(i_ModelName, i_LicenseID, new FuelSource(k_emptyEnergy, k_MaxFuel, k_FuelType))
        {
        }
    }
}
