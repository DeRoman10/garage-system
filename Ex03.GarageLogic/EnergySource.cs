namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_EnergyLeft;
        protected float m_MaxEnergyCapacity;

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
        }
        public float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
        }

        public abstract string GetEnergyDetails();

        protected void AddEnergy(float i_EnergyToAdd)
        {
            float maxEnergyToAdd = m_MaxEnergyCapacity - m_EnergyLeft;

            if (i_EnergyToAdd < 0 || i_EnergyToAdd > maxEnergyToAdd)
            {
                throw new ValueRangeException(0, maxEnergyToAdd);
            }

            m_EnergyLeft += i_EnergyToAdd;
        }
    }
}

