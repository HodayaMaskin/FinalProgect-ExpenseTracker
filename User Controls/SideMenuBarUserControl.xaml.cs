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

namespace WpfApp2.User_Controls
{
    /// <summary>
    /// Interaction logic for SideMenuBarUserControl.xaml
    /// </summary>
    public partial class SideMenuBarUserControl : UserControl
    {
        NorthwindEntity context = new NorthwindEntity();
        public SideMenuBarUserControl()
        {
            //InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new MainWindow();
            homeWindow.Show();
            //var myWindow = (Window)VisualParent.GetSelfAndAncestors().FirstOrDefault(a => a is Window);
            //myWindow.Close();
            var oldHomeWindow = Window.GetWindow(this);
            oldHomeWindow.Close();
            
        }
    }
}
