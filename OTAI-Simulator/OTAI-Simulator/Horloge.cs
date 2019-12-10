using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAI_Simulator
{
    public static class Horloge
    {
        static int m_currentTime;
        static bool m_running;

        static Horloge()
        {
            m_currentTime = 0;
        }

        public static void start()
        {
            m_running = true;
            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long prevTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long deltaTime = 0;
            while (m_running)
            {
                currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                deltaTime = currentTime - prevTime;

                if (deltaTime >= 1000)
                {
                    Debug.WriteLine("Spin");
                    prevTime = currentTime;
                }
            }
        }

        public static void Stop()
        {
            m_running = false;
        }
    }
}
