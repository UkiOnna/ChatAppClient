using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppClient
{
    class Program
    {
        //сервер берет чето ищет потом бац и челик ну он такой принимает все ок да но потом челик отправляет сообщение и это сообщение отображается всем подключенным
        // кроме того кто отправил но принять он может только троих а следущего такой не не не пошел отсюда потом пользователь отключается и все ок опять 

        private const int SERVER_PORT = 3535;
        static void Main(string[] args)
        {
            Socket remoteServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), SERVER_PORT);
            bool isExit = false;
            try
            {
                Console.WriteLine("Соединяемся с сервером");
                remoteServerSocket.Connect(endPoint);
                
                Console.WriteLine("Соединено..");
                while (!isExit)
                {
                    Console.WriteLine("Напишите сообщение  Напишите 2 чтобы выйти");
                    
                    string mes = Console.ReadLine();
                    if (mes == "2")
                    {
                        
                    }
                    // Console.WriteLine("Отправка...");
                    remoteServerSocket.Send(Encoding.Default.GetBytes(mes));
                    Console.WriteLine("Сообщение отправлено");
                }

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                remoteServerSocket.Close();
                Console.WriteLine("Сеанс завершен.");
            }
            Console.ReadLine();
        }
    }
}
