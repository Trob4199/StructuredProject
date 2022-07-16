using System;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using CKK.Logic.Models;




namespace CKK.Server
{
    public class Server
    {
        private Socket sck = null;
        private EndPoint epLocal;
        private EndPoint epRemote;
        private byte[] buffer;
        private string localip;
        private int localport = 11000;
        private int remoteport = 11001;
        public List<Order> orders = new List<Order>();
        public Queue<Order> OrdersQueue = new Queue<Order>();   

        public static void Main()
        {
            Server s = new Server();
            s.Form1_Load();
            s.StartSever();
            while (true)
            {

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
                Console.WriteLine("Server Started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void MessageCallBack(IAsyncResult aResult)
        {

            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);

                // check if theres actually information that was received
                if (size > 0)
                {
                    //get 1500 bytes of data (because that is how big the buffer is)
                    //byte[] receivedData = new byte[1500];

                    // getting the message data, which is passed through
                    byte[] receivedData = (byte[])aResult.AsyncState;

                    //converts message data byte array to json
                    try
                    {
                        var utf8reader = new Utf8JsonReader(receivedData);
                        var json = (JsonElement)JsonSerializer.Deserialize<object>(ref utf8reader);
                        var ordertemp = json.ToObject<Order>();
                        OrdersQueue.Enqueue(ordertemp);
                        
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.ToString());
                    }



                    //adding message to the listbox
                    Console.Clear();
                    Console.WriteLine("Server Running");
                    Console.WriteLine($"Number of orders in Queue: {OrdersQueue.Count}");
                    SendMessage("Order Received");


                }
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }



        private void SendMessage(string message)
        {
            try
            {
                // convert from string to byte[]
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] msg = new byte[1500];

                msg = enc.GetBytes(message);

                //sending the message
                sck.Send(msg);

                // add to the listbox
                DateTime localDate = DateTime.Now;


                //clear txtMessage

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    static class JsonExtention
    {
        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}