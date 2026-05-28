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

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Wrong fuel type");
            }
            AddEnergy(i_LitersToAdd);
        }
    }
}
