using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
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

        //Accesseurs
        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public String Position
        {
            get { return this.m_position; }
            set { this.m_position = value; }
        }

        public int MinPassenger
        {
            get { return this.m_minPassenger; }
            set { this.m_minPassenger = value; }
        }

        public int MaxPassenger
        {
            get { return this.m_maxPassenger; }
            set { this.m_maxPassenger = value; }
        }
        public int MinMerchandise
        {
            get { return this.m_minMerchandise; }
            set { this.m_minMerchandise = value; }
        }
        public int MaxMerchandise
        {
            get { return this.m_maxMerchandise; }
            set { this.m_maxMerchandise = value; }
        }
        public List<Aeronef> Aircrafts
        {
            get { return this.m_aircrafts; }
            set { this.m_aircrafts = value; }
        }

        //Constructeurs

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
    }
}
