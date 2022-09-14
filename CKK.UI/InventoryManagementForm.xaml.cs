using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Collections.ObjectModel;
using System.Windows;


namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for InventoryManagementForm.xaml
    /// </summary>
    public partial class InventoryManagementForm : Window
    {
        private IStore _Store;

        public ObservableCollection<Product> _Items { get; private set; }

        public InventoryManagementForm(IStore store)
        {
            _Store = store;
            InitializeComponent();
            _Items = new ObservableCollection<Product>();
            lvProduct.ItemsSource = _Items;
            RefreshList();



        }

        private void RefreshList()
        {
            _Items.Clear();
            foreach (Product product in new ObservableCollection<Product>(_Store.GetAllProducts()))
                _Items.Add(product);
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
            decimal price = 0;  
            itemstemp = _Store.GetProductsByPrice(price);
            _Items = new ObservableCollection<Product>(itemstemp);
            lbInventoryList.ItemsSource = _Items;
            */
        }
    }
}
