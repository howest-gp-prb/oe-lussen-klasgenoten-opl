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

namespace Prb.LussenKlasgenoten.Wpf
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
        List<string> classMates;
        List<string> filterResult;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classMates = new List<string>();
            filterResult = new List<string>();
            PopulateCombobox();
            doStats();
        }
        private void PopulateCombobox()
        {
            for(int r = 1; r <= 10; r++)
            {
                cmbCharacters.Items.Add(r);
            }
            cmbCharacters.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtClassMate.Text.Trim();
            if (name.Length > 0)
            {
                classMates.Add(name);
                PopulateListboxes();
                doStats();
                txtClassMate.Text = "";
                txtClassMate.Focus();
            }
  

        }
        private void PopulateListboxes()
        {
            lstClassMates.ItemsSource = null;
            lstFilter.ItemsSource = null;

            lstClassMates.ItemsSource = classMates;
            lstFilter.ItemsSource = filterResult;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int nrOfCharacters = int.Parse(cmbCharacters.SelectedItem.ToString());
            filterResult.Clear();
            foreach(string classMate in classMates)
            {
                if(classMate.Length == nrOfCharacters)
                {
                    filterResult.Add(classMate);
                }
            }
            PopulateListboxes();
        }
        private void doStats()
        {
            lstStats.Items.Clear();
            for (int r = 1; r <= 10; r++)
            {
                int counter = 0;
                foreach (string classMate in classMates)
                {
                    if (classMate.Length == r)
                    {
                        counter++;
                    }
                }
                lstStats.Items.Add($"{counter} klasgenoten met {r} letters");
            }
        }
    }
}
