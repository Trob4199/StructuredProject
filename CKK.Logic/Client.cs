using System;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using CKK.Logic.Models;
using CKK.Persistance.Models;
using CKK.Logic.Interfaces;



namespace CKK.Client
{
    public class Client
    {
        private Socket sck = null;
        private EndPoint epLocal;
        private EndPoint epRemote;
        private byte[] buffer;
        private string localip;
        private int localport = 11001;
        private int remoteport = 11000;
        private IStore Store;

        public static void Main()
        {
            Client c = new Client();
            //Load the store data
            FileStore store = new FileStore();
            Customer customer1 = new Customer();

            //Create a generic customer (demo only)
            customer1 = customerinto(customer1);
            customer1.CustomerId = 101;


            //Create a shopping cart (demo only) 
            ShoppingCart newcart = new ShoppingCart();
            newcart.ShoppingCartId = 100;
            newcart.Customer = customer1;
            newcart.ShoppingCartId = 101;
            newcart.CustomerId = newcart.Customer.CustomerId;


            c.Form1_Load();

            //c.SendMessage();
            while (true)
            {
                Console.WriteLine("Select and option: ");
                Console.WriteLine("1: Add Item to Cart ");
                Console.WriteLine("2: View Cart");
                Console.WriteLine("3: View Store List");
                Console.WriteLine("4: Check Out");
                string selection = Console.ReadLine();
                Console.Clear();


                if (selection == "1")
                {
                    Console.Write("Enter the item number to add: ");
                    var additem = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the quantity: ");
                    int quanity = Convert.ToInt32(Console.ReadLine());

                    StoreItem TempStoreItem = store.FindStoreItemById(additem);
                    var tempproduct = TempStoreItem.Product;
                    var tempcartitem = new ShoppingCartItem(tempproduct, quanity);

                    newcart.ShoppingCartList.Add(tempcartitem);

                    Console.WriteLine($"\n\n{tempproduct.Name} has been added to your cart.\n\n");
                    Console.WriteLine("Press Enter to continue....");
                    Console.Read();
                    Console.Clear();

                }
                else if (selection == "2")
                {
                    Console.WriteLine("\t\tShopping Cart\n");
                    Console.WriteLine("Item Number\tDescription\tQuanity");
                    foreach (var item in newcart.ShoppingCartList)
                    {
                        Console.WriteLine($"{item.Product.Id}\t\t{item.Product.Name}\t\t{item.Quantity}");
                    }
                    Console.Write("\n\nPress Enter to continue....");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (selection == "3")
                {
                    var listtemp = store.GetStoreItems();
                    Console.WriteLine("\t\t\tStore Inventory");
                    Console.WriteLine($"Item Number \t Description \t Price \t\t Quantity");
                    foreach (var item in listtemp)
                    {
                        Console.WriteLine($"{item.ToString()}");
                    }
                    Console.WriteLine("\n\n\n");
                }
                else if (selection == "4")  //Send Order to server side and wait for response
                {
                    Order order = new Order();
                    order.OrderId = 1;
                    order.ShoppingCartId = newcart.ShoppingCartId;
                    c.StartSever();
                    c.SendMessage(order);
                    c.startReceiving();

                }



            }

        }



        public void Form1_Load()
        {
            // set up socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // Get own IP
            localip = GetLocalIP();

        }

        private static string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void StartSever()
        {
            try
            {
                // create local IPEndpoint with the local IPAddress and bind it to the EndPoint
                epLocal = new IPEndPoint(IPAddress.Parse(localip), localport);
                sck.Bind(epLocal);

                // connect to remote IP and port and bind the remote IPAddress to the remote EndPoint
                epRemote = new IPEndPoint(IPAddress.Parse(localip), remoteport);
                sck.Connect(epRemote);

                //create a buffer that will be use ot receive messages from the socket and start to listen ot the specific port
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                //change GUI to enable messages to send. 
                Console.WriteLine("Connected");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);

                // check if theres actually information that was received
                if (size > 0)
                {
                    //get 1500 bytes of data (because that is how big the buffer is)
                    byte[] receivedData = new byte[1500];

                    // getting the message data, which is passed through
                    receivedData = (byte[])aResult.AsyncState;

                    //converts message data byte array to string
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);

                    //adding message to the listbox
                    Console.WriteLine(receivedMessage);


                    Console.Write("\n\nPress Enter to continue....");
                    Console.ReadLine();


                }

                sck.Shutdown(SocketShutdown.Both);
                sck.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        private void startReceiving()
        {
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
        }

        private void SendMessage(Order newcart)
        {
            try
            {
                byte[] msg = JsonSerializer.SerializeToUtf8Bytes<object>(newcart);

                //sending the message
                sck.Send(msg);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Customer customerinto(Customer customertemp)
        {
            customertemp.Address = "123 main street";
            return customertemp;
        }

    }
}