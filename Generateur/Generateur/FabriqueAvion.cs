using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class FabriqueAvion
    {
        //Données membres
        static FabriqueAvion m_fabriqueAvion = null;


        //Constructeurs
        private FabriqueAvion()
        {

        }

        //Méthodes
        public static FabriqueAvion getInstance()
        {
            if (m_fabriqueAvion == null)
            {
                m_fabriqueAvion = new FabriqueAvion();
            }
            return m_fabriqueAvion;
        }

        public Aeronef createAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime = 0, int p_unloadingTime = 0, float p_capacity = 0)
        {
            switch (p_type)
            {
                case aircraftType.aeronefPassager:
                    return createPassenger(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, Convert.ToInt32(p_capacity));
                    break;
                case aircraftType.aeronefCargo:
                    return createCargo(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                    break;
                case aircraftType.aeronefSecours:
                    return createSecours(p_name, p_speed, p_maintenanceTime);
                    break;
                case aircraftType.aeronefCiterne:
                    return createCiterne(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime);
                    break;
                case aircraftType.aeronefObservateur:
                    return createObservateur(p_name, p_speed, p_maintenanceTime);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public Aeronef createPassenger(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, int p_capacity)
        {
            return new AeronefPassager(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
        }

        public Aeronef createCargo(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_weightCapacity)
        {
            return new AeronefCargo(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_weightCapacity);
        }

        public Aeronef createSecours(String p_name, int p_speed, int p_maintenanceTime)
        {
            return new AeronefSecours(p_name, p_speed, p_maintenanceTime);
        }

        public Aeronef createCiterne(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_largingTime)
        {
            return new AeronefCiterne(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_largingTime);
        }

        public Aeronef createObservateur(String p_name, int p_speed, int p_maintenanceTime)
        {
            return new AeronefObservateur(p_name, p_speed, p_maintenanceTime);
        }
    }
}
