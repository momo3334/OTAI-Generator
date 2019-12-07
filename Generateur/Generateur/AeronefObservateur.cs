using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class AeronefObservateur : Aeronef
    {
        //Constructeur
        public AeronefObservateur(String p_name, int p_speed, int p_maintenanceTime) : base(p_name, p_speed, p_maintenanceTime)
        {
        }
    }
}
