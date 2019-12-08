using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class AeronefPassager : AeronefTransport
    {
        //Données membres
        int m_capacity;

        //Accesseurs
        public int Capacity
        {
            get { return this.m_capacity; }
            set { this.m_capacity = value; }
        }

        //Constructeur
        public AeronefPassager(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, int p_capacity) : base(p_name, p_speed,  p_maintenanceTime,  p_loadingTime, p_unloadingTime)
        {
            this.m_capacity = p_capacity;
        }

        public override string ToString()
        {
            return $"{base.ToString()},{this.m_capacity},Passager";
        }
    }
}
