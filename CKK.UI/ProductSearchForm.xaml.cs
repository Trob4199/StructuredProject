using System;
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
using System.Windows.Shapes;
using CKK.Logic.Models;
using System.Collections.ObjectModel;
using CKK.Persistance.Models;
using CKK.Logic.Interfaces;
using CKK.Logic.Repository.InMemory;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for InventoryManagementForm.xaml
    /// </summary>
    public partial class ProductSearchForm : Window
    {
        private IStore _Store;

        public ObservableCollection<Product> _Items { get; private set; }

        public ProductSearchForm(IStore store)
        {
            
            _Store = store;
            InitializeComponent();

        }

        private void RefreshList()
        {
            _Items.Clear();
            foreach (Product prod in new ObservableCollection<Product>(_Store.GetAllProducts()))
                _Items.Add(prod);
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void qtySortButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            List<Product> itemstemp = new List<Product>();
            itemstemp = _Store.GetProductsByQuantity();
            _Items = new ObservableCollection<Product>(itemstemp);
            lbInventoryList.ItemsSource = _Items;
            */

        }

        private void priceSortButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            List<Product> itemstemp = new List<Product>();
            itemstemp = _Store.GetProductsByPrice();
            _Items = new ObservableCollection<Product>(itemstemp);
            lbInventoryList.ItemsSource = _Items;
            */
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            
            string searchtext = Searchbox.Text;
            List<Product> itemstemp = new List<Product>();
            itemstemp = _Store.GetProductsByName(searchtext);
            _Items = new ObservableCollection<Product>(itemstemp);
            lbInventoryList.ItemsSource = _Items;
            
        }
    }
}
