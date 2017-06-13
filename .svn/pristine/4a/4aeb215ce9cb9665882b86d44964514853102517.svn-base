using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISANotifications
{
    /// <summary>
    /// Interaction logic for dummy.xaml
    /// </summary>
    public partial class dummy : Page
    {
        public dummy()
        {
            InitializeComponent(); 
            Loaded += Dummy_Loaded;

        }

        private void Dummy_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ManageNotifications.xaml", UriKind.Relative));
        }
    }
}
