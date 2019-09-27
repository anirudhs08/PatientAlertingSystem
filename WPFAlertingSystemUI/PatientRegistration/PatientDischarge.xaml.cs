using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PatientRegistration
{
    /// <summary>
    /// Interaction logic for PatientDischarge.xaml
    /// </summary>
    public partial class PatientDischarge : Window
    {
        public PatientDischarge()
        {
            InitializeComponent();
            //InitializeComponent();
            ServiceController ServiceLoadBed = new ServiceController();
            buttonDischargeBed1.IsEnabled = false;
            buttonDischargeBed2.IsEnabled = false;
            buttonDischargeBed3.IsEnabled = false;
            buttonDischargeBed4.IsEnabled = false;
            buttonDischargeBed5.IsEnabled = false;
            buttonDischargeBed6.IsEnabled = false;
            buttonDischargeBed7.IsEnabled = false;
            buttonDischargeBed8.IsEnabled = false;

            PatientDetails patient = new PatientDetails();

            //List<PatientDetails> allPatients = new List<PatientDetails>()
            var allPatients = ServiceLoadBed.Load_data();

            for (int i = 0; i < allPatients.Length; i++)
            {
                patient.PatientID = allPatients[i].PatientID;
                patient.BedNo = allPatients[i].BedNo;
                int bedno = allPatients[i].BedNo;
                switch (bedno)
                {
                    case 1:
                        textBlock1.Text = patient.PatientID.ToString();
                        buttonDischargeBed1.IsEnabled = true;
                        break;

                    case 2:
                        textBlock2.Text = patient.PatientID.ToString();
                        buttonDischargeBed2.IsEnabled = true;
                        break;

                    case 3:
                        textBlock3.Text = patient.PatientID.ToString();
                        buttonDischargeBed3.IsEnabled = true;
                        break;

                    case 4:
                        textBlock4.Text = patient.PatientID.ToString();
                        buttonDischargeBed4.IsEnabled = true;
                        break;

                    case 5:
                        textBlock5.Text = patient.PatientID.ToString();
                        buttonDischargeBed5.IsEnabled = true;
                        break;

                    case 6:
                        textBlock6.Text = patient.PatientID.ToString();
                        buttonDischargeBed6.IsEnabled = true;
                        break;

                    case 7:
                        textBlock7.Text = patient.PatientID.ToString();
                        buttonDischargeBed7.IsEnabled = true;
                        break;

                    case 8:
                        textBlock8.Text = patient.PatientID.ToString();
                        buttonDischargeBed8.IsEnabled = true;
                        break;


                }
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRegistration.ServiceController serviceConnection = new PatientRegistration.ServiceController();
            string result = serviceConnection.DeletePatient(textBlock1.Text.ToString());


            MessageBox.Show("result");
            textBlock1.Text = "ID";
        }

        private void ButtonDischargeBed2_Click(object sender, RoutedEventArgs e)
        {
            ServiceController serviceConnection = new ServiceController();
            string result = serviceConnection.DeletePatient(textBlock2.Text.ToString());
            if (result == "true")
                MessageBox.Show("Successfully Deleted");
            else
                MessageBox.Show("Could not Deleted");
            textBlock2.Text = "ID";
        }

        private void ButtonDischargeBed3_Click(object sender, RoutedEventArgs e)
        {

            ServiceController serviceConnection = new ServiceController();
            string result = serviceConnection.DeletePatient(textBlock3.Text.ToString());
            if (result == "true")
                MessageBox.Show("Successfully Deleted");
            else
                MessageBox.Show("Could not Deleted");

            textBlock3.Text = "ID";
        }

        private void ButtonDischargeBed4_Click(object sender, RoutedEventArgs e)
        {
            ServiceController serviceConnection = new ServiceController();
            string result = serviceConnection.DeletePatient(textBlock4.Text.ToString());
            if (result == "true")
                MessageBox.Show("Successfully Deleted");
            else
                MessageBox.Show("Could not Deleted");
            textBlock4.Text = "ID";
        }
    }







   
}


