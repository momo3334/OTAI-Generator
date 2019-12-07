using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public class Scenario
    {
        //Données membres
        List<Aeronef> m_aircrafts;
        List<Aeroport> m_airports;
        FabriqueAvion m_aircraftFactory;

        ControlleurGenerateur m_generatorController;

        //Accesseurs
        public List<Aeronef> Aircrafts
        {
            get { return this.m_aircrafts; }
            set { this.m_aircrafts = value; }
        }
        public List<Aeroport> Airports
        {
            get { return this.m_airports; }
            set { this.m_airports = value; }
        }

        //Constructeurs
        public Scenario()
        {
            this.m_generatorController = new ControlleurGenerateur(this);
            this.m_aircraftFactory = FabriqueAvion.getInstance();
            this.m_aircrafts = new List<Aeronef>();
            this.m_airports = new List<Aeroport>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VueGenerateur(this.m_generatorController));
        }

        //Méthodes
        public void addAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_capacity)
        {
            if (m_aircraftFactory != null)
            {
                Aeronef airCraft = m_aircraftFactory.createAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                m_aircrafts.Add(airCraft);
            }
        }

        public void addAirport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            Aeroport airportToAdd = new Aeroport(p_name, p_position, p_minPassenger, p_maxPassenger, p_minMerchandise, p_maxMerchandise);
            bool isExisting = false;

            foreach (var airport in this.m_airports)
            {
                if (airport.ToString() == airportToAdd.ToString())
                {
                    isExisting = true;
                }
            }

            if (!isExisting)
            {
                this.m_airports.Add(airportToAdd);
            }
        }
    }
}
