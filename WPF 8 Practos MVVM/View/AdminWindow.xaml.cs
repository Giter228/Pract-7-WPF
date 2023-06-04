using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WPF_8_Practos_MVVM.BD_for_WPF_Pract_7DataSetTableAdapters;
using WPF_8_Practos_MVVM.ViewModel;

namespace WPF_8_Practos_MVVM
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Tab_Control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*TabItem selected_tab = (TabItem)Tab_Control.SelectedItem;*/
            var selectedTab = e.AddedItems[0] as TabItem;
            if (selectedTab != null)
            {
                switch (selectedTab.Header.ToString())
                {
                    case "Пользователи":
                        DataContext = null;
                        DataContext = new UsersViewModel();
                        break;

                    case "Изделия":
                        DataContext = null;
                        DataContext = new FabricsViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
