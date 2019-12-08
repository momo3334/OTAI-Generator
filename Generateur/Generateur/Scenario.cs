using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public delegate void onAirportChange();
    public delegate void onAircraftChange();

    public class Scenario
    {
        //Données membres
        List<Aeronef> m_aircrafts;
        List<Aeroport> m_airports;
        FabriqueAvion m_aircraftFactory;

        ControlleurGenerateur m_generatorController;
        VueGenerateur m_vueGenerateur;

        //Evenement
        onAirportChange m_onAirportChange;
        onAircraftChange m_onAircraftChange;


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
            this.m_vueGenerateur = new VueGenerateur(this.m_generatorController, this);
            Application.Run(m_vueGenerateur);
        }

        //Méthodes

        public void addViewEventHandler(MethodInvoker p_viewMethod, String p_type)
        {
            switch (p_type)
            {
                case "onAirportChange":
                    m_onAirportChange += new onAirportChange(p_viewMethod);
                    break;
                case "onAircraftChange":
                    m_onAircraftChange += new onAircraftChange(p_viewMethod);
                    break;
                default:
                    break;
            }
        }

        public void removeViewEventHandler(MethodInvoker p_viewMethod, String p_type)
        {
            switch (p_type)
            {
                case "onAirportChange":
                    m_onAirportChange -= new onAirportChange(p_viewMethod);
                    break;
                case "onAircraftChange":
                    m_onAircraftChange -= new onAircraftChange(p_viewMethod);
                    break;
                default:
                    break;
            }
        }

        //Notifier la vue selon le changement apporté
        public void notifyView(string p_type)
        {
            switch (p_type)
            {
                case "airportChange":
                    if (this.m_onAirportChange != null)
                    {
                        m_onAirportChange.Invoke();
                    }
                    break;
                case "aircraftChange":
                    if (this.m_onAircraftChange != null)
                    {
                        m_onAircraftChange.Invoke();
                    }
                    break;
                default:
                    break;
            }
        }


        public void addAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_capacity)
        {
            if (m_aircraftFactory != null)
            {
                Aeronef airCraft = m_aircraftFactory.createAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                m_aircrafts.Add(airCraft);
            }
            else
            {
                this.m_aircraftFactory = FabriqueAvion.getInstance();
                Aeronef airCraft = m_aircraftFactory.createAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                m_aircrafts.Add(airCraft);
            }
            //Notifier les abonnés
            this.notifyView("aircraftChange");
        }

        public void addAirport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            Aeroport airportToAdd = new Aeroport(p_name, p_position, p_minPassenger, p_maxPassenger, p_minMerchandise, p_maxMerchandise);

            if (this.m_airports.Count > 0)
            {
                foreach (var airport in this.m_airports)
                {
                    bool exist = false;
                    
                    //Si l'aeroport est déja présent dans la liste
                    if (airport.ToString() != airportToAdd.ToString())
                    {
                        exist = true;
                    }

                    if (exist)
                    {
                        this.m_airports.Add(airportToAdd);
                    }
                }
            }
            else
            {
                this.m_airports.Add(airportToAdd);
            }

            //Notifier les abonnés
            this.notifyView("airportChange");
        }
    }
}
