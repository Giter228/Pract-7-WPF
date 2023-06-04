using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_8_Practos_MVVM.ViewModel.Helpers;

namespace WPF_8_Practos_MVVM.Model
{
    internal class FabricFromCheck : PropertyChangedHelper
    {
        private string name;
        private string size;
        private int amount;

        /* public string Name { get; set; }
        public string Size { get; set; }
        public int Amount { get; set; }*/
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public FabricFromCheck(string name, string size, int amount)
        {
            Name = name;
            Size = size;
            Amount = amount;
        }
        public FabricFromCheck() { }
    }
}
