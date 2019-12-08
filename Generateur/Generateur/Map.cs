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
    public partial class Map : Form
    {
        VueGenerateur m_parentForm;

        public Map(VueGenerateur p_parent)
        {
            this.m_parentForm = p_parent;
            InitializeComponent();
        }

        private void Map_Click(object sender, MouseEventArgs e)
        {
            float height = this.Height;
            float width = this.Width;
            Debug.WriteLine(e.Location.X);
            Debug.WriteLine(e.Location.Y);

            double mouseX = (e.Location.X - width / 2);
            double mouseY = ((height - e.Location.Y) - height / 2);


            double lat = mouseY / (height / 180);
            double longi = mouseX / (width / 360);

            Debug.WriteLine("X:" + mouseX + "Y:" + mouseY + ", long: " + longi + " lat: " + lat);

            m_parentForm.fillAirportPositionTxtBox(lat, longi);
            this.Close();
        }
    }
}
