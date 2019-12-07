﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class AeronefCiterne : Aeronef
    {
        //Données membres
        int m_loadingTime;
        int m_largingTime;

        //Accesseurs
        public int LoadingTime
        {
            get { return this.m_loadingTime; }
            set { this.m_loadingTime = value; }
        }

        public int LargingTime
        {
            get { return this.m_largingTime; }
            set { this.m_largingTime = value; }
        }

        //Constructeur
        public AeronefCiterne(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_largingTime) : base(p_name, p_speed, p_maintenanceTime)
        {
            this.m_loadingTime = p_loadingTime;
            this.m_largingTime = p_largingTime;
        }
    }
}