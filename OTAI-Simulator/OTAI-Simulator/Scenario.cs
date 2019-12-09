using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTAI_Simulator
{
    [DataContractAttribute(Namespace = "")]
    class Scenario
    {
        //Données membres
        byte[] m_mapImage;
        byte[] m_airportIcon;
        byte[] m_aircraftIcon;
        List<Aeroport> m_airports;
        FabriqueAvion m_aircraftFactory;
        //ControlleurGenerateur m_generatorController;
        //VueGenerateur m_vueGenerateur;

        //Evenement


        //Accesseurs
        [DataMember()]
        public List<Aeroport> Airports
        {
            get { return this.m_airports; }
            set { this.m_airports = value; }
        }

        [DataMember()]
        public byte[] MapImage
        {
            get => m_mapImage;
            set => m_mapImage = value;
        }

        [DataMember()]
        public byte[] AirportIcon
        {
            get => m_airportIcon;
            set => m_airportIcon = value;
        }

        [DataMember()]
        public byte[] AircraftIcon
        {
            get => m_aircraftIcon;
            set => m_aircraftIcon = value;
        }

        //Constructeurs

        //public Scenario() { }

        public Scenario()
        {
            //this.m_generatorController = new ControlleurGenerateur(this);
            this.m_aircraftFactory = FabriqueAvion.getInstance();
            this.m_airports = new List<Aeroport>();
        }

        public void startScenario()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //this.m_vueGenerateur = new VueGenerateur(this.m_generatorController, this);
            Application.Run(new Form1());
        }
    }
}
