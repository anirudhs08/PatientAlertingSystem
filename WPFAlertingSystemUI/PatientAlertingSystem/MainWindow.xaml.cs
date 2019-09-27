using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PatientAlertingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<bool> Bed2AlertHistory = new List<bool>();
        List<bool> Bed8AlertHistory = new List<bool>();
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void AlertBed2_Click(object sender, RoutedEventArgs e)
        {
            alertBed2.IsEnabled = false;
            undoAlertBed2.IsEnabled = true;
            Bed2AlertHistory.Clear();
            bool pulseLow = (bool)lowPulseBed2.IsChecked;
            bool pulseHigh = (bool)highPulseBed2.IsChecked;
            bool spo2Low = (bool)lowSpo2Bed2.IsChecked;
            bool spo2High = (bool)highSpo2Bed2.IsChecked;
            bool temperatureLow = (bool)lowTemperatureBed2.IsChecked;
            bool temperatureHigh = (bool)highTemperatureBed2.IsChecked;
            Bed2AlertHistory.Add(pulseLow);
            Bed2AlertHistory.Add(pulseHigh);
            Bed2AlertHistory.Add(spo2Low);
            Bed2AlertHistory.Add(spo2High);
            Bed2AlertHistory.Add(temperatureLow);
            Bed2AlertHistory.Add(temperatureHigh);
            lowPulseBed2.IsChecked = false;
            highPulseBed2.IsChecked = false;
            lowSpo2Bed2.IsChecked = false;
            highSpo2Bed2.IsChecked = false;
            lowTemperatureBed2.IsChecked = false;
            highTemperatureBed2.IsChecked = false;


        }

        private void UndoAlertBed2_Click(object sender, RoutedEventArgs e)
        {
            alertBed2.IsEnabled = true;
            undoAlertBed2.IsEnabled = false;
            lowPulseBed2.IsChecked = Bed2AlertHistory[0];
            highPulseBed2.IsChecked = Bed2AlertHistory[1];
            lowSpo2Bed2.IsChecked = Bed2AlertHistory[2];
            highSpo2Bed2.IsChecked = Bed2AlertHistory[3];
            lowTemperatureBed2.IsChecked = Bed2AlertHistory[4];
            highTemperatureBed2.IsChecked = Bed2AlertHistory[5];
            
        }

        private void AlertBed8_Click(object sender, RoutedEventArgs e)
        {
            alertBed8.IsEnabled = false;
            undoAlertBed8.IsEnabled = true;
            Bed8AlertHistory.Clear();
            bool pulseLow = (bool)lowPulseBed8.IsChecked;
            bool pulseHigh = (bool)highPulseBed8.IsChecked;
            bool spo2Low = (bool)lowSpo2Bed8.IsChecked;
            bool spo2High = (bool)highSpo2Bed8.IsChecked;
            bool temperatureLow = (bool)lowTemperatureBed8.IsChecked;
            bool temperatureHigh = (bool)highTemperatureBed8.IsChecked;
            Bed8AlertHistory.Add(pulseLow);
            Bed8AlertHistory.Add(pulseHigh);
            Bed8AlertHistory.Add(spo2Low);
            Bed8AlertHistory.Add(spo2High);
            Bed8AlertHistory.Add(temperatureLow);
            Bed8AlertHistory.Add(temperatureHigh);
            lowPulseBed8.IsChecked = false;
            highPulseBed8.IsChecked = false;
            lowSpo2Bed8.IsChecked = false;
            highSpo2Bed8.IsChecked = false;
            lowTemperatureBed8.IsChecked = false;
            highTemperatureBed8.IsChecked = false;
        }

        private void UndoAlertBed8_Click(object sender, RoutedEventArgs e)
        {
            alertBed8.IsEnabled = true;
            undoAlertBed8.IsEnabled = false;
            lowPulseBed8.IsChecked = Bed2AlertHistory[0];
            highPulseBed8.IsChecked = Bed2AlertHistory[1];
            lowSpo2Bed8.IsChecked = Bed2AlertHistory[2];
            highSpo2Bed8.IsChecked = Bed2AlertHistory[3];
            lowTemperatureBed8.IsChecked = Bed2AlertHistory[4];
            highTemperatureBed8.IsChecked = Bed2AlertHistory[5];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AlertingSystem.Service1Client patient = new AlertingSystem.Service1Client();


            var dummy = patient.MonitorPatientVitals();
            for (int i = 0; i < dummy.Length; i++)
            {

                string[] alertArray = dummy[i].Diagnosis.Split(',');
                int bedNo = dummy[i].BedNo;
                int iterator = 0;
                switch (bedNo)
                {
                    case 1:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed1.IsChecked = true;
                                else
                                    lowPulseBed1.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed1.IsChecked = true;
                                else
                                    lowSpo2Bed1.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed1.IsChecked = true;
                                else
                                    lowTemperatureBed1.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 2:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed2.IsChecked = true;
                                else
                                    lowPulseBed2.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed2.IsChecked = true;
                                else
                                    lowSpo2Bed2.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed2.IsChecked = true;
                                else
                                    lowTemperatureBed2.IsChecked = true;
                            }
                            iterator = iterator + 2;
                            alertBed2.IsEnabled = true;


                        }
                        break;
                    case 3:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed3.IsChecked = true;
                                else
                                    lowPulseBed3.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed3.IsChecked = true;
                                else
                                    lowSpo2Bed3.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed3.IsChecked = true;
                                else
                                    lowTemperatureBed3.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 4:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed4.IsChecked = true;
                                else
                                    lowPulseBed4.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed4.IsChecked = true;
                                else
                                    lowSpo2Bed4.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed4.IsChecked = true;
                                else
                                    lowTemperatureBed4.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 5:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed5.IsChecked = true;
                                else
                                    lowPulseBed5.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed5.IsChecked = true;
                                else
                                    lowSpo2Bed5.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed5.IsChecked = true;
                                else
                                    lowTemperatureBed5.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 6:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed6.IsChecked = true;
                                else
                                    lowPulseBed6.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed6.IsChecked = true;
                                else
                                    lowSpo2Bed6.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed6.IsChecked = true;
                                else
                                    lowTemperatureBed6.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 7:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed7.IsChecked = true;
                                else
                                    lowPulseBed7.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed7.IsChecked = true;
                                else
                                    lowSpo2Bed7.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed7.IsChecked = true;
                                else
                                    lowTemperatureBed7.IsChecked = true;
                            }
                            iterator = iterator + 2;

                        }
                        break;
                    case 8:
                        while (iterator < alertArray.Length)
                        {
                            if (alertArray[iterator] == "pulse")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highPulseBed8.IsChecked = true;
                                else
                                    lowPulseBed8.IsChecked = true;
                            }
                            else if (alertArray[iterator] == "spo2")
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highSpo2Bed8.IsChecked = true;
                                else
                                    lowSpo2Bed8.IsChecked = true;
                            }
                            else
                            {
                                if (alertArray[iterator + 1] == "high")
                                    highTemperatureBed8.IsChecked = true;
                                else
                                    lowTemperatureBed8.IsChecked = true;
                            }
                            iterator = iterator + 2;
                            alertBed8.IsEnabled = true;
                        }
                        break;
                }


            }
            DisableBeds();

        }
        private void DisableBeds()
        {
            string configurationSet = "";
            XDocument RootConfigure = XDocument.Load(@"C:\Users\320053936\Downloads\ConfigureBeds.xml");
            foreach (XElement configure in RootConfigure.Descendants("BedConfiguration"))
            {
                foreach (XElement firstRow in RootConfigure.Descendants("FirstRowBeds"))
                {
                    configurationSet = configurationSet + firstRow.Value + ",";
                }
                foreach (XElement secondRow in RootConfigure.Descendants("SecondRowBeds"))
                {
                    configurationSet = configurationSet + secondRow.Value;
                }

            }
           
            string[] configurationAlert = configurationSet.Split(',');
            int rowOne = Convert.ToInt32(configurationAlert[0]);
            int rowTwo = Convert.ToInt32(configurationAlert[1]);
            switch(rowOne)
            {
                case 0:
                    Bed1Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed1.Visibility = Visibility.Hidden;
                    lowPulseBed1.Visibility = Visibility.Hidden;
                    highPulseBed1.Visibility = Visibility.Hidden;
                    lowSpo2Bed1.Visibility = Visibility.Hidden;
                    highSpo2Bed1.Visibility = Visibility.Hidden;
                    lowTemperatureBed1.Visibility = Visibility.Hidden;
                    highTemperatureBed1.Visibility = Visibility.Hidden;
                    alertBed1.Visibility = Visibility.Hidden;
                    undoAlertBed1.Visibility = Visibility.Hidden;

                    Bed2Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed2.Visibility = Visibility.Hidden;
                    lowPulseBed2.Visibility = Visibility.Hidden;
                    highPulseBed2.Visibility = Visibility.Hidden;
                    lowSpo2Bed2.Visibility = Visibility.Hidden;
                    highSpo2Bed2.Visibility = Visibility.Hidden;
                    lowTemperatureBed2.Visibility = Visibility.Hidden;
                    highTemperatureBed2.Visibility = Visibility.Hidden;
                    alertBed2.Visibility = Visibility.Hidden;
                    undoAlertBed2.Visibility = Visibility.Hidden;

                    Bed3Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed3.Visibility = Visibility.Hidden;
                    lowPulseBed3.Visibility = Visibility.Hidden;
                    highPulseBed3.Visibility = Visibility.Hidden;
                    lowSpo2Bed3.Visibility = Visibility.Hidden;
                    highSpo2Bed3.Visibility = Visibility.Hidden;
                    lowTemperatureBed3.Visibility = Visibility.Hidden;
                    highTemperatureBed3.Visibility = Visibility.Hidden;
                    alertBed3.Visibility = Visibility.Hidden;
                    undoAlertBed3.Visibility = Visibility.Hidden;

                    Bed4Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed4.Visibility = Visibility.Hidden;
                    lowPulseBed4.Visibility = Visibility.Hidden;
                    highPulseBed4.Visibility = Visibility.Hidden;
                    lowSpo2Bed4.Visibility = Visibility.Hidden;
                    highSpo2Bed4.Visibility = Visibility.Hidden;
                    lowTemperatureBed4.Visibility = Visibility.Hidden;
                    highTemperatureBed4.Visibility = Visibility.Hidden;
                    alertBed4.Visibility = Visibility.Hidden;
                    undoAlertBed4.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Bed2Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed2.Visibility = Visibility.Hidden;
                    lowPulseBed2.Visibility = Visibility.Hidden;
                    highPulseBed2.Visibility = Visibility.Hidden;
                    lowSpo2Bed2.Visibility = Visibility.Hidden;
                    highSpo2Bed2.Visibility = Visibility.Hidden;
                    lowTemperatureBed2.Visibility = Visibility.Hidden;
                    highTemperatureBed2.Visibility = Visibility.Hidden;
                    alertBed2.Visibility = Visibility.Hidden;
                    undoAlertBed2.Visibility = Visibility.Hidden;

                    Bed3Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed3.Visibility = Visibility.Hidden;
                    lowPulseBed3.Visibility = Visibility.Hidden;
                    highPulseBed3.Visibility = Visibility.Hidden;
                    lowSpo2Bed3.Visibility = Visibility.Hidden;
                    highSpo2Bed3.Visibility = Visibility.Hidden;
                    lowTemperatureBed3.Visibility = Visibility.Hidden;
                    highTemperatureBed3.Visibility = Visibility.Hidden;
                    alertBed3.Visibility = Visibility.Hidden;
                    undoAlertBed3.Visibility = Visibility.Hidden;

                    Bed4Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed4.Visibility = Visibility.Hidden;
                    lowPulseBed4.Visibility = Visibility.Hidden;
                    highPulseBed4.Visibility = Visibility.Hidden;
                    lowSpo2Bed4.Visibility = Visibility.Hidden;
                    highSpo2Bed4.Visibility = Visibility.Hidden;
                    lowTemperatureBed4.Visibility = Visibility.Hidden;
                    highTemperatureBed4.Visibility = Visibility.Hidden;
                    alertBed4.Visibility = Visibility.Hidden;
                    undoAlertBed4.Visibility = Visibility.Hidden;


                    break;
                case 2:
                    Bed3Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed3.Visibility = Visibility.Hidden;
                    lowPulseBed3.Visibility = Visibility.Hidden;
                    highPulseBed3.Visibility = Visibility.Hidden;
                    lowSpo2Bed3.Visibility = Visibility.Hidden;
                    highSpo2Bed3.Visibility = Visibility.Hidden;
                    lowTemperatureBed3.Visibility = Visibility.Hidden;
                    highTemperatureBed3.Visibility = Visibility.Hidden;
                    textBlockPulseBed3.Visibility = Visibility.Hidden;
                    textBlockSpo2Bed3.Visibility = Visibility.Hidden;
                    textBlockTemperatureBed3.Visibility = Visibility.Hidden;
                    alertBed3.Visibility = Visibility.Hidden;
                    undoAlertBed3.Visibility = Visibility.Hidden;

                    Bed4Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed4.Visibility = Visibility.Hidden;
                    lowPulseBed4.Visibility = Visibility.Hidden;
                    highPulseBed4.Visibility = Visibility.Hidden;
                    lowSpo2Bed4.Visibility = Visibility.Hidden;
                    highSpo2Bed4.Visibility = Visibility.Hidden;
                    lowTemperatureBed4.Visibility = Visibility.Hidden;
                    highTemperatureBed4.Visibility = Visibility.Hidden;
                    textBlockPulseBed4.Visibility = Visibility.Hidden;
                    textBlockSpo2Bed4.Visibility = Visibility.Hidden;
                    textBlockTemperatureBed4.Visibility = Visibility.Hidden;
                    alertBed4.Visibility = Visibility.Hidden;
                    undoAlertBed4.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Bed4Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed4.Visibility = Visibility.Hidden;
                    lowPulseBed4.Visibility = Visibility.Hidden;
                    highPulseBed4.Visibility = Visibility.Hidden;
                    lowSpo2Bed4.Visibility = Visibility.Hidden;
                    highSpo2Bed4.Visibility = Visibility.Hidden;
                    lowTemperatureBed4.Visibility = Visibility.Hidden;
                    highTemperatureBed4.Visibility = Visibility.Hidden;
                    alertBed4.Visibility = Visibility.Hidden;
                    undoAlertBed4.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
            switch (rowTwo)
            {
                case 0:
                    Bed5Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed5.Visibility = Visibility.Hidden;
                    lowPulseBed5.Visibility = Visibility.Hidden;
                    highPulseBed5.Visibility = Visibility.Hidden;
                    lowSpo2Bed5.Visibility = Visibility.Hidden;
                    highSpo2Bed5.Visibility = Visibility.Hidden;
                    lowTemperatureBed5.Visibility = Visibility.Hidden;
                    highTemperatureBed5.Visibility = Visibility.Hidden;
                    alertBed5.Visibility = Visibility.Hidden;
                    undoAlertBed5.Visibility = Visibility.Hidden;

                    Bed6Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed6.Visibility = Visibility.Hidden;
                    lowPulseBed6.Visibility = Visibility.Hidden;
                    highPulseBed6.Visibility = Visibility.Hidden;
                    lowSpo2Bed6.Visibility = Visibility.Hidden;
                    highSpo2Bed6.Visibility = Visibility.Hidden;
                    lowTemperatureBed6.Visibility = Visibility.Hidden;
                    highTemperatureBed6.Visibility = Visibility.Hidden;
                    alertBed6.Visibility = Visibility.Hidden;
                    undoAlertBed6.Visibility = Visibility.Hidden;

                    Bed7Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed7.Visibility = Visibility.Hidden;
                    lowPulseBed7.Visibility = Visibility.Hidden;
                    highPulseBed7.Visibility = Visibility.Hidden;
                    lowSpo2Bed7.Visibility = Visibility.Hidden;
                    highSpo2Bed7.Visibility = Visibility.Hidden;
                    lowTemperatureBed7.Visibility = Visibility.Hidden;
                    highTemperatureBed7.Visibility = Visibility.Hidden;
                    alertBed7.Visibility = Visibility.Hidden;
                    undoAlertBed7.Visibility = Visibility.Hidden;

                    Bed8Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed8.Visibility = Visibility.Hidden;
                    lowPulseBed8.Visibility = Visibility.Hidden;
                    highPulseBed8.Visibility = Visibility.Hidden;
                    lowSpo2Bed8.Visibility = Visibility.Hidden;
                    highSpo2Bed8.Visibility = Visibility.Hidden;
                    lowTemperatureBed8.Visibility = Visibility.Hidden;
                    highTemperatureBed8.Visibility = Visibility.Hidden;
                    alertBed8.Visibility = Visibility.Hidden;
                    undoAlertBed8.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Bed6Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed6.Visibility = Visibility.Hidden;
                    lowPulseBed6.Visibility = Visibility.Hidden;
                    highPulseBed6.Visibility = Visibility.Hidden;
                    lowSpo2Bed6.Visibility = Visibility.Hidden;
                    highSpo2Bed6.Visibility = Visibility.Hidden;
                    lowTemperatureBed6.Visibility = Visibility.Hidden;
                    highTemperatureBed6.Visibility = Visibility.Hidden;
                    alertBed6.Visibility = Visibility.Hidden;
                    undoAlertBed6.Visibility = Visibility.Hidden;

                    Bed7Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed7.Visibility = Visibility.Hidden;
                    lowPulseBed7.Visibility = Visibility.Hidden;
                    highPulseBed7.Visibility = Visibility.Hidden;
                    lowSpo2Bed7.Visibility = Visibility.Hidden;
                    highSpo2Bed7.Visibility = Visibility.Hidden;
                    lowTemperatureBed7.Visibility = Visibility.Hidden;
                    highTemperatureBed7.Visibility = Visibility.Hidden;
                    alertBed7.Visibility = Visibility.Hidden;
                    undoAlertBed7.Visibility = Visibility.Hidden;

                    Bed8Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed8.Visibility = Visibility.Hidden;
                    lowPulseBed8.Visibility = Visibility.Hidden;
                    highPulseBed8.Visibility = Visibility.Hidden;
                    lowSpo2Bed8.Visibility = Visibility.Hidden;
                    highSpo2Bed8.Visibility = Visibility.Hidden;
                    lowTemperatureBed8.Visibility = Visibility.Hidden;
                    highTemperatureBed8.Visibility = Visibility.Hidden;
                    alertBed8.Visibility = Visibility.Hidden;
                    undoAlertBed8.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Bed7Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed7.Visibility = Visibility.Hidden;
                    lowPulseBed7.Visibility = Visibility.Hidden;
                    highPulseBed7.Visibility = Visibility.Hidden;
                    lowSpo2Bed7.Visibility = Visibility.Hidden;
                    highSpo2Bed7.Visibility = Visibility.Hidden;
                    lowTemperatureBed7.Visibility = Visibility.Hidden;
                    highTemperatureBed7.Visibility = Visibility.Hidden;
                    alertBed7.Visibility = Visibility.Hidden;
                    undoAlertBed7.Visibility = Visibility.Hidden;

                    Bed8Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed8.Visibility = Visibility.Hidden;
                    lowPulseBed8.Visibility = Visibility.Hidden;
                    highPulseBed8.Visibility = Visibility.Hidden;
                    lowSpo2Bed8.Visibility = Visibility.Hidden;
                    highSpo2Bed8.Visibility = Visibility.Hidden;
                    lowTemperatureBed8.Visibility = Visibility.Hidden;
                    highTemperatureBed8.Visibility = Visibility.Hidden;
                    alertBed8.Visibility = Visibility.Hidden;
                    undoAlertBed8.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Bed8Image.Visibility = Visibility.Hidden;
                    textBlockPulseBed8.Visibility = Visibility.Hidden;
                    lowPulseBed8.Visibility = Visibility.Hidden;
                    highPulseBed8.Visibility = Visibility.Hidden;
                    lowSpo2Bed8.Visibility = Visibility.Hidden;
                    highSpo2Bed8.Visibility = Visibility.Hidden;
                    lowTemperatureBed8.Visibility = Visibility.Hidden;
                    highTemperatureBed8.Visibility = Visibility.Hidden;
                    alertBed8.Visibility = Visibility.Hidden;
                    undoAlertBed8.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    break;
                default:
                    break;
            }

        }

        
    }
}
