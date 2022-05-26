using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.IOSystemDomain;

namespace ABB_Controller_Signals
{
    class ControllerResults
    {
        public ControllerInfoCollection Controllers { get; set; }
        public Controller SelectedController { get; set; }
        public SignalCollection Signals { get; set; }

        public void FindControllers()
        {
            var scanner = new NetworkScanner();
            scanner.Scan();
            Controllers = scanner.Controllers;
        }

    }
}
