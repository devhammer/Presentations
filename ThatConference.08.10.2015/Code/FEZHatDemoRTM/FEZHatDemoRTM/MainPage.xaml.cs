using GHIElectronics.UAP.Shields;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalFezHAT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private FEZHAT hat;
        private int count = 0;
        private SolidColorBrush redBrush;
        private SolidColorBrush blueBrush;
        private SolidColorBrush blackBrush;
        private double temp;
        private FEZHAT.Color theColor;

        public MainPage()
        {
            this.InitializeComponent();

            this.Start();
        }

        private async void Start()
        {
            redBrush = new SolidColorBrush(Colors.Red);
            blueBrush = new SolidColorBrush(Colors.Blue);
            blackBrush = new SolidColorBrush(Colors.Black);
            hat = await FEZHAT.CreateAsync();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, object e)
        {
            var xamlBrush = blackBrush;
            temp = hat.GetTemperature();
            if(temp > 26)
            {
                theColor = FEZHAT.Color.Red;
                xamlBrush = redBrush;
            }
            else
            {
                theColor = FEZHAT.Color.Blue;
                xamlBrush = blueBrush;                
            }

            if(count%2 > 0)
            {
                hat.D2.Color = theColor;
                hat.D3.TurnOff();
                D3X.Fill = xamlBrush;
                D2X.Fill = blackBrush;
            }
            else
            {
                hat.D3.Color = theColor;
                hat.D2.TurnOff();
                D2X.Fill = xamlBrush;
                D3X.Fill = blackBrush;
            }
            Debug.WriteLine("Temp is:" + temp.ToString("0.00"));

            var request = new HttpClient();
            string jsonTemp = "{ 'SensorName': 'Temperature 1', 'SensorValue': '" + temp.ToString("0.00") + "'}";
            var content = new StringContent(jsonTemp);
            HttpResponseMessage response = await request.PostAsync("http://sensorreadingapi.azurewebsites.net/Api/SensorReading", content);
            Debug.WriteLine("Response: " + response.StatusCode.ToString());
            count++;
        }
    }
}
