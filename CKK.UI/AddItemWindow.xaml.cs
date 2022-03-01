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
using CKK.Logic.Interfaces;
using CKK.UI;
using CKK.Persistance.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
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

            FileStore tp = (FileStore)Application.Current.FindResource("globStore");

            tp.AddStoreItem(productadd, quanity);

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
