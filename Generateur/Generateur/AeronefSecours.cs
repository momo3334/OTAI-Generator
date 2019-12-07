using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class AeronefSecours : Aeronef
    {
        //Constructeur
        public AeronefSecours(String p_name, int p_speed, int p_maintenanceTime) : base(p_name, p_speed, p_maintenanceTime)
        {
        }
    }
}
