using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TCPClient
{
    public partial class TcpClientForm : Form
    {
        public TcpClientForm()
        {
            InitializeComponent();
            button1.Click += buttonConnect_Click;
            button2.Click += buttonSend_Click;
            FormClosed += Form1_FormClosed;
            CheckForIllegalCrossThreadCalls = false;
        }
        // Объект содержащий рабочий сокет клиентского приложения
        TcpClient tcpСlient = new TcpClient();
        // Объект сетевого потока для приема и отправки сообщений
        NetworkStream ns;
        // Флаг для остановки потоков и завершения сетевой работы приложения
        bool stopNetwork;
        bool FileReceiveFlag { get; set; }
        private delegate bool TryFileCompile(string s);
        private string Path { get; set; }
        #region Управление клиентским приложением
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClient();
        }

        #endregion
        #region Функциональная часть Сетевая работа
        // Попытка подключения к серверу
        void Connect()
        {
            Path = "";
            tcpСlient = new TcpClient();
            try
            {
                tcpСlient.Connect(textBox2.Text, int.Parse(textBox3.Text));
                ns = tcpСlient.GetStream();
                
                Thread th = new Thread(ReceiveRun);
                th.Start();

                // Цветовое оповещение о подключении.
                BackColor = Color.FromArgb(255, 128, 0);
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch
            {
                ErrorSound();
            }
        }
        void CloseClient()
        {
            byte[] buffer = Encoding.Default.GetBytes("Отключаюсь.");
            ns.Write(buffer, 0, buffer.Length);
            if (ns != null) ns.Close();
            if (tcpСlient != null) tcpСlient.Close();
            stopNetwork = true;
            // Цветовое оповещение об отключении.
            BackColor = Color.FromName("Control");
        }
        // Отправка сообщений в блокирующем режиме,
        // поскольку обмен короткими сообщениями
        // не вызовет заметного блокирования интерфейса приложения. 
        void SendMessage()
        {
            if (ns != null)
            {
                byte[] buffer = Encoding.Default.GetBytes(textBox1.Text);
                ns.Write(buffer, 0, buffer.Length);
            }
        }
        // Цикл извлечения сообщений,
        // запускается в отдельном потоке.
        void ReceiveRun()
        {
            FileReceiveFlag = false;
            while (true)
            {
                try
                {
                    string s = null;
                    while (ns.DataAvailable == true)
                    {
                        // Определение необходимого размера буфера приема.
                        byte[] buffer = new byte[tcpСlient.Available];
                        ns.Read(buffer, 0, buffer.Length);

                        s += Encoding.Default.GetString(buffer);
                    }
                    //ParameterizedThreadStart p = FileCompile;

                    //Thread fileCreate = new Thread(new ParameterizedThreadStart(FileCompile));
                    //fileCreate.
                    if (s != null)
                    {
                        Task t = new Task(FileCompile, s);
                        t.Start();
                    }
                    //    for(int i=0; i<s.Length;i++)
                    //    {
                    //        if (FileReceiveFlag)
                    //            break;
                    //        if(s[i]=='#')
                    //        {
                    //            string command = s.Substring(i, 21);
                    //            if(command == "#FileSendCommandLine#")
                    //            {
                    //                Path = s.Split(new string[] { "#FileSendCommandLine#" }, StringSplitOptions.None)[0];
                    //                FileReceiveFlag = true;
                    //                fs = new FileStream(Path, FileMode.Create);
                    //                buffer = Encoding.Default.GetBytes(s.Split(new string[] { "#FileSendCommandLine#" }, StringSplitOptions.None)[1]);
                    //             break;
                    //             }
                    //         }
                    //    }


                    //for (int i = 0; i < s.Length; i++)
                    //{
                    //    if (!FileReceiveFlag)
                    //        break;
                    //    if (s[i] == '#')
                    //    {
                    //        string command = s.Substring(i, 20);
                    //        if (command == "#EndFileCommandLine#")
                    //        {
                    //            //Path = s.Split(new string[] { "#FileSendCommandLine#" }, StringSplitOptions.None)[0];
                    //            FileReceiveFlag = false;

                    //            //fs = new FileStream(Path, FileMode.Create);

                    //            //buffer = Encoding.Default.GetBytes(s.Split(new string[] { "#EndFileCommandLine#" }, StringSplitOptions.None)[0]);
                    //            string convert = Encoding.Default.GetString(buffer);
                    //            //int a = convert.Length;
                    //            convert = convert.Split(new string[] { "#EndFileCommandLine#" }, StringSplitOptions.None)[0];
                    //            buffer = Encoding.Default.GetBytes(convert);
                    //            //int b = convert.Length;
                    //            fs.Write(buffer, 0, buffer.Length);
                    //            //fs.Dispose();
                    //            break;
                    //        }
                    //    }
                    //}

                        //if (FileReceiveFlag)
                        //{
                        //    fs.Write(buffer, 0, buffer.Length);
                        //}
                        //if (FileReceiveFlag)
                        //{
                        //    fs.Write(buffer, 0, buffer.Length);
                        //}
                        //if (s == "Подтверждено.")
                        //{
                        //    break;
                        //}
                        //if (s== "Отказано в подключении.") 
                        //{
                        //    tcpСlient.Client.Close();
                        //    button1.Enabled = true;
                        //    button2.Enabled = false;
                        //    return;
                        //}

                    
                    //if (s != null)
                    //{
                    //    ShowReceiveMessage(s);
                    //    s = string.Empty;                      
                    //}
                    //else
                    //{
                        //FileReceiveFlag = false;
                    //}
                    // Вынужденная строчка для экономия ресурсов процессора.
                    // Неизящный способ.
                    Thread.Sleep(100);
                }
                catch
                {
                    ErrorSound();
                }

                if (stopNetwork == true) break;

            }
        }

        private void FileCompile(object networkStreamData)
        {
            string data = (string)networkStreamData;
            FileStream fs = null;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '#')
                {
                    string command = data.Substring(i, 21);
                    if (command == "#FileSendCommandLine#")
                    {
                        Path = data.Split(new string[] { "#FileSendCommandLine#" }, StringSplitOptions.None)[0];
                        fs = new FileStream(Path, FileMode.Create);
                        data = data.Split(new string[] { "#FileSendCommandLine#" }, StringSplitOptions.None)[1];
                        break;
                    }
                }
            }
            if (fs != null)
            {
                byte[] fileData = Encoding.Default.GetBytes(data);
                fs.Write(fileData, 0, fileData.Length);
                //fs.Dispose();
                //fs = null;
                //GC.Collect();
                //return true;
            }
            else ShowReceiveMessage(data);

            //else return false;
        }
        
        #endregion
        #region Информации о сетевой работе
        // Код доступа к свойствам объектов главной формы  из других потоков
        delegate void UpdateReceiveDisplayDelegate(string message);
        void ShowReceiveMessage(string message)
        {
            if (listBox1.InvokeRequired == true)
            {
                UpdateReceiveDisplayDelegate rdd = new UpdateReceiveDisplayDelegate(ShowReceiveMessage);
                // Данный метод вызывается в дочернем потоке,
                // ищет основной поток и выполняет делегат указанный в качестве параметра 
                // в главном потоке, безопасно обновляя интерфейс формы.
                Invoke(rdd, new object[] { message });
            }
            else
            {
                // Если не требуется вызывать метод Invoke, обратимся напрямую к элементу формы.
                listBox1.Items.Add(message);
            }
        }
        // Звуковое оповещение о перехваченной ошибке.
        void ErrorSound()
        {
            Console.Beep(2000, 80);
            Console.Beep(3000, 120);
        }
        #endregion
    }
}

