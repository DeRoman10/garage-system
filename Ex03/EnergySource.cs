namespace Ex03
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

        virtual protected void AddEnergy(float i_EnergyToAdd)
        {
            if (m_EnergyLeft + i_EnergyToAdd > m_MaxEnergyCapacity)
            {
                //throw new ValueRangeException(); 
            }
            m_EnergyLeft += i_EnergyToAdd;
        }
    }
}

