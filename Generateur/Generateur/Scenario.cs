using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;

namespace Generateur
{
    public delegate void onAirportChange();

    [DataContractAttribute(Namespace = "")]
    //[KnownType(typeof(List<Aeroport>))]
    public class Scenario
    {
        //Données membres
        byte[] m_mapImage;
        byte[] m_airportIcon;
        byte[] m_aircraftIcon;
        List<Aeroport> m_airports;
        FabriqueAvion m_aircraftFactory;
        ControlleurGenerateur m_generatorController;
        VueGenerateur m_vueGenerateur;

        //Evenement
        onAirportChange m_onAirportChange;


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
        public Scenario()
        {
            this.m_generatorController = new ControlleurGenerateur(this);
            this.m_aircraftFactory = FabriqueAvion.getInstance();
            this.m_airports = new List<Aeroport>();

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            this.m_vueGenerateur = new VueGenerateur(this.m_generatorController, this);
            Application.Run(m_vueGenerateur);
        }

        //Méthodes

        public void addViewEventHandler(MethodInvoker p_viewMethod, String p_type)
        {
            switch (p_type)
            {
                case "onAirportChange":
                    m_onAirportChange += new onAirportChange(p_viewMethod);
                    break;
                case "onAircraftChange":
                    m_airports[0].addViewEventHandler(p_viewMethod);
                    break;
                default:
                    break;
            }
        }

        public void removeViewEventHandler(MethodInvoker p_viewMethod, String p_type)
        {
            switch (p_type)
            {
                case "onAirportChange":
                    m_onAirportChange -= new onAirportChange(p_viewMethod);
                    break;
                case "onAircraftChange":
                    m_airports[0].removeViewEventHandler(p_viewMethod);
                    break;
                default:
                    break;
            }
        }

        //Notifier la vue selon le changement apporté
        public void notifyView(string p_type)
        {
            m_onAirportChange.Invoke();
        }


        public void addAircraft(String p_name, aircraftType p_type, int p_speed, int p_maintenanceTime, int p_loadingTime, int p_unloadingTime, float p_capacity, int indexOfAirport)
        {
            if (m_aircraftFactory != null)
            {
                Aeronef airCraft = m_aircraftFactory.createAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                m_airports[indexOfAirport].addAircraft(airCraft);
            }
            else
            {
                this.m_aircraftFactory = FabriqueAvion.getInstance();
                Aeronef airCraft = m_aircraftFactory.createAircraft(p_name, p_type, p_speed, p_maintenanceTime, p_loadingTime, p_unloadingTime, p_capacity);
                m_airports[indexOfAirport].addAircraft(airCraft);
            }
        }

        public void addAirport(String p_name, String p_position, int p_minPassenger, int p_maxPassenger, int p_minMerchandise, int p_maxMerchandise)
        {
            Aeroport airportToAdd = new Aeroport(p_name, p_position, p_minPassenger, p_maxPassenger, p_minMerchandise, p_maxMerchandise);

            if (this.m_airports.Count > 0)
            {
                bool exist = false;
                foreach (var airport in this.m_airports)
                {
                    //Si l'aeroport est déja présent dans la liste
                    if (airport.ToString() == airportToAdd.ToString())
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    this.m_airports.Add(airportToAdd);
                }
            }
            else
            {
                this.m_airports.Add(airportToAdd);
            }

            airportToAdd.addViewEventHandler(this.m_vueGenerateur.refreshAircraftList);

            //Notifier les abonnés
            this.notifyView("airportChange");
        }

        public List<String> getAircrafts(int indexOfAirport)
        {
            return this.m_airports[indexOfAirport].getAircrafts();
        }

        public void serializeScenario()
        {
            Debug.WriteLine("generation scenario initialise...");

            this.m_aircraftIcon = convertImageTobyteArray(getSelectedPath("cmbImageAirplane"));
            this.m_airportIcon = convertImageTobyteArray(getSelectedPath("cmbImageAirport"));
            this.m_mapImage = convertImageTobyteArray(getSelectedPath("cmbImageMap"));


            DataContractSerializer serializer = new DataContractSerializer(typeof(Scenario));

            //Permet de specifier que q'une indentation est désiré sur le fichier xml de sortie.
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            string text;
            using (var ms = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings { Indent = true }))
                {
                    serializer.WriteObject(xmlWriter, this);
                }
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(ms))
                {
                    text = reader.ReadToEnd();
                }

                File.WriteAllText(@"..\..\data\Scenario.xml", text);
            }
        }

        public byte[] convertImageTobyteArray(String path)
        {
            Image image = Image.FromFile(path);
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public String getSelectedPath(String cmbTarget)
        {
            String imagePath = "";
            switch (cmbTarget)
            {
                case "cmbImageAirplane":
                    imagePath = $"..\\..\\data\\icons\\airplanes\\{m_vueGenerateur.getImageAirplane()}";
                    break;
                case "cmbImageAirport":
                    imagePath = $"..\\..\\data\\icons\\airports\\{m_vueGenerateur.getImageAirport()}";
                    break;
                case "cmbImageMap":
                    imagePath = $"..\\..\\data\\icons\\maps\\{ m_vueGenerateur.getImageMap()}";
                    break;
                default:
                    break;
            }

            return imagePath;
        }
    }
}
