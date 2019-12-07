using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public enum aircraftType { aeronefPassager, aeronefCargo, aeronefSecours, aeronefCiterne, aeronefObservateur }

    static class Generateur
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Scenario scenario = new Scenario();
        }
    }
}
