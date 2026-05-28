namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_RemainingBattery, float i_MaxBatteryLife)
        {
            m_EnergyLeft = i_RemainingBattery;
            m_MaxEnergyCapacity = i_MaxBatteryLife;
        }

        public override string GetEnergyDetails()
        {
            return string.Format(
                "Battery left: {0} hours, Max battery: {1} hours", m_EnergyLeft, m_MaxEnergyCapacity);
        }

        public void ChargeBattery(float i_HoursToCharge)
        { 
            AddEnergy(i_HoursToCharge);
        }
    }
}