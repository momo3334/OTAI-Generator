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
    public class ControlleurSimulateur
    {

        VueSimulateur m_viewSimulator;
        Scenario m_scenario;

        public ControlleurSimulateur()
        {
            this.m_scenario = deserializeScenario();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            this.m_viewSimulator = new VueSimulateur(this);
            Application.Run(this.m_viewSimulator);
        }


        public static Scenario deserializeScenario()
        {
            Debug.WriteLine("Deserialisation scenario initialise...");
            string text;
            Scenario loadedScenario = null;

            text = File.ReadAllText(@"..\..\data\Scenario.xml");
            using (Stream stream = new MemoryStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Scenario));
                loadedScenario = (Scenario)serializer.ReadObject(stream);
            }

            return loadedScenario;
        }
    }
}
