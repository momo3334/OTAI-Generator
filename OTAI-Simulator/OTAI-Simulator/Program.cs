using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTAI_Simulator
{
    public enum aircraftType { aeronefPassager, aeronefCargo, aeronefSecours, aeronefCiterne, aeronefObservateur }


    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ControlleurSimulateur controller = new ControlleurSimulateur();
        }


    }
}
