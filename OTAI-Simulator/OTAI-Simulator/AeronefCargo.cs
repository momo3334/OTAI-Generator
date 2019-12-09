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
    class AeronefCargo : AeronefTransport
    {
        //Données membres
        float m_weightCapacity;

        //Accesseurs
        [DataMember()]
        public float WeightCapacity
        {
            get { return this.m_weightCapacity; }
            set { this.m_weightCapacity = value; }
        }

        //Constructeur
        public AeronefCargo(){}

        public AeronefCargo(String p_name, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_weightCapacity) : base(p_name, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime)
        {
            this.m_weightCapacity = p_weightCapacity;
        }

        public override string ToString()
        {
            return $"{base.ToString()},{this.m_weightCapacity},Cargo";
        }
    }
}
