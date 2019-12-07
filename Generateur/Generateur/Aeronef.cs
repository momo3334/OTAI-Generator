using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    public abstract class Aeronef
    {
        //Données membres
        String m_name;
        String m_destination;
        int m_speed;
        int m_maintenanceTime;
        public enum aircraftType { aeronefPassager, aeronefCargo, aeronefSecours, aeronefCiterne, aeronefObservateur }

        //Accesseurs
        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }
        public String Destination
        {
            get { return this.m_destination; }
            set { this.m_destination = value; }
        }

        public int Speed
        {
            get { return this.m_speed; }
            set { this.m_speed = value; }
        }

        public int Maintenance
        {
            get { return this.m_maintenanceTime; }
            set { this.m_maintenanceTime = value; }
        }

        //Constructeurs
        public Aeronef(String p_name, int p_speed, int p_maintenanceTime)
        {
            this.m_name = p_name;
            this.m_speed = p_speed;
            this.m_maintenanceTime = p_maintenanceTime;
        }
    }
}
