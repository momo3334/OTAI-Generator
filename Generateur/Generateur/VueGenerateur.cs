using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public interface IVueGenerateur
    {

    }


    public partial class VueGenerateur : Form
    {
        ControlleurGenerateur m_controller;
        Scenario m_scenario;



        public VueGenerateur(ControlleurGenerateur p_controller, Scenario p_scenario)
        {
            InitializeComponent();
            this.m_controller = p_controller;
            this.m_scenario = p_scenario;
            m_scenario.addViewEventHandler(this.refreshAirportList, "onAirportChange");

            lstAirport.View = View.Details;
            lstAirport.FullRowSelect = true;
            lstAirport.Columns.Add("Nom", 380);
            lstAirport.Columns.Add("Position", 165);
            lstAirport.Columns.Add("PassagerMin", -2);
            lstAirport.Columns.Add("PassagerMax", -2);
            lstAirport.Columns.Add("MarchandiseMin", -2);
            lstAirport.Columns.Add("MarchandiseMax", -2);

            lstAircraft.View = View.Details;
            lstAircraft.FullRowSelect = true;
            lstAircraft.Columns.Add("Nom", 320);
            lstAircraft.Columns.Add("Type", 130);
            lstAircraft.Columns.Add("Capacité", -2);
            lstAircraft.Columns.Add("Vitesse", -2);
            lstAircraft.Columns.Add("Temps embarquement", -2);
            lstAircraft.Columns.Add("Temps débarquement", -2);
            lstAircraft.Columns.Add("Temps entretient", -2);

            addAircraftType();
            addAvailableImages();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            Map map = new Map(this);
            map.Show();
        }

        private void BtnAddAirport_Click(object sender, EventArgs e)
        {
            String name;
            String position;
            int minPassenger;
            int maxPassenger;
            int minMerchandise;
            int maxMerchandise;

            name = this.txtAirportName.Text;
            position = this.txtAirportPosition.Text;
            minPassenger = Convert.ToInt32(this.txtAirportMinPass.Text);
            maxPassenger = Convert.ToInt32(this.txtAirportMaxPass.Text);
            minMerchandise = Convert.ToInt32(this.txtAirportMinMerch.Text);
            maxMerchandise = Convert.ToInt32(this.txtAirportMaxMerch.Text);

            
            m_controller.addAirport(name, position, minPassenger, maxPassenger, minMerchandise, maxMerchandise);
            
        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            if (this.lstAirport.SelectedIndices.Count > 0)
            {
                int selectedAirport = this.lstAirport.SelectedIndices[0];

                String name;
                aircraftType selectedType = 0;
                int speed;
                int maintenanceTime;
                int loadingTime;
                int unloadingTime;
                int capacity;


                name = txtAircraftName.Text;
                speed = Convert.ToInt32(txtAircraftSpeed.Text);
                maintenanceTime = Convert.ToInt32(txtAircraftMaintenance.Text);
                loadingTime = Convert.ToInt32(txtAircraftLoading.Text);
                unloadingTime = Convert.ToInt32(txtAircraftUnloading.Text);
                capacity = Convert.ToInt32(txtAircraftCapacity.Text);
                switch (cmbAircraftType.SelectedItem)
                {
                    case "Passager":
                        selectedType = aircraftType.aeronefPassager;
                        break;
                    case "Cargo":
                        selectedType = aircraftType.aeronefCargo;
                        break;
                    case "Secours":
                        selectedType = aircraftType.aeronefSecours;
                        break;
                    case "Citerne":
                        selectedType = aircraftType.aeronefCiterne;
                        break;
                    case "Observation":
                        selectedType = aircraftType.aeronefObservateur;
                        break;
                    default:
                        break;
                }
                m_controller.addAircraft(name, selectedType, speed, maintenanceTime, loadingTime, unloadingTime, capacity, selectedAirport);
            }
        }

        private void addAircraftType()
        {
            cmbAircraftType.Items.Add("Passager");
            cmbAircraftType.Items.Add("Cargo");
            cmbAircraftType.Items.Add("Secours");
            cmbAircraftType.Items.Add("Citerne");
            cmbAircraftType.Items.Add("Observation");
        }


        private void addAvailableImages()
        {
            String[] airports = System.IO.Directory.GetFiles(@"..\..\data\icons\airports", "*.png");

            //All world map airports
            foreach (String filePath in airports)
            {
                String[] fileName = filePath.Split('\\');
                cmbImageAirport.Items.Add(fileName[fileName.Length - 1]);
            }

            //All world map airplanes
            String[] airplanes = System.IO.Directory.GetFiles(@"..\..\data\icons\airplanes", "*.png");

            foreach (String filePath in airplanes)
            {
                String[] fileName = filePath.Split('\\');

                cmbImageAirplane.Items.Add(fileName[fileName.Length - 1]);
            }

            //All world map images
            String[] maps = System.IO.Directory.GetFiles(@"..\..\data\icons\maps", "*.png");

            foreach (String filePath in maps)
            {
                String[] fileName = filePath.Split('\\');

                cmbImageMap.Items.Add(fileName[fileName.Length - 1]);
            }
        }

        public void refreshAirportList()
        {
            List<Aeroport> airports = this.m_controller.getAirports();

            this.lstAirport.Items.Clear();

            foreach (Aeroport airport in airports)
            {
                //this.lstAirport.Items.Add(airport.ToString());
                lstAirport.Items.Add(new ListViewItem(new string[] { airport.Name, airport.Position, airport.MinPassenger.ToString(), airport.MaxPassenger.ToString(), airport.MinMerchandise.ToString(), airport.MaxMerchandise.ToString() }));
            }
        }

        public void refreshAircraftList()
        {
            if (lstAirport.SelectedIndices.Count > 0)
            {
                List<String> aircrafts = this.m_scenario.getAircrafts(lstAirport.SelectedIndices[0]);

                this.lstAircraft.Items.Clear();

                for (int i = 0; i < aircrafts.Count; i++)
                {
                    //Reordering columns propely
                    List<String> temp = aircrafts[i].Split(',').ToList();

                    temp.Insert(temp.Count, temp[2]);
                    temp.RemoveAt(2);
                    temp.Insert(1, temp[4]);
                    temp.RemoveAt(5);
                    temp.Insert(1, temp[5]);
                    temp.RemoveAt(6);
                    lstAircraft.Items.Add(new ListViewItem(temp.ToArray()));
                }
            }
        }

        public void fillAirportPositionTxtBox(double p_lattitude, double p_longitude)
        {
            String airportPosition = "";
            char latCardinal = ' ';
            char lonCardinal = ' ';

            if (p_lattitude > 0)
            {
                latCardinal = 'N';
            }
            else
            {
                latCardinal = 'S';
            }

            if (p_longitude > 0)
            {
                lonCardinal = 'W';
            }
            else
            {
                lonCardinal = 'E';
            }


            int degLat = Convert.ToInt32(Math.Truncate(p_lattitude));
            int degLon = Convert.ToInt32(Math.Truncate(p_longitude));

            int minLat = Convert.ToInt32((p_lattitude - degLat) * 60);
            int minLon = Convert.ToInt32((p_longitude - degLon) * 60);

            int secLat = Convert.ToInt32((p_lattitude - degLat) * 100 - Math.Truncate(p_lattitude - degLat) * 60);
            int secLon = Convert.ToInt32((p_longitude - degLon) * 100 - Math.Truncate(p_longitude - degLon) * 60);

            char quote = '\u0022';
            airportPosition = $"{degLat}° {minLat}\' {secLat}{quote} {latCardinal}, {degLon}° {minLon}\' {secLon}{quote} {lonCardinal}";
            txtAirportPosition.Text = airportPosition;
        }

        private void cmbAircraftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAircraftType.SelectedValue)
            {
                case "Passager":
                    break;
                case "Cargo":
                    break;
                case "Secours":
                    break;
                case "Citerne":
                    break;
                case "Observation":
                    break;
                default:
                    break;
            }
        }

        private void btnGenerateScenario_Click(object sender, EventArgs e)
        {
            m_scenario.serializeScenario();
        }

        private void lstAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshAircraftList();
        }

        public String getImageAirplane()
        {
            return this.cmbImageAirplane.SelectedItem.ToString();
        }

        public String getImageAirport()
        {
            return this.cmbImageAirport.SelectedItem.ToString();
        }

        public String getImageMap()
        {
            return this.cmbImageMap.SelectedItem.ToString();
        }

        private void cmbImageMap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbImageAirport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbImageAirplane_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
