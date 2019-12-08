using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    public class ControlleurGenerateur
    {
        ControlleurAeronef m_controlleurAeronef;
        ControlleurAeroport m_controlleurAeroport;
        Scenario m_scenario;

        public ControlleurGenerateur(Scenario p_scenario)
        {
            this.m_controlleurAeronef = new ControlleurAeronef(p_scenario);
            this.m_controlleurAeroport = new ControlleurAeroport(p_scenario);
        }

        public void addAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_capacity)
        {
            this.m_controlleurAeronef.addAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
        }

        public List<Aeroport> getAirports()
        {
            return m_controlleurAeroport.getAirports();
        }

        public List<Aeronef> getAircraft()
        {
            return m_controlleurAeronef.getAircraft();
        }

        public void addAirport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            m_controlleurAeroport.addAirport(p_name, p_position, p_minPassenger, p_maxPassenger, p_minMerchandise, p_maxMerchandise);
        }
    }
}
