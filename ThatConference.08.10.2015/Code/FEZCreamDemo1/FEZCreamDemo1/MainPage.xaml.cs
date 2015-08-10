using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GT = GHIElectronics.UAP.Gadgeteer;
using GTM = GHIElectronics.UAP.Gadgeteer.Modules;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FEZCreamDemo1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GTM.FEZCream mainboard;
        private GTM.Joystick joystick;
        private GTM.CharacterDisplay charDisplay;
        private DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();

            this.Setup();
        }

        private async void Setup()
        {
            mainboard = await GT.Module.CreateAsync<GTM.FEZCream>();
            joystick = await GT.Module.CreateAsync<GTM.Joystick>(mainboard.GetProvidedSocket(5));
            charDisplay = await GT.Module.CreateAsync<GTM.CharacterDisplay>(mainboard.GetProvidedSocket(8));

            this.ProgramStarted();
        }

        private void ProgramStarted()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
            charDisplay.BacklightEnabled = true;
        }

        private void Timer_Tick(object sender, object e)
        {
            string joystickPos = "X: " + joystick.X.ToString() + ", Y: " + joystick.Y.ToString();
            JoystickPosition.Text = joystickPos;
            charDisplay.Clear();
            charDisplay.SetCursorPosition(0, 0);
            charDisplay.Print("X: " + joystick.X.ToString("0.0000"));
            charDisplay.SetCursorPosition(1, 0);
            charDisplay.Print("Y: " + joystick.Y.ToString("0.0000"));
        }
    }
}
