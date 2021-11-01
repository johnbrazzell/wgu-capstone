using Microsoft.Maps.MapControl.WPF;
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
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        //Chose the map start location to center on the middle of the U.S.  
        Location startLocation = new Location(44.967243, -103.77155);

        public MapWindow()
        {
            InitializeComponent();
            mainMap.SetView(startLocation, 3.0);

            //Pushpin testPin = new Pushpin();
            //testPin.Location = startLocation;
            //testPin.ToolTip = "Test";
            //mainMap.Children.Add(testPin);
            
           
        }

        private void addPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Create add plant window
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
        }
    }
}
