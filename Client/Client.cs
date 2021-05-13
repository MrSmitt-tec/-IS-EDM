using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;
using System.Management;

namespace Client
{
    class Client
    {
        public static int Port;
        public static string IPAdresS;
        private static string _username;


        static void Main(string[] args)
        {
            //------------------------------Получение логин@имя компьютера---------------------------------------------начало
            foreach (var p in Process.GetProcessesByName("explorer"))
            {
                _username = GetProcessOwner(p.Id);
            }

            // remove the domain part from the username
            var usernameParts = _username.Split('\\');

            _username = usernameParts[usernameParts.Length - 1] + "@" + Dns.GetHostName();

            //------------------------------Получение логин@имя компьютера---------------------------------------------конец


            Console.WriteLine(_username);
            

            //------------------------------------Параметры для соединения с сервером-------------------------------------------
            Console.WriteLine("Веддите адрес сервера: ");
            IPAdresS = Console.ReadLine();
            Console.WriteLine("Введите порт: ");
            Port = Convert.ToInt32(Console.ReadLine());

            //------------------------------------Параметры для соединения с сервером-------------------------------------------
            TcpClient client = null;

            try
            {
                client = new TcpClient(IPAdresS, Port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    string message = String.Format(_username);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    //client.Close();

                    // получаем ответ
                    data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine("Соединение........." + message);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
                Console.ReadLine();
            }

        }

        //------------------------------------------------------------------------------------------------------------------начало
        public static string GetProcessOwner(int processId) //получение пользователя запустившего процесс(это не точно)
        {
            var query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectCollection processList;

            using (var searcher = new ManagementObjectSearcher(query))
            {
                processList = searcher.Get();
            }

            foreach (var mo in processList.OfType<ManagementObject>())
            {
                object[] argList = { string.Empty, string.Empty };
                var returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", argList));

                if (returnVal == 0)
                {
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
        }
        //------------------------------------------------------------------------------------------------------------------конец

        
            //

            //IPAdresS = Console.ReadLine(); //вводим ИП адрес сервера
            ////if (Console.ReadLine() == null) { IPadresServer = "127.0.0.1"; }


            //
            //Port = Convert.ToInt32(Console.ReadLine()); //вводим порт введением в консоль


            //Console.WriteLine(IPAdresS);
            //Console.WriteLine(Port);

            //Console.Write("Введите свое имя:");



            //string userName = WindowsIdentity.GetCurrent().Name;




            //       TcpClient client = null;
            //       try
            //       {
            //           client = new TcpClient(IPAdresS, Port);
            //           NetworkStream stream = client.GetStream();

            //           while (true)
            //           {
            //               Console.Write(userName + ": ");
            //               // ввод сообщения
            //               string message = Console.ReadLine();
            //               message = String.Format("{0}: {1}", userName, message);
            //               // преобразуем сообщение в массив байтов
            //               byte[] data = Encoding.Unicode.GetBytes(message);
            //               // отправка сообщения
            //               stream.Write(data, 0, data.Length);

            //               // получаем ответ
            //               data = new byte[64]; // буфер для получаемых данных
            //               StringBuilder builder = new StringBuilder();
            //               int bytes = 0;
            //               do
            //               {
            //                   bytes = stream.Read(data, 0, data.Length);
            //                   builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            //               }
            //               while (stream.DataAvailable);

            //               message = builder.ToString();
            //               Console.WriteLine("Сервер: {0}", message);
            //           }
            //       }
            //       catch (Exception ex)
            //{
            //           Console.WriteLine(ex.Message);
            //}
            //       finally
            //{
            //           client.Close();
            //}

        
    }
}
