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
        public int Id { get; set; }
        public string Meno { get; set; }
        public string Nazov { get; set; }
        public string Miesto { get; set; }
        public int Kusy { get; set; }
        public Item(int id, string meno, string nazov, string miesto, int kusy)
        {
            Id = id;
            Meno = meno;
            Nazov = nazov;
            Miesto = miesto;
            Kusy = kusy;
                
        }
        

    }
}
