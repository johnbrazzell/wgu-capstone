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

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for EditPlantWindow.xaml
    /// </summary>
    public partial class EditPlantWindow : Window
    {
        public EditPlantWindow(ViewPlantsWindow window, Plant plant)
        {
            InitializeComponent();
            //need to split address string
            //consider moving address to its own database
            //address format order
            //street, city, state, zip
            string[] splitAddress = plant.PlantAddress.Split(' ');

            //fill form with values
            plantNameTextbox.Text = plant.PlantName;
            phoneNumberTextbox.Text = plant.PhoneNumber;
            productsProducedTextbox.Text = plant.ProductionInformation;
            streetTextbox.Text = splitAddress[0];
            cityTextbox.Text = splitAddress[1];
            stateTextbox.Text = splitAddress[2];
            zipTextBox.Text = splitAddress[3];

        }

        private void updatePlantbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillForm()
        {

        }
    }
}
