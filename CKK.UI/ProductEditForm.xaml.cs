using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProductEditForm : Window
    {
        int ID;
        Product ProdTemp;
        private IStore Store;
        bool ready = false;



        public ProductEditForm(IStore store)
        {
            Store = store;

            InitializeComponent();
        }


        private void IDTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text != "")
            {
                ID = Convert.ToInt32(((TextBox)sender).Text);


                try
                {
                    ProdTemp = Store.FindProductById(ID);

                    ItemDescTextBox.Visibility = Visibility.Visible;
                    QtyTextBox.Visibility = Visibility.Visible;
                    PriceTextBox.Visibility = Visibility.Visible;
                    SaveButton.IsEnabled = true;
                    ItemDescTextBox.Text = ProdTemp.Name;
                    QtyTextBox.Text = Convert.ToString(ProdTemp.Quantity);
                    PriceTextBox.Text = Convert.ToString(ProdTemp.Price);
                    ready = true;
                }
                catch
                {
                    MessageBox.Show($"No matching products with ID {ID}");
                    ready = false;
                }



            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProdTemp.Price = Convert.ToDecimal(PriceTextBox.Text);
            ProdTemp.Name = ItemDescTextBox.Text;
            ProdTemp.Quantity = Convert.ToInt16(QtyTextBox.Text);

            Store.UpdateProduct(ProdTemp);
            SaveButton.IsEnabled = false;
        }

        private void Cancelbuttun_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
