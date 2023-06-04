using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_8_Practos_MVVM.Model;

namespace WPF_8_Practos_MVVM.ViewModel
{
    internal class FabricToCheck
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Cost { get; set; }
        public FabricToCheck(string name, string size, int cost)
        {
            Name = name;
            Size = size;
            Cost = cost;
        }
        public FabricToCheck(FabricFromCheck selected)
        {
            Name = selected.Name;
            Size = selected.Size;
        }
        public FabricToCheck() { }
    }
}
