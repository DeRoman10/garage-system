namespace Ex03.GarageLogic
{
    public class GarageTask
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_Vehicle;
        private eVehicleStatus m_VehicleStatus;
        
        public GarageTask(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhone;
            r_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.OnRepair;
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }
    }
}
