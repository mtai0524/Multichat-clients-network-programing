using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace serverTCPchat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Chuong trinh chat xuyen luc dia kkk");
            Console.ResetColor();
            ThreadedTcpSrvr server = new ThreadedTcpSrvr(); 
        }
    }
    class ConnectionThread
    {
        public TcpListener threadListener; //tạo thread listener
        private static int connections = 0; // số connect
        static List<TcpClient> clientList = new List<TcpClient>(); // static để giữ giá trị khi tạo đối tượng mới nếu k thì mất hết client
        public void HandleConnection()
        {
            int recv;
            byte[] data = new byte[1024];
            TcpClient client = threadListener.AcceptTcpClient(); // chấp nhận kết nối trả về TCPclient
            NetworkStream ns = client.GetStream(); // tạo network stream
            connections++; // tăng số conn
            Console.WriteLine("New client accepted: {0} active connections",
            connections);
            clientList.Add(client);
            string welcome = "Welcome to my test server"; // tạo chuỗi
            data = Encoding.ASCII.GetBytes(welcome); // chuyển string thanh byte
            ns.Write(data, 0, data.Length); // đẩy byte lên ns
            while (true) 
            {
                data = new byte[1024];
                recv = ns.Read(data, 0, data.Length); // đọc byte == nhận byte
                if (recv == 0) // nếu không có data
                    break;
                foreach (TcpClient c in clientList)
                {
                    NetworkStream stream = c.GetStream();
                    if (stream.CanWrite)
                    {
                        stream.Write(data, 0, recv);
                    }
                }
            }
            ns.Close(); // đóng ns 
            client.Close(); // đóng tcpclient
            connections--; // giảm conn
            Console.WriteLine("Client disconnected: {0} active connections",
            connections); // input disconnect
        }
    }
    class ThreadedTcpSrvr // dùng thread để chạy hàm
    {
        private TcpListener client;
        public ThreadedTcpSrvr()
        {
            client = new TcpListener(9050); // tạo listener để client conn
            client.Start();  // bắt đầu lắng nghe
            Console.WriteLine("Waiting for clients...");
            while (true)
            {
                while (!client.Pending()) // nếu không còn client trong hàng đợi thì thread ngủ 1s và lắng nghe tiếp
                {
                    Thread.Sleep(1000);// ngủ 1s xong kiểm tra hanfg đợi
                }
                ConnectionThread newconnection = new ConnectionThread(); // new đối tượng
                newconnection.threadListener = this.client; // gán thuộc tính đối tượng thành TCP lắng nghe hiện tại
                Thread newthread = new Thread(new
                ThreadStart(newconnection.HandleConnection)); // tạo một luồng xử lí kết nối riêng
                newthread.Start(); // bắt đầu thread
            }
        }
    }
}
