using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPchat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Socket client;
        private static byte[] data = new byte[1024];
        private void btnConn_Click(object sender, EventArgs e)
        {
            results.Items.Add("Connecting...");
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            client.BeginConnect(iep, new AsyncCallback(Connected), client);
        }
        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            ////////
        }
        void AcceptConn(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            client = oldserver.EndAccept(iar);
            results.Items.Add("Connection from: " + client.RemoteEndPoint.ToString());
            Thread receiver = new Thread(new ThreadStart(ReceiveData));
            receiver.Start();
        }
        void Connected(IAsyncResult iar)
        {
            try
            {
                client.EndConnect(iar);
                results.Items.Add("Connected to: " + client.RemoteEndPoint.ToString());
                Thread receiver = new Thread(new ThreadStart(ReceiveData));
                receiver.Start();
            }
            catch (SocketException)
            {
                results.Items.Add("Error connecting");
            }
        }
        void ReceiveData()
        {
            int recv;
            string stringData;
            while (true)
            {
                recv = client.Receive(data);
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                if (stringData == "bye")
                    break;
                results.Items.Add(stringData);
            }
            stringData = "bye"; // output bye thoi roi dong ket noi
            byte[] message = Encoding.UTF8.GetBytes(stringData); client.Send(message);
            client.Close();
            results.Items.Add("Connection stopped");
            return;
        }
       

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtName.Text == String.Empty || newText.Text == String.Empty)
            {
                MessageBox.Show("Nhap chua day du thong tin");
            }
            string input = newText.Text;
            string name = txtName.Text;
            string combine = name + ": " + input;
            byte[] message = Encoding.UTF8.GetBytes(combine);
            newText.Clear();
            client.BeginSend(message, 0, message.Length, 0,
            new AsyncCallback(SendData), client);


        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            results.Items.Add("Listening for a client...");
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            newsock.Bind(iep);
            newsock.Listen(5); newsock.BeginAccept(new AsyncCallback(AcceptConn), newsock);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSend.Click += BtnSend_Click;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.UTF8.GetBytes(newText.Text);
            newText.Clear();
            client.BeginSend(message, 0, message.Length, 0,
            new AsyncCallback(SendData), client);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.UTF8.GetBytes(txtName.Text);
            client.BeginSend(message, 0, message.Length, 0,
            new AsyncCallback(SendData), client);
        }
    }
}
