using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class ControlleurAeroport
    {
        Scenario m_scenario;

        public ControlleurAeroport(Scenario p_scenario)
        {
            if (this.m_scenario == null)
            {
                this.m_scenario = p_scenario;
            }
        }

        public List<Aeroport> getAirports()
        {
            return m_scenario.Airports;
        }

        public void addAirport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            this.m_scenario.addAirport(p_name, p_position, p_minPassenger, p_maxPassenger, p_minMerchandise, p_maxMerchandise);
        }
    }
}
