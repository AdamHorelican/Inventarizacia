using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Invetarizácia
{
    internal class Item
    {
        public string Meno { get; set; }
        public string Nazov { get; set; }
        public string Miesto { get; set; }
        public string Kusy { get; set; }
        public Item(string meno, string nazov, string miesto, string kusy)
        {
            Meno = meno;
            Nazov = nazov;
            Miesto = miesto;
            Kusy = kusy;
        }

    }
}
