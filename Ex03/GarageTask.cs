namespace Ex03.GarageLogic
{
    public class GarageTask
    {
        private string m_ownerName;
        private string m_ownerPhone;
        private eVehicleStatus m_vehicleStatus;
        private Vehicle m_vehicle;

        public GarageTask(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_ownerName = i_OwnerName;
            m_ownerPhone = i_OwnerPhone;
            m_vehicle = i_Vehicle;
            m_vehicleStatus = eVehicleStatus.onRepair;
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_vehicleStatus;
            }
            set
            {
                m_vehicleStatus = value;
            }
        }
    }
}
