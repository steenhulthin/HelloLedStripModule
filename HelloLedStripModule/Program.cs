using System.Threading;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace HelloLedStripModule
{
    public partial class Program
    {
        private static readonly int FirstLed = 0;
        private static readonly int LastLed = 6;
        private int _ledNumberToModify = FirstLed;

        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            Debug.Print("Program Started");
            FlashAllLedsOnce();
            var timer = new GT.Timer(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void FlashAllLedsOnce()
        {
            led_Strip.TurnAllLedsOff();
            led_Strip.TurnAllLedsOn();
            Thread.Sleep(1000);
            led_Strip.TurnAllLedsOff();
        }

        void timer_Tick(GT.Timer timer)
        {
            led_Strip.TurnLEDOff(_ledNumberToModify);
            if (_ledNumberToModify == LastLed) _ledNumberToModify = FirstLed;
            else _ledNumberToModify++;
            led_Strip.TurnLEDOn(_ledNumberToModify);
        }
    }
}
