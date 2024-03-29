﻿using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for RemoveItemWindow.xaml
    /// </summary>
    public partial class RemoveItemWindow : Window
    {
        int ID;
        Product ProdTemp;
        private IStore Store;
        bool ready = false;

        public RemoveItemWindow(IStore store)
        {
            Store = store;
            InitializeComponent();
        }



        private void IDTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text != "")
            {
                ID = Convert.ToInt32(((TextBox)sender).Text);



                ProdTemp = Store.FindProductById(ID);

                if (ProdTemp != null)
                {
                    ItemDescTextBlock.Text = ProdTemp.Name;
                    QtyTextBlock.Text = Convert.ToString(ProdTemp.Quantity);
                    PriceTextBlock.Text = Convert.ToString(ProdTemp.Price);
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

                    Product deleted = Store.DeleteProduct(ID);

                    if (deleted != null)
                    {
                        MessageBox.Show($"Item number {ID}, {ProdTemp.Name} was removed successfully.");
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
