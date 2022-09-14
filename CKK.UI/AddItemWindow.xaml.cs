using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Windows;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private IStore Store;


        public AddItemWindow(IStore store)
        {
            Store = store;

            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Description = ItemDescTextBox.Text;
            decimal Price = Convert.ToDecimal(PriceTextBox.Text);
            int quanity = Convert.ToInt32(QtyTextBox.Text);


            Product productadd = new Product();
            productadd.Name = Description;
            productadd.Price = Price;
            productadd.Quantity = quanity;

            productadd = Store.AddProduct(productadd);

            productadd = Store.FindByName(productadd.Name);

            MessageBox.Show($"New Item Number {productadd.Id} was created for {Description}.");
            clearboxes();
            //Store1.AddStoreItem(productadd, quanity);

        }

        private void clearboxes()
        {
            ItemDescTextBox.Clear();
            QtyTextBox.Clear();
            PriceTextBox.Clear();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }
    }
}
