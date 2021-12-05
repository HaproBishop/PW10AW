using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryProducts;
using VisualTable;

namespace PW10AW
{
    /// <summary>
    /// By Hapro Bishop
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Product> _productlist = new List<Product>();
        Product _addingproduct;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №10. Задание №1. В первом одномерном массиве" +
                " хранятся затраты на производство продуктов, во втором - цены на эти продукты. Указать номер первого продукта," +
                " затраты на производство которого превышают цены.", "О программе", MessageBoxButton.OK,
                 MessageBoxImage.Information);
        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1) В программе используется List, где хранится значение (экземпляр объекта структуры \"Product\")\n" +
                "2) Также нельзя вводить больше шестизначного числа\n" +
                "3) Может быть введено символов в имя продуктов максимум - 14", "Справка", MessageBoxButton.OK,
                MessageBoxImage.Question);
        }

        private void ClearList_Click(object sender, RoutedEventArgs e)
        {            
            ProductList.ItemsSource = null;
            _productlist.Clear();
            IdResult.Clear();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _addingproduct.EnterInfoAboutProduct(ProductName.Text, Convert.ToInt32(Price.Text), Convert.ToInt32(Cost.Text));
                _productlist.Add(_addingproduct);
                ProductList.ItemsSource = ProductTable.ToDataTable(_productlist).DefaultView;
                IdResult.Clear();
            }
            catch
            {
                MessageBox.Show("Введите корректно значения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FindProductPriceLessCost_Click(object sender, RoutedEventArgs e)
        {
            bool wasbreak = false;
            for (int i = 0; i < _productlist.Count; i++)
            {
                if (_productlist[i].Cost > _productlist[i].Price)
                {
                    IdResult.Text = (i + 1).ToString();
                    wasbreak = true;
                    break;
                }
            }
            if (!wasbreak) MessageBox.Show("К сожалению, не было найдено продукта, у которого затраты превышают цену", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
