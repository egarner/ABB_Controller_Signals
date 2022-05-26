using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.IOSystemDomain;

namespace ABB_Controller_Signals
{

    class Program
    {
        static void Main(string[] args)
        {

            ControllerResults Cont = new ControllerResults();
            Cont.FindControllers();

            foreach(ControllerInfo c in Cont.Controllers)
            {
                Controller aController = ControllerFactory.CreateFrom(c);
                Console.WriteLine();
                Console.WriteLine("Controller Name: " + c.ControllerName);
                Console.WriteLine("IPAddress: " + c.IPAddress);
                Console.WriteLine("Availability: " + c.Availability);
                Console.WriteLine("State: " + aController.State);
                Console.WriteLine("Base Directory: " + c.BaseDirectory);
                Console.WriteLine("Hostname: " + c.HostName);
                Console.WriteLine("ID: " + c.Id);
                Console.WriteLine("IsVirtual: " + c.IsVirtual);
                Console.WriteLine("MacAddress: " + c.MacAddress);
                Console.WriteLine("NetscanID: " + c.NetscanId);
                Console.WriteLine("RobAPIPort: " + c.RobApiPort);
                Console.WriteLine("RunLevel: " + c.RunLevel);
                Console.WriteLine("SystemID: " + c.SystemId);
                Console.WriteLine("System Name: " + c.SystemName);
                Console.WriteLine("Version: " + c.Version);
                Console.WriteLine("Version Name: " + c.VersionName);
                Console.WriteLine("Web Services Port: " + c.WebServicesPort);
                Console.WriteLine("== Signals ===============================>");

                SignalCollection aSignalCollection = aController.IOSystem.GetSignals(IOFilterTypes.All);
                
                Console.WriteLine("\tName,\tType,\tValue");

                foreach(Signal s in aSignalCollection)
                {
                    Console.WriteLine(string.Format("\t{0} \t{1} \t{2}", s.Name, s.Type, s.Value));
                }
            }
            Console.WriteLine("Press any key to terminate.");
            Console.ReadLine();
        }
    }
}
