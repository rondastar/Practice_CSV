using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Resolvers;
using CsvHelper;

namespace Practice_CSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CoffeeMug> coffeeMugs = new List<CoffeeMug>();
        const string filePath = "coffeeMugs.csv";
        public MainWindow()
        {
            InitializeComponent();
            Preload();

            coffeeMugs = LoadCSV<CoffeeMug>(filePath);

            lvDisplay.ItemsSource = coffeeMugs;
           
        }

        public void Preload()
        {
            // Populates the _mugs list with 5 mugs
            coffeeMugs.Add(new CoffeeMug("classic", "maroon", "ceramic"));
            coffeeMugs.Add(new CoffeeMug("2 separate fingers", "green", "ceramic"));
            coffeeMugs.Add(new CoffeeMug("classic", "blue", "metal"));
            coffeeMugs.Add(new CoffeeMug("classic", "grey","tin"));
            coffeeMugs.Add(new CoffeeMug("handwarmer", "black", "ceramic"));

            SaveData<CoffeeMug>(filePath, coffeeMugs);
        }

        // Saves data to CSV file
        public void SaveData<T>(string filePath, List<T> list)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(list);
                writer.Flush();
            }
        }

        // loads data from CSV file
        public List<T> LoadCSV<T>(string filePath)
        {
            List<T> temp = new List<T>();

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                temp = csv.GetRecords<T>().ToList();
            }
            return temp;
        }

        private void btnAddMug_Click(object sender, RoutedEventArgs e)
        {
            string newMugHandle = txtHandle.Text;
            string newMugColor = txtColor.Text;
            string newMugMaterial = txtMaterial.Text;

            coffeeMugs.Add(new CoffeeMug(newMugHandle, newMugColor, newMugMaterial));
            lvDisplay.Items.Refresh();
        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            LoadCSV<CoffeeMug>(filePath);
        }

        private void btnSaveListToCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveData<CoffeeMug>(filePath, coffeeMugs);
        }
    } // class
} // namespace
