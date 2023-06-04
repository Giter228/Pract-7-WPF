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
using WPF_8_Practos_MVVM.ViewModel;

namespace WPF_8_Practos_MVVM
{
    /// <summary>
    /// Логика взаимодействия для BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        public BuyerWindow()
        {
            InitializeComponent();
            DataContext = new CartViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CartViewModel();
        }
    }
}
