using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class ControlleurAeronef
    {
        Scenario m_scenario;

        public ControlleurAeronef(Scenario p_scenario)
        {
            if (this.m_scenario == null)
            {
                this.m_scenario = p_scenario;
            }
        }

        public void addAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_capacity)
        {
            m_scenario.addAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
        }
    }
}
