using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_RemainingBattery, float i_MaxBatteryLife)
        {
            m_EnergyLeft = i_RemainingBattery;
            m_MaxEnergyCapacity = i_MaxBatteryLife;
        }

        public override Dictionary<string, string> GetEnergyDetails()
        {
            Dictionary<string, string> energyDetails = new Dictionary<string, string>();

            energyDetails.Add("Current Energy", m_EnergyLeft.ToString());

            return energyDetails;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            AddEnergy(i_HoursToCharge);
        }
    }
}