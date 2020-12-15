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

namespace scala.LussenOefening3.Wpf
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

        List<string> namen;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            namen = new List<string>();
            Seeding();
            VulListbox();
            lblFout.Visibility = Visibility.Hidden;
        }
        private void Seeding()
        {
            namen.Add("Jan");
            namen.Add("Piet");
            namen.Add("Joris");
            namen.Add("Corneel");
        }
        private void VulListbox()
        {
            lstNamen.Items.Clear();
            namen.Sort();
            foreach(string naam in namen)
            {
                lstNamen.Items.Add(naam);
            }
        }
        private void lstNamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNaam.Text = "";
            lblFout.Visibility = Visibility.Hidden;
            if (lstNamen.SelectedItem != null)
            {
                txtNaam.Text = lstNamen.SelectedItem.ToString();
            }
        }
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            lblFout.Visibility = Visibility.Hidden;
            string nieuweNaam = txtNaam.Text.Trim();
            if (nieuweNaam.Length == 0)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Je kan geen lege naam toevoegen !";
                return;
            }
            bool gevonden = false;
            foreach(string naam in namen)
            {
                if(nieuweNaam.ToUpper() == naam.ToUpper())
                {
                    gevonden = true;
                    break;
                }
            }
            if(gevonden)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Naam reeds in gebruik : NIET toegevoegd !";
                return;
            }
            namen.Add(nieuweNaam);
            VulListbox();
            lstNamen.SelectedItem = nieuweNaam;
            txtNaam.Focus();
            txtNaam.SelectAll();
        }

        private void btnBijwerken_Click(object sender, RoutedEventArgs e)
        {
            lblFout.Visibility = Visibility.Hidden;
            if(lstNamen.SelectedItem == null)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Je dient eerst een naam te selecteren !";
                return;
            }
            string nieuweNaam = txtNaam.Text.Trim();
            if (nieuweNaam.Length == 0)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Je kan geen lege naam gebruiken !";
                return;
            }
            string oudeNaam = lstNamen.SelectedItem.ToString();
            bool gevonden = false;
            foreach (string naam in namen)
            {
                if (nieuweNaam.ToUpper() == naam.ToUpper() && naam.ToUpper() != oudeNaam.ToUpper())
                {
                    gevonden = true;
                    break;
                }
            }
            if (gevonden)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Naam reeds in gebruik : NIET gewijzigd !";
                txtNaam.Text = oudeNaam;
                return;
            }
            for(int r = 0; r < namen.Count; r++)
            {
                if(namen[r].ToUpper() == oudeNaam.ToUpper())
                {
                    namen[r] = nieuweNaam;
                    break;
                }
            }
            VulListbox();
            lstNamen.SelectedItem = nieuweNaam;
            txtNaam.Focus();
            txtNaam.SelectAll();

        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            lblFout.Visibility = Visibility.Hidden;
            if (lstNamen.SelectedItem == null)
            {
                lblFout.Visibility = Visibility.Visible;
                lblFout.Content = "Je dient eerst een naam te selecteren !";
                return;
            }
            string teWissenNaam = lstNamen.SelectedItem.ToString();
            for (int r = 0; r < namen.Count; r++)
            {
                if (namen[r].ToUpper() == teWissenNaam.ToUpper())
                {
                    namen.RemoveAt(r);
                    break;
                }
            }
            VulListbox();
            txtNaam.Text = "";
            txtNaam.Focus();
        }


    }
}
