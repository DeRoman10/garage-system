using System;
using System.Collections.Generic;
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

        public override Dictionary<string, string> GetEnergyDetails()
        {
            Dictionary<string, string> energyDetails = new Dictionary<string, string>();

            energyDetails.Add("Fuel type", m_FuelType.ToString());
            energyDetails.Add("Current fuel", m_EnergyLeft.ToString());

            return energyDetails;
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
