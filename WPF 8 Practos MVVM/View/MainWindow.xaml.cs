using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_8_Practos_MVVM.BD_for_WPF_Pract_7DataSetTableAdapters;

namespace WPF_8_Practos_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static roles_dataTableAdapter roles_data = new roles_dataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Authorization_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (Login_BX.Text.Trim() == "" || Password_BX.Password.Trim() == "")
            {
                ErrorSign.Text = "Не все поля заполнены.";
                return;
            }

            var alllogins = roles_data.GetData().Rows;
            int counter = 1;
            for (int i = 0; i < alllogins.Count; i++)
            {
                if (alllogins[i][1].ToString() == Login_BX.Text.Trim() &&
                    alllogins[i][2].ToString() == Password_BX.Password)
                {
                    int roleID = (int)alllogins[i][3];

                    switch (roleID)
                    {
                        case 1:
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            Close();
                            break;

                        case 2:
                            BuyerWindow buyerWindow = new BuyerWindow();
                            buyerWindow.Show();
                            Close();
                            break;
                    }

                }
                if (counter == alllogins.Count)
                {
                    ErrorSign.Text = "Пользователь не найден.";
                }
                counter++;
            }

        }
    }
}
