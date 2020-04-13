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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace drankregrestratie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        drankregrestratie db = new drankregrestratie();
        public MainWindow()
        {
            InitializeComponent();
            dgdrank.ItemsSource = db.items.ToList();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            Naam deNaam = new Naam();
            deNaam.Naam = txtboxnaam.Text

            db.items.InsertOnSubmit(deNaam);

            db.SubmitChanges();

            dgItems.ItemsSource = db.items.ToList();
        }

        private void btnzoek_Click(object sender, RoutedEventArgs e)
        {
            string sWaarde = txtzoek.Text;

            var lijst = db.items.Where(p => p.itemnaam.Contains(sWaarde)).ToList();
            dgItems.ItemsSource = lijst;
        }
    }
}
