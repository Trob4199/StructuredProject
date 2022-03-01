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

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for InventoryManagementForm.xaml
    /// </summary>
    public partial class InventoryManagementForm : Window
    {
        private IStore _Store;

        public ObservableCollection<StoreItem> _Items { get; private set; }

        public InventoryManagementForm(FileStore store)
        {
            _Store = store;
            InitializeComponent();
            _Items = new ObservableCollection<StoreItem>();
            lbInventoryList.ItemsSource = _Items;
            RefreshList();

            

        }

        private void RefreshList()
        {
            _Items.Clear();
            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems()))
                _Items.Add(si);
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void qtySortButton_Click(object sender, RoutedEventArgs e)
        {
            List<StoreItem> itemstemp = new List<StoreItem>();
            itemstemp = _Store.GetProductsByQuantity();
            _Items = new ObservableCollection<StoreItem>(itemstemp);
            lbInventoryList.ItemsSource = _Items;


        }

        private void priceSortButton_Click(object sender, RoutedEventArgs e)
        {
            List<StoreItem> itemstemp = new List<StoreItem>();
            itemstemp = _Store.GetProductsByPrice();
            _Items = new ObservableCollection<StoreItem>(itemstemp);
            lbInventoryList.ItemsSource = _Items;
        }
    }
}
