using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProducts
{
    public struct Product
    {
        int _price;
        int _cost;
        public string Name { get; set; }
        public int Price { get => _price; set => _price = ProveValue(value) ? value : throw new Exception("Значение меньше нуля"); }
        public int Cost { get => _cost; set => _cost = ProveValue(value) ? value : throw new Exception("Значение меньше нуля"); }
        private bool ProveValue(int value)
        {
            if (value >= 0) return true;
            return false;
        }
        public void EnterInfoAboutProduct(string name, int price, int cost)
        {
            Name = name;
            Price = price;
            Cost = cost;
        }
    }
}
