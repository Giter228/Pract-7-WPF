using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_8_Practos_MVVM.Model
{
    internal class Fabrics
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Amount { get; set; }
        public Fabrics(string name, string size, string amount)
        {
            Name = name;
            Size = size;
            Amount = amount;
        }
        public Fabrics() { }
    }
}
