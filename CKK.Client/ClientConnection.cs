﻿using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;



namespace CKK.Client
{
    public class ClientConnection
    {
        private Socket sck = null;
        private EndPoint epLocal;
        private EndPoint epRemote;
        private byte[] buffer;
        private string localip;
        private int localport = 11001;
        private int remoteport = 11000;
        private IStore Store;
        private Customer Customer1;
        private Order Order1;
        private string receivedMessage;


        public ClientConnection(Order order)
        {
            Order1 = order;
        }

        public string OrderProcess()
        {
            Form1_Load();
            StartSever();
            SendMessage(Order1);
            startReceiving();
            return receivedMessage;
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
                    receivedMessage = eEncoding.GetString(receivedData);
                }

                sck.Shutdown(SocketShutdown.Both);
                sck.Close();

            }

            catch (Exception exp)
            {
                receivedMessage = "Error, Could not process order";
            }
        }

        private void startReceiving()
        {
            buffer = new byte[1500];
            var done = false;
            int i = 0;
            var message = sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            while (done == false)
            {                   
                if (receivedMessage != null && message.IsCompleted == true)
                {
                    done = true;
                }
                else if(receivedMessage == "Error, Could not process order")
                {
                    done = true;
                    sck.Close();
                }

                
            }
            
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

