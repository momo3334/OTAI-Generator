using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public partial class VueGenerateur : Form
    {
        ControlleurGenerateur m_controller;

        public VueGenerateur(ControlleurGenerateur p_controller)
        {
            InitializeComponent();
            this.m_controller = p_controller;

            lstAirport.View = View.Details;
            //lstAirport.Columns.Add("Nom");
            //lstAirport.Columns.Add("Position");
            addAircraftType();
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

            updateAirportList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            m_controller.addAircraft( name, selectedType, speed, maintenanceTime, loadingTime, unloadingTime, capacity);

            
        }

        private void addAircraftType()
        {
            cmbAircraftType.Items.Add("Passager");
            cmbAircraftType.Items.Add("Cargo");
            cmbAircraftType.Items.Add("Secours");
            cmbAircraftType.Items.Add("Citerne");
            cmbAircraftType.Items.Add("Observation");
        }

        private void updateAirportList()
        {
            List<Aeroport> airports = this.m_controller.getAirports();

            this.lstAirport.Items.Clear();

            foreach (Aeroport airport in airports)
            {
                //this.lstAirport.Items.Add(airport.ToString());
                lstAirport.Items.Add(new ListViewItem(new string[] { airport.Name, airport.Position }));
            }

            //this.lstAirport.Update();
        }
    }
}
