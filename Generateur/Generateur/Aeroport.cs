using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public delegate void onAircraftChange();

    [DataContractAttribute( Namespace = "" )]
    //[KnownType(typeof(List<Aeronef>))]
    public class Aeroport
    {
        //Données membres
        String m_name;
        String m_position;
        int m_minPassenger;
        int m_maxPassenger;
        int m_minMerchandise;
        int m_maxMerchandise;
        List<Aeronef> m_aircrafts;
        onAircraftChange m_onAircraftChange;

        //Accesseurs
        [DataMember()]
        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        [DataMember()]
        public String Position
        {
            get { return this.m_position; }
            set { this.m_position = value; }
        }

        [DataMember()]
        public int MinPassenger
        {
            get { return this.m_minPassenger; }
            set { this.m_minPassenger = value; }
        }

        [DataMember()]
        public int MaxPassenger
        {
            get { return this.m_maxPassenger; }
            set { this.m_maxPassenger = value; }
        }

        [DataMember()]
        public int MinMerchandise
        {
            get { return this.m_minMerchandise; }
            set { this.m_minMerchandise = value; }
        }

        [DataMember()]
        public int MaxMerchandise
        {
            get { return this.m_maxMerchandise; }
            set { this.m_maxMerchandise = value; }
        }

        [DataMember()]
        public List<Aeronef> Aircrafts
        {
            get { return this.m_aircrafts; }
            set { this.m_aircrafts = value; }
        }

        //Constructeurs
        public Aeroport() { }

        public Aeroport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            this.m_name = p_name;
            this.m_position = p_position;
            this.m_minPassenger = p_minPassenger;
            this.m_maxPassenger = p_maxPassenger;
            this.m_minMerchandise = p_minMerchandise;
            this.m_maxMerchandise = p_maxMerchandise;
            this.m_aircrafts = new List<Aeronef>();
        }

        //Méthodes
        public String ToString()
        {
            String returnString;

            returnString = "" + this.m_name + this.m_position + this.m_minPassenger + this.m_maxPassenger + this.m_minMerchandise + this.m_maxMerchandise + "";

            return returnString;
        }

        public void addViewEventHandler(MethodInvoker p_viewMethod)
        {
            m_onAircraftChange += new onAircraftChange(p_viewMethod);
        }

        public void removeViewEventHandler(MethodInvoker p_viewMethod)
        {
            m_onAircraftChange -= new onAircraftChange(p_viewMethod);
        }
        //Notifier la vue selon le changement apporté
        public void notifyView()
        {
            m_onAircraftChange.Invoke();
        }

        public void addAircraft(Aeronef aircraftToAdd)
        {
            if (this.m_aircrafts.Count > 0)
            {
                bool exist = false;
                foreach (var airport in this.m_aircrafts)
                {


                    //Si l'aeronef est déja présent dans la liste
                    if (airport.ToString() == aircraftToAdd.ToString())
                    {
                        exist = true;
                    }

                }

                if (!exist)
                {
                    this.m_aircrafts.Add(aircraftToAdd);
                }
            }
            else
            {
                this.m_aircrafts.Add(aircraftToAdd);
            }

            //Notifier les abonnés
            this.notifyView();
        }

        public List<String> getAircrafts()
        {
            List<String> returnedAircrafts = new List<String>();

            foreach (Aeronef aircraft in this.m_aircrafts)
            {
                returnedAircrafts.Add(aircraft.ToString());
            }

            return returnedAircrafts;
        }
    }
}
