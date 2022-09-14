using CKK.Logic.Interfaces;
using CKK.Logic.Repository.InMemory;
using CKK.Logic.Repository.Interfaces;
using CKK.UI;
using System.Windows;

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
            IProductRepository Prodrepo = new ProductRepository(conn);
            Store = new DataStore(Prodrepo);

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

        private void EditItembutton_Click(object sender, RoutedEventArgs e)
        {
            ProductEditForm edit = new ProductEditForm(Store);
            edit.Show();

        }
    }
}
