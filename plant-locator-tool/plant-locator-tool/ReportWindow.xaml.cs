using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
using MySql.Data.MySqlClient;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private string _docPath = Environment.CurrentDirectory;
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void plantsByCreationDateButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand("SELECT plantID, plantName, creationDate FROM plant_location ORDER BY creationDate DESC", connection);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            reportDataGrid.DataContext = dt;
            reportDataGrid.ItemsSource = dt.DefaultView;

        }

        private void numberOfPlantsByUserButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand("SELECT createdBy, COUNT(*) AS numPlantsCreated FROM plant_location GROUP BY createdBy", connection);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            reportDataGrid.DataContext = dt;
            reportDataGrid.ItemsSource = dt.DefaultView;

        }


        private void exportCSVButton_Click(object sender, RoutedEventArgs e)
        {

            if (reportDataGrid.Items.Count != 0)
            {


                reportDataGrid.SelectAllCells();
                reportDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, reportDataGrid);
                reportDataGrid.UnselectAllCells();

                string result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);

                try
                {

                    StreamWriter streamWriter = new StreamWriter("reportdata.csv");
                    streamWriter.WriteLine(result);
                    streamWriter.Close();
                    Process.Start("reportdata.csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            else
            {
                return;
            }
            
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
