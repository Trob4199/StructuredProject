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
            Store = new FileStore();
            InitializeComponent();
        }

        private void AddItembutton_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItem = new AddItemWindow();
            addItem.Show();

        }

        private void InventoryItembutton_Click(object sender, RoutedEventArgs e)
        {
            FileStore tp = (FileStore)Application.Current.FindResource("globStore");
            InventoryManagementForm inven = new InventoryManagementForm(tp);
            inven.Show();
 
        }

        private void RemoveItembutton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItemWindow removeItem = new RemoveItemWindow();
            removeItem.Show();
        }

        private void SearchByItembutton_Click(object sender, RoutedEventArgs e)
        {
            FileStore tp = (FileStore)Application.Current.FindResource("globStore");
            ProductSearchForm search = new ProductSearchForm(tp);
            search.Show();
        }
    }
}
