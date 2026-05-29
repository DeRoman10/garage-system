using System;
namespace Ex03.GarageLogic
{
    public class FuelSource : EnergySource
    {
        private eFuelType m_FuelType;

        public FuelSource(float i_RemainingFuel, float i_MaxFuelCapacity, eFuelType i_FuelType)
        {
            m_EnergyLeft = i_RemainingFuel;
            m_MaxEnergyCapacity = i_MaxFuelCapacity;
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            { 
                return m_FuelType; 
            }
        }

        public override string GetEnergyDetails()
        {
            return string.Format(
                "Fuel type: {0}, Current fuel: {1}, Max fuel: {2}", m_FuelType, m_EnergyLeft, m_MaxEnergyCapacity);
        }

        public void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Incorrect fuel type.");
            }

            AddEnergy(i_LitersToAdd);
        }
    }
}
