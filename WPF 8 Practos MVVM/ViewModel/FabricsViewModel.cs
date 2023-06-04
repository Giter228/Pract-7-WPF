using System.Collections.ObjectModel;
using System.Linq;
using WPF_8_Practos_MVVM.Model;
using WPF_8_Practos_MVVM.ViewModel.Helpers;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using System.Windows;

namespace WPF_8_Practos_MVVM.ViewModel
{
    internal class FabricsViewModel : PropertyChangedHelper
    {
        #region Properties
        private Fabrics selectedFabric = new Fabrics();
        public Fabrics SelectedFabric
        {
            get
            {
                return selectedFabric;
            }
            set
            {
                selectedFabric = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Fabrics> fabrics = new ObservableCollection<Fabrics>();
        public ObservableCollection<Fabrics> Fabrics
        {
            get { return fabrics; }
            set
            {
                fabrics = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public BindableCommand AddCommand { get; set; }
        public ICommand CloseCommand { get; }
        #endregion 

        public FabricsViewModel()
        {
            AddCommand = new BindableCommand(_ => AddSomebody());
            CloseCommand = new RelayCommand(CloseWindow);

            Fabrics = new ObservableCollection<Fabrics>()
            {
                new Fabrics("Стол", "600", "75"),
                new Fabrics("Комод", "333", "175"),
                new Fabrics("Стул", "250", "32"),
                new Fabrics("Табурет", "758", "54"),
                new Fabrics("Шкаф", "852", "83"),
                new Fabrics("Диван", "231", "375"),
                new Fabrics("Столешница", "120", "9")
            };

        }

        public void AddSomebody()
        {
            if (string.IsNullOrEmpty(SelectedFabric.Name) || string.IsNullOrEmpty(SelectedFabric.Size.ToString()) || string.IsNullOrEmpty(SelectedFabric.Amount.ToString()))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            Fabrics.Add(SelectedFabric);

            SelectedFabric = new Fabrics();

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
