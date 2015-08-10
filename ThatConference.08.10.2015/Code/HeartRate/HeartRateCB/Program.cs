using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using Gadgeteer.Modules.DevhammerEnterprises;

namespace HeartRateCB
{
    public partial class Program
    {
        GT.Timer _timer;

        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            button.ButtonPressed += button_ButtonPressed;
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            starBoard.ShowPattern(StarBoard.Patterns.Heartbeat);            
        }
    }
}
