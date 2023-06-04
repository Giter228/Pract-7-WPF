using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WPF_8_Practos_MVVM.ViewModel.Helpers;
using Microsoft.Toolkit.Mvvm.Input;

namespace WPF_8_Practos_MVVM.ViewModel
{
    internal class UsersViewModel : PropertyChangedHelper
    {
        #region Properties
        private Users selectedUser = new Users();
        public Users SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Users> users = new ObservableCollection<Users>();
        public ObservableCollection<Users> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public BindableCommand AddCommand { get; set; }
        public ICommand CloseCommand { get; }
        #endregion 
        public UsersViewModel()
        {
            AddCommand = new BindableCommand(_ => AddSomebody());
            CloseCommand = new RelayCommand(CloseWindow);

            Users = new ObservableCollection<Users>()
            {
                new Users("admin", "admin", "Администратор"),
                new Users("buyer", "buyer", "Покупатель")
            };
        }

        public void AddSomebody()
        {
            if (string.IsNullOrEmpty(SelectedUser.Login) || string.IsNullOrEmpty(SelectedUser.Password) || string.IsNullOrEmpty(SelectedUser.RoleName))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            Users.Add(SelectedUser);

            SelectedUser = new Users();

            OnPropertyChanged();
        }

        private void CloseWindow()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.IsActive);
            if (currentWindow != null)
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;

                currentWindow.Close();
                mainWindow.Show();
            }
        }
    }
}
