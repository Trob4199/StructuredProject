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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Models;
using CKK.UI;
using CKK.Persistance.Models;
using CKK.Logic.Interfaces;
using CKK.Logic.Repository.InMemory;


namespace StructuredProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IStore Store;
        
        public MainWindow()
        {
            DatabaseConnectionFactory conn = new DatabaseConnectionFactory();
            ProductRepository prodrepo = new ProductRepository(conn);
            Store = new DataStore(prodrepo);

            InitializeComponent();
        }

        private void AddItembutton_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItem = new AddItemWindow(Store);
            addItem.Show();

        }

        private void InventoryItembutton_Click(object sender, RoutedEventArgs e)
        {
            
            InventoryManagementForm inven = new InventoryManagementForm(Store);
            inven.Show();
 
        }

        private void RemoveItembutton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItemWindow removeItem = new RemoveItemWindow(Store);
            removeItem.Show();
        }

        private void SearchByItembutton_Click(object sender, RoutedEventArgs e)
        {
            ProductSearchForm search = new ProductSearchForm(Store);
            search.Show();
        }
    }
}
