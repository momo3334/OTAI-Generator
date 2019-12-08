using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    abstract class AeronefTransport : Aeronef
    {
        //Données membres
        int m_loadingTime;
        int m_unloadingTime;

        //Accesseurs
        public int LoadingTime
        {
            get { return this.m_loadingTime; }
            set { this.m_loadingTime = value; }
        }

        public int UnloadingTime
        {
            get { return this.m_unloadingTime; }
            set { this.m_unloadingTime = value; }
        }

        //Constructeurs

        public AeronefTransport(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime) : base(p_name, p_speed, p_maintenanceTime)
        {
            this.m_loadingTime = p_loadingTime;
            this.m_unloadingTime = p_unloadingTime;
        }

        public override string ToString()
        {
            return $"{base.ToString()},{this.m_loadingTime},{this.m_unloadingTime}";
        }
    }
}
