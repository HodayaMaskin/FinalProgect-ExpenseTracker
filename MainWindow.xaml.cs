using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntity context = new NorthwindEntity();
        Personal personal = new Personal();

        public MainWindow()
        {
            InitializeComponent();

            var listCity = from p in context.Cities select p.NameCity;
            ObservableCollection<string> cities = new ObservableCollection<string>(listCity);
            lstCities.DataContext = cities;

            var listStatus = from p in context.Status select p.NameStatus;
            ObservableCollection<string> status = new ObservableCollection<string>(listStatus);
            lstStatus.DataContext = status;

            numChildren.Visibility = Visibility.Hidden;
            lblNumChildren.Visibility = Visibility.Hidden;

        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {


        
            if (personalIDTextBox.Text != null && personalIDTextBox.Text != "")
            {
                var list = from p in context.Personals select p;
                ObservableCollection<Personal> personals = new ObservableCollection<Personal>(list);
                Personal personal = new Personal();
                foreach (var per in personals)
                {
                    if (per.UserID == int.Parse(personalIDTextBox.Text))
                    {
                        MainPersonal newForm = new MainPersonal(); //create your new form.
                        this.Hide();
                        newForm.Show(); //show the new form
                        //var newForm = new MainPersonal(per); //create your new form.
                        ////var newForm = new MainPerson(int.Parse(personalIDTextBox.Text)); //create your new form.
                        //newForm.Show(); //show the new form
                    }
                }
            }
            else
            {
                //
                MessageBox.Show("personal ID is not valid");
            }

           

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(personal.Gender!=1 && personal.Gender!=2)
            {
                MessageBox.Show("Gender Required");
                return;
            }

            if ((Regex.IsMatch(personalId.Text, "[^0-9]+")) || personalId.Text==null || personalId.Text=="" || personalId.Text.Length>9)
            {
                MessageBox.Show("personal ID is not valid");
                return;
            }

            if (Regex.IsMatch(firstName.Text, "[^a-zA-Z]+") || firstName.Text == null || firstName.Text == "")
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                return;
            }

            if (Regex.IsMatch(lastName.Text, "[^a-zA-Z]+") || lastName.Text == null || lastName.Text == "")
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                return;
            }

            if (Regex.IsMatch(age.Text, "[^0-9]+") || age.Text == null || age.Text == "")
            {
                MessageBox.Show("age is not valid");
                return;
            }

            if (Regex.IsMatch(numChildren.Text, "[^0-9]+") || numChildren.Text == null || numChildren.Text == "")
            {
                MessageBox.Show("num children is not valid");
                return;
            }

            if (personalId.Text != null && personalId.Text != "")
            {
                var list = from p in context.Personals select p;
                ObservableCollection<Personal> personals = new ObservableCollection<Personal>(list);
                //Personal personal = new Personal();

                foreach (var per in personals)
                {
                    if (per.UserID == int.Parse(personalId.Text))
                    {
                        MessageBox.Show("personal ID is exit");
                        return;
                        //var newForm = new MainPersonal(per); //create your new form.
                        ////var newForm = new MainPerson(int.Parse(personalIDTextBox.Text)); //create your new form.
                        //newForm.Show(); //show the new form
                    }
                }

                
                

                try
                {
                    personal.UserID = int.Parse(personalId.Text);
                    personal.FirstName = firstName.Text;
                    personal.LastName = lastName.Text;
                    personal.Age = float.Parse(age.Text);
                    personal.Children = int.Parse(numChildren.Text);
                    //personal.Gender = personal.Gender;
                    // Refresh the grids so the database generated values show up.
                    //this.p.Items.Refresh();
                    //this.productsDataGrid.Items.Refresh();

                    context.Personals.Add(personal);
                    context.SaveChanges();

                    MainPersonal newForm = new MainPersonal(); //create your new form.
                    this.Hide();
                    newForm.Show(); //show the new form
                }
                catch (DbEntityValidationException eee)
                {
                    MessageBox.Show(eee.EntityValidationErrors.ToString());
                }

            }
            else
            {
                //
                MessageBox.Show("personal ID is not valid");
            }

           

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioExit.IsChecked == true)
            {
                radioNew.IsChecked = false;
                btnAdd.IsEnabled = false;
                btnConnect.IsEnabled = true;
                
            }
            if(radioNew.IsChecked == true)
            {
                radioExit.IsChecked = false;
                btnAdd.IsEnabled = true;
                btnConnect.IsEnabled = false;
            }
            
        }

        private void lstCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       
            personal.CityId= int.Parse(this.lstCities.SelectedIndex.ToString()) + 1;
        }

        private void lstStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index= int.Parse(this.lstStatus.SelectedIndex.ToString()) + 1;
            personal.Status = index;
            if (index == 2 || index == 3)
            {
                numChildren.Visibility = Visibility.Visible;
                lblNumChildren.Visibility = Visibility.Visible;
            }
        }

        private void radioGender_Checked(object sender, RoutedEventArgs e)
        {
            if (radioMan.IsChecked == true)
            {
                radioWife.IsChecked = false;
                personal.Gender = 1;
            }
            if (radioWife.IsChecked == true)
            {
                radioMan.IsChecked = false;
                personal.Gender = 2;
            }
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
