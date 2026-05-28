namespace Ex03.GarageLogic
{
    public class ElectricSource : EnergySource
    {
        public ElectricSource(float i_RemainingBattery, float i_MaxBatteryLife)
        {
            m_EnergyLeft = i_RemainingBattery;
            m_MaxEnergyCapacity = i_MaxBatteryLife;
        }

        public void ChargeBattery(float i_HoursToAdd)
        { 
            AddEnergy(i_HoursToAdd);
        }
    }
}