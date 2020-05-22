using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainPersonal.xaml
    /// </summary>
    public partial class MainPersonal : Window
    {
        NorthwindEntity context = new NorthwindEntity();
        public MainPersonal(Personal personal)
        {
            InitializeComponent();

            var listCity = from p in context.Cities select p.NameCity;
            ObservableCollection<string> cities = new ObservableCollection<string>(listCity);
          //  lstDishes.ItemsSource = listCity;
            //lstDishes.DisplayMemberPath = "Description";

            var listStatus = from p in context.Status select p.NameStatus;
            ObservableCollection<string> statuses = new ObservableCollection<string>(listStatus);
           // lstDishes.ItemsSource = listCity;
            //lstDishes.DisplayMemberPath = "Description";
        }

        public MainPersonal()
        {
            InitializeComponent();
           
            //cmbColors.ItemsSource = typeof(Colors).GetProperties();
            var list = from p in context.Cities select p.NameCity;
            ObservableCollection<string> cities = new ObservableCollection<string>(list);
            //lstDishes.DataContext = cities;

           
            
        }

        private void lstDishes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int index = int.Parse(this.lstDishes.SelectedIndex.ToString()) + 1;
                //Items.IndexOf(e.GetType());
            //sender.GetHashCode();
            //MessageBox.Show(e.GetType().ToString());
            //MessageBox.Show( sender.GetType().Name.ToString());
            //var Selected = lstDishes.SelectedItem as  ;
            //MessageBox.Show("You selected: " + Selected.Description));
        }

        private void Add_Revenue(object sender, RoutedEventArgs e)
        {
           
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SideMenuBarUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
