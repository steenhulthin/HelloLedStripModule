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

namespace HelloLedStripModule
{
    public partial class Program
    {
        // LED number 0 is the first LED from the RIGHT of the LED strip
        private int _ledNumber = 0;
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            Debug.Print("Program Started");
            led_Strip.TurnAllLedsOff();
            led_Strip.TurnAllLedsOn();
            Thread.Sleep(1000);
            led_Strip.TurnAllLedsOff();
            var timer = new GT.Timer(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(GT.Timer timer)
        {
            led_Strip.TurnLEDOff(_ledNumber);
            if (_ledNumber == 6) _ledNumber = 0;
            else _ledNumber++;
            led_Strip.TurnLEDOn(_ledNumber);
        }
    }
}
