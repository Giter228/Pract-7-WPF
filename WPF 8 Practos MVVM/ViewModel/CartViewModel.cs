using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_8_Practos_MVVM.Model;
using WPF_8_Practos_MVVM.ViewModel.Helpers;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WPF_8_Practos_MVVM.ViewModel
{
    internal class CartViewModel : PropertyChangedHelper
    {
        #region Properties

        #region First
        private FabricFromCheck selectedFabric = new FabricFromCheck();
        public FabricFromCheck SelectedFabric
        {
            get { return selectedFabric; }
            set
            {
                selectedFabric = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<FabricFromCheck> _firstDataGridItems;
        public ObservableCollection<FabricFromCheck> FirstDataGridItems
        {
            get { return _firstDataGridItems; }
            set
            {
                _firstDataGridItems = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Second
        private FabricToCheck selectedFabric2 = new FabricToCheck();
        public FabricToCheck SelectedFabric2
        {
            get { return selectedFabric2; }
            set
            {
                selectedFabric2 = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<FabricToCheck> _secondDataGridItems;
        public ObservableCollection<FabricToCheck> SecondDataGridItems
        {
            get { return _secondDataGridItems; }
            set
            {
                _secondDataGridItems = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region GeneralPrice
        private int price { get; set; } = 0;
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region PaidByUser
        private string paid { get; set; }
        public string Paid
        {
            get { return paid; }
            set
            {
                paid = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion
        #region Commands
        public ICommand AddItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand WriteCheckCommand { get; set; }
        #endregion

        bool isDeleted = false;
        bool existsInFirstGrid = false;
        public CartViewModel()
        {
            AddItemCommand = new BindableCommand(_ => AddFabric());
            DeleteItemCommand = new BindableCommand(_ => DeleteFabric());
            WriteCheckCommand = new BindableCommand(_ => WriteCheck());

            FirstDataGridItems = new ObservableCollection<FabricFromCheck>()
            {
                new FabricFromCheck("Стол", "500", 15),
                new FabricFromCheck("Комод", "500", 35),
                new FabricFromCheck("Стул", "500", 25),
                new FabricFromCheck("Табурет", "543", 15),
                new FabricFromCheck("Шкаф", "345", 10),
                new FabricFromCheck("Диван", "565", 4),
                new FabricFromCheck("Столешница", "3545", 7)
            };
            SecondDataGridItems = new ObservableCollection<FabricToCheck>();
        }

        public void AddFabric()
        {
            if (SelectedFabric == null) return;

            FabricToCheck item = new FabricToCheck(SelectedFabric);
            item.Cost = SetPrice();
            SecondDataGridItems.Add(item);
            existsInFirstGrid = true;

            for (int x = 0; x <= FirstDataGridItems.Count - 1; x++)
            {
                if ((SecondDataGridItems[SecondDataGridItems.Count - 1].Name == FirstDataGridItems[x].Name) &&
                    (SecondDataGridItems[SecondDataGridItems.Count - 1].Size == FirstDataGridItems[x].Size))
                {
                    int number = Convert.ToInt32(FirstDataGridItems[x].Amount);
                    number -= 1;
                    if (number == 0)
                    {
                        existsInFirstGrid = false;
                        FirstDataGridItems.RemoveAt(x);
                        return;
                    }

                    FirstDataGridItems[x].Amount = number;
                    SelectedFabric = null;
                    return;
                }
            }
        }
        private int SetPrice()
        {
            Random rnd = new Random();
            int somePrice = rnd.Next(5000, 8000);
            Price += somePrice;
            return somePrice;
        }

        public void DeleteFabric()
        {
            if (SelectedFabric2 == null) return;

            for (int x = SecondDataGridItems.Count - 1; x >= 0; x--)
            {
                if (isDeleted)
                {
                    SelectedFabric2 = null;
                    isDeleted = !isDeleted;
                    return;
                }

                for (int y = 0; y < FirstDataGridItems.Count; y++)
                {
                    if (SecondDataGridItems[x].Name == FirstDataGridItems[y].Name &&
                        SecondDataGridItems[x].Size == FirstDataGridItems[y].Size &&
                        SelectedFabric2.Cost == SecondDataGridItems[x].Cost)
                    {
                        Price -= SecondDataGridItems[x].Cost;
                        if (existsInFirstGrid)
                        {
                            FirstDataGridItems[y].Amount += 1;
                        }
                        else
                        {
                            FirstDataGridItems.Add(new FabricFromCheck(SelectedFabric2.Name, SelectedFabric2.Size, 1));
                        }
                        isDeleted = true;
                        SecondDataGridItems.RemoveAt(x);
                        return;
                    }
                }
            }
        }
        public void WriteCheck()
        {
            int returned = 0;
            int wasPaid;
            try
            {  wasPaid = Convert.ToInt32(Paid); }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода уплаченной суммы");
                return;
            }
            if (wasPaid < 0)
            {
                MessageBox.Show("Сумма не может быть отрицательной");
                return;
            }
            else if (wasPaid < Price)
            {
                MessageBox.Show("Вы не можете оплатить меньше, чем заявленная цена");
                return;
            }
            else if (wasPaid == Price) returned = 0;
            else if (wasPaid > Price) returned = wasPaid - Price;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExtension = "txt";
            dialog.Filters.Add(new CommonFileDialogFilter("Text Files", "*.txt"));
            dialog.EnsurePathExists = true;
            dialog.EnsureReadOnly = false;
            dialog.EnsureValidNames = true;


            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string fileName = dialog.FileName;

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("\nMebel.ru - Мебель по заказ. Самое лучшее - здесь!\n\tКассовый чек\n");
                    foreach (FabricToCheck item in SecondDataGridItems)
                    {
                        writer.WriteLine($"\t{item.Name}  -  {item.Cost}");
                    }

                    writer.WriteLine($" Итого к оплате: {Price}");
                    writer.WriteLine($" Оплачено: {paid}");
                    writer.WriteLine($" Сдача: {returned}");
                }
            }
            MessageBox.Show("Чек выписан");
        }
    }
}