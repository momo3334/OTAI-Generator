using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OTAI_Simulator
{
    [DataContractAttribute(Namespace = "")]
    class AeronefObservateur : Aeronef
    {
        //Constructeur
        public AeronefObservateur() { }

        public AeronefObservateur(String p_name, int p_speed, int p_maintenanceTime) : base(p_name, p_speed, p_maintenanceTime)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()},X,X,X,Observateur";
        }
    }
}
