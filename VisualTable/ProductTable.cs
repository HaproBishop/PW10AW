using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProducts;

namespace VisualTable
{/// <summary>
/// Класс для занесения данных в таблицу (тесно связан с Product классом)
/// </summary>
    public static class ProductTable
    {
        static DataTable res;
        public static DataTable ToDataTable(List<Product> products)
        {
            res = new DataTable();
            res.Columns.Add("№", typeof(string));
            res.Columns.Add("Продукт", typeof(string));
            res.Columns.Add("Цена", typeof(int));
            res.Columns.Add("Затраты", typeof(int));
            for (int i = 0; i < products.Count; i++)
            {
                DataRow row = res.NewRow();
                row[0] = (i + 1).ToString();
                row[1] = products[i].Name;
                row[2] = products[i].Price;
                row[3] = products[i].Cost;
                res.Rows.Add(row);
            }
            return res;
        }
    }
}
