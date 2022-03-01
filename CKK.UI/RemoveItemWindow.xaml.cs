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
using CKK.Persistance.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for RemoveItemWindow.xaml
    /// </summary>
    public partial class RemoveItemWindow : Window
    {
        int ID;
        StoreItem itemtemp;
        FileStore tp;
        bool ready = false; 

        public RemoveItemWindow()
        {
            InitializeComponent();
        }



        private void IDTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text != "")
            {
                ID = Convert.ToInt32(((TextBox)sender).Text);


                tp = (FileStore)Application.Current.FindResource("globStore");
                itemtemp = tp.FindStoreItemById(ID);

                if (itemtemp != null)
                {
                    ItemDescTextBlock.Text = itemtemp.Product.Name;
                    QtyTextBlock.Text = Convert.ToString(itemtemp.Quantity);
                    PriceTextBlock.Text = Convert.ToString(itemtemp.Product.Price);
                    ready = true;
                }
                else
                {
                    MessageBox.Show($"No matching products with ID {ID}");
                    ready = false;
                }


            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ready)
            {


                MessageBoxResult MessageBoxResult = MessageBox.Show("Are you sure you want to delete item?", "Remove Item", MessageBoxButton.YesNo);

                if (MessageBoxResult == MessageBoxResult.Yes)
                {

                    string deleted = tp.DeleteStoreItem(ID);

                    if (deleted == "Deleted")
                    {
                        MessageBox.Show($"Item number {ID}, {itemtemp.Product.Name} was removed successfully.");
                        ItemDescTextBlock.Text = "";
                        QtyTextBlock.Text = "";
                        PriceTextBlock.Text = "";
                        IDTextBox.Text = "";
                    }

                }
            }
        }

        private void Cancelbuttun_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
