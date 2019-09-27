using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PatientRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("####################");
            PatientRegistration.PatientDetails patientDetails = new PatientRegistration.PatientDetails();
            patientDetails.PatientID = int.Parse(textBoxPatientId.Text);
            patientDetails.PatientName = textBoxPatientName.Text;
            patientDetails.Address = textBoxAddress.Text;
            patientDetails.Contact = int.Parse(textBoxContactDetail.Text);
            patientDetails.BedNo = int.Parse(textBoxBedNo.Text);
            patientDetails.BloodGroup = textBoxBloodGroup.Text;
            patientDetails.Diagnosis = "Fever";
            patientDetails.Doctor = textBoxDoctor.Text;

            patientDetails.runService(patientDetails);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxPatientId.Text = "";
            textBoxPatientName.Text = "";
            textBoxBloodGroup.Text = "";
            textBoxAddress.Text = "";
            textBoxBedNo.Text = "";
            textBoxContactDetail.Text = "";
            textBoxDoctor.Text = "";
        }

        private void Id_LoseFocus(object sender, RoutedEventArgs e)
        {
            
            if(!Regex.IsMatch(textBoxPatientId.Text, @"^\d+$"))
            {
                textBoxPatientId.Text = "Invalid input";
               
                
            }
        }

       

        private void TxtBedNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(textBoxBedNo.Text, @"^\d+$"))
            {
                textBoxBedNo.Text = "Invalid Bed No";
               
            }
        }

        private void Contact_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(textBoxContactDetail.Text, @"^\d+$"))
            {
                textBoxContactDetail.Text = "invalid Contact number";
                
            }
        }
        /*
        private void Contact_KeyUp(object sender, KeyEventArgs e)
        {
            if(textBoxContactDetail.Text.Length>=10)
            {
                textBoxContactDetail.IsReadOnly =  true;
            }
        }

        */
    }
}
