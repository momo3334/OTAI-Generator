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
            this.m_parentForm = m_parentForm;
            InitializeComponent();
        }

        private void Map_Click(object sender, MouseEventArgs e)
        {
            float height = this.Height;
            float width = this.Width;

            float mouseX = e.Location.X - width / 2;
            float mouseY = (height - e.Location.Y) - (height / 2);


            float lat = mouseY ;
            float longi = mouseX / 2;

            Debug.WriteLine("X:" + mouseX + "Y:" + mouseY + ", long: " + longi + " lat: " + lat);
        }
    }
}
