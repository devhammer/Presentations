using System;
using Microsoft.SPOT;
using System.Threading;

namespace BrainPadDemo1
{
    public class Program
    {
        public static void Main()
        {
            BrainPad.Display.Clear();
            BrainPad.Display.DrawLargeString(5, 5, "Hello!", BrainPad.Color.Palette.Red);
            while (BrainPad.LOOPING)
            {
                if(BrainPad.LightSensor.GetLevel() > 0.5)
                {
                    BrainPad.Display.Clear();
                    BrainPad.Display.DrawLargeString(5, 5, "Light!", BrainPad.Color.Palette.White);
                }
                
            }
        }
    }
}
