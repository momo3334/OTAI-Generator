using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace OTAI_Simulator
{
    public partial class VueSimulateur : Form
    {
        ControlleurSimulateur m_controller;
        byte[] m_imageMap;
        byte[] m_iconAircraft;
        byte[] m_iconAirport;

        public VueSimulateur(ControlleurSimulateur p_controlleurSimulateur,byte[] p_imageMap, byte[] p_iconAircraft, byte[] p_iconAirport )
        {
            InitializeComponent();
            initCustomFont();

            this.m_controller = p_controlleurSimulateur;
            this.m_imageMap = p_imageMap;
            this.m_iconAircraft = p_iconAircraft;
            this.m_iconAirport = p_iconAirport;
        }

        private void OpenFileDialog(string folderPath)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog();

            Stream fileStream = null;
            //Update - remove parenthesis
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (fileStream = selectFileDialog.OpenFile()) != null)
            {
                string fileName = selectFileDialog.FileName;
                using (fileStream)
                {
                    // TODO
                }
            }
        }

        public void initCustomFont()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.DS_DIGII.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.DS_DIGII;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            lblClock.Font = new Font(pfc.Families[0], 54);
        }

        private void BtnOpenNewScenario_Click(object sender, EventArgs e)
        {
            OpenFileDialog("");
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            Thread clock = new Thread(new ThreadStart(Horloge.start));
            clock.Start();
        }
    }
}
