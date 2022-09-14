using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

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
