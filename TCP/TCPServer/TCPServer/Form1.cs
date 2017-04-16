using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
//using Word = Microsoft.Office.Interop.Word;
using System.IO;


namespace TCPServer
{
    public partial class TcpServerForm : Form
    {
        public TcpServerForm()
        {
            InitializeComponent();
            listBoxClients.HorizontalScrollbar = true;
            buttonSendAll.Click += buttonSendAll_Click;
            buttonStart.Click += buttonStart_Click;
            buttonStop.Click += buttonStop_Click;
            buttonSendTarget.Click += buttonSendTarget_Click;
            FormClosing += TcpServerForm_FormClosing;
            connectedClients = new List<ConnectedClient>();
        }

        // Высокоуровневая надстройка для прослушивающего сокета
        TcpListener server;
        // Количество принимаемых подключений к серверу
        const int maxClientAmount = 15;
        // Высокоуровневая надстройка для сокетов обмена сообщений с 
        // клиентскими приложениями.
        TcpClient[] clients = new TcpClient[maxClientAmount];
        // Счетчик подключенных клиентов
        int countClient = 0;
        // Флаг мягкой остановки циклов и дополнительных потоков
        bool stopNetwork;
        List<ConnectedClient> connectedClients;
        #region Управление серверным приложением
        private void buttonStart_Click(object sender, EventArgs e)
        {           
            StartServer();         
        }
        private void buttonSendAll_Click(object sender, EventArgs e)
        {
            string message = "Cервер" + ": " + textBoxSend.Text;
            SendToClients(message, -1);
        }
        private void buttonSendTarget_Click(object sender, EventArgs e)
        {
            string message = "Cервер" + ": " + textBoxSend.Text;
            SendToClient(message);
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }
        private void TcpServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }
        #endregion
        #region Функциональная часть сетевой работы
        // Запуск сервера и вспомогательного потока акцептирования клиентских подключений
        // т.е. назначения сокетов ответственных за обмен сообщениями 
        // с соответствующим клиентским приложением
        private void StartServer()
        {
            // Предотвратим повторный запуск сервера
            if (server == null)
            {
                // Блок перехвата исключений на случай запуска одновременно
                // двух серверных приложений с одинаковым портом.
                try
                {
                    stopNetwork = false;
                    countClient = 0;
                    UpdateClientsDisplay();

                    int port = int.Parse(textBoxSocket.Text);
                    server = new TcpListener(IPAddress.Any, port);
                    server.Start();


                    Thread acceptThread = new Thread(AcceptClients);
                    acceptThread.Start();

                    // Визуальное оповещение, что сервер запущен
                    BackColor = Color.FromArgb(150, 192, 255);

                }
                catch(Exception ex)
                {
                    textBoxReceive.Text += ex.Message;
                    ErrorSound();
                }
            }
        }
        // Принудительная остановка сервера и запущенных потоков.
        private void StopServer()
        {
            if (server != null)
            {
                server.Stop();
                server = null;
                stopNetwork = true;

                for (int i = 0; i < maxClientAmount; i++)
                {
                    if (clients[i] != null) clients[i].Close();
                }
                // Визуально оповещаем, что сервер остановлен.
                BackColor = Color.FromName("Control");
            }
        }
        // Принимаем запросы клиентов на подключение и
        // привязываем к каждому подключившемуся клиенту 
        // сокет (в данном случае объект класса TcpClient)
        // для обменом сообщений.
        private void AcceptClients()
        { 
            while (true)
            {
                try
                {
                    clients[countClient] = server.AcceptTcpClient();
                    if (server == null)
                        break;                  
                    //clients.Add(server.AcceptTcpClient());
                    NetworkStream ns = clients[countClient].GetStream();
                    byte[] myReadBuffer = Encoding.Default.GetBytes("Введите псевдоним");
                    Invoke(new UpdateReceiveConnectionDelegate(UpdateReceiveDisplay),clients[countClient].Client.RemoteEndPoint);
                    ns.Write(myReadBuffer, 0, myReadBuffer.Length);
                    string s = null;
                    while (s==null)
                    {
                        ns = clients[countClient].GetStream();
                        while (ns.DataAvailable == true)
                        {
                            byte[] buffer = new byte[clients[countClient].Available];
                            ns.Read(buffer, 0, buffer.Length);
                            s = Encoding.Default.GetString(buffer);
                            ConnectedClient c = new ConnectedClient(s, clients[countClient].Client.RemoteEndPoint);
                            connectedClients.Add(c);
                            SendToClients("Подключился клиент " + s + " " + c.IP.ToString(), countClient);
                        }

                    }
                    myReadBuffer = Encoding.Default.GetBytes("Принято, отправка сообщений разрешена.");
                    ns.Write(myReadBuffer, 0, myReadBuffer.Length);
                    Thread readThread = new Thread(ReceiveRun);
                    readThread.Start(countClient);
                    countClient++;
                    // Данный метод, хотя и вызывается в отдельном потоке (не в главном),
                    // но находит родительский поток и выполняет делегат указанный в качестве параметра 
                    // в главном потоке, безопасно обновляя интерфейс формы.
                    Invoke(new UpdateClientsDisplayDelegate(UpdateClientsDisplay));
                    
                }
                catch (Exception)
                {
                    // Перехватим возможные исключения
                    ErrorSound();
                }
                if (stopNetwork == true)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Отправка сообщений клиентам
        /// </summary>
        /// <param name="text">текст сообщения</param>
        /// <param name="skipindex">индекс клиента которому не посылается сообщение</param>        
        private void SendToClients(string text, int skipindex)
        {
            for (int i = 0; i < maxClientAmount; i++)
            {
                if (clients[i] != null)
                {
                    if (i == skipindex) continue;
                    // Подготовка и запуск асинхронной отправки сообщения.
                    openFileDialog1.ShowDialog();
                    string fileName = openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1];
                    NetworkStream ns = clients[i].GetStream();
                    byte[] startCommandBuffer = Encoding.Default.GetBytes(fileName+"#FileSendCommandLine#");
                    ns.Write(startCommandBuffer, 0, startCommandBuffer.Length);
                    //ns.Flush();
                    //Thread.Sleep(100);
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    byte[] readBuf = new byte[fs.Length];
                    fs.Read(readBuf, 0, (Convert.ToInt32(fs.Length)));
                    //string convert = Encoding.Default.GetString(readBuf);
                    //convert += "#EndFileCommandLine#";
                    //readBuf = Encoding.Default.GetBytes(convert);
                    //readBufEncoding.Default.GetBytes("#EndFileCommandLine#");
                    //FileData = Encoding.Default.GetString(readBuf);
                    //NetworkStream ns = clients[i].GetStream();
                    //byte[] myReadBuffer = Encoding.Default.GetBytes(text);
                    //ns.BeginWrite(readBuf, 0, readBuf.Length, new AsyncCallback(AsyncSendCompleted), ns);
                    ns.Write(readBuf, 0, readBuf.Length);
                    //ns.Flush();
                    //Thread.Sleep(200);
                    //ns.Flush();
                    //Thread.Sleep(100);
                    //commandBuffer = Encoding.Default.GetBytes("#EndFileCommandLine#");
                    //ns.Write(commandBuffer, 0, commandBuffer.Length);
                    //ns.Flush();
                    //Thread.Sleep(100);
                    //byte[] endCommandBuffer = Encoding.Default.GetBytes("#EndFileCommandLine#");
                    //ns.Write(endCommandBuffer, 0, endCommandBuffer.Length);
                    //ns.Flush();
                    //Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// Отправка сообщения конкретному клиенту
        /// </summary>
        /// <param name="message">текст сообщения</param>
        private void SendToClient(string message)
        {
            try
            {
                if(clients[listBoxClients.SelectedIndex]!=null)
                {
                    NetworkStream ns = clients[listBoxClients.SelectedIndex].GetStream();
                    byte[] myReadBuffer = Encoding.Default.GetBytes(message);
                    ns.BeginWrite(myReadBuffer, 0, myReadBuffer.Length, new AsyncCallback(AsyncSendCompleted), ns);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не выбран клиент-получатель.", "Ошибка отправки сообщения.", MessageBoxButtons.OK);         
            }
        }

        // Асинхронная отправка сообщения клиенту.
        public void AsyncSendCompleted(IAsyncResult ar)
        {
            NetworkStream ns = (NetworkStream)ar.AsyncState;
            ns.EndWrite(ar);
        }

        //private void ReceivePass(object num)
        //{
        //    string s = null;
        //    NetworkStream ns = clients[(int)num].GetStream();

        //    while (ns.DataAvailable == true)
        //    {
        //        // Определить точный размер буфера приема позволяет свойство класса TcpClient - Available
        //        byte[] buffer = new byte[clients[(int)num].Available];

        //        ns.Read(buffer, 0, buffer.Length);
        //        s += Encoding.Default.GetString(buffer);
        //    }
        //}
        // Извлечение сообщения от клиента и ретрансляция полученного 
        // сообщения другим клиентам
        private void ReceiveRun(object num)
        {
            while (true)
            {
                try
                {
                    string s = null;
                    NetworkStream ns = clients[(int)num].GetStream();

                    while (ns.DataAvailable == true)
                    {
                        // Определить точный размер буфера приема позволяет свойство класса TcpClient - Available
                        byte[] buffer = new byte[clients[(int)num].Available];

                        ns.Read(buffer, 0, buffer.Length);
                        s += Encoding.Default.GetString(buffer);
                    }
                    if(s == "Отключаюсь.")
                    {
                        s = connectedClients[(int)num].Name + " отключился.";
                        SendToClients(s, (int)num);
                        foreach (ConnectedClient c in connectedClients)
                            if (c.Name == connectedClients[(int)num].Name)
                                connectedClients.Remove(c);
                        s = null;

                    }
                    if (s != null)
                    {
                        // Данный метод, хотя и вызывается в отдельном потоке (не в главном),
                        // но находит родительский поток и выполняет делегат указанный в качестве параметра 
                        // в главном потоке, безопасно обновляя интерфейс формы.
                        Invoke(new UpdateReceiveDisplayDelegate(UpdateReceiveDisplay), new object[] { (int)num, s });
                        // Принятое сообщение от клиента перенаправляем всем клиентам
                        // кроме текущего.
                        s = connectedClients[(int)num].Name + ": " + s;
                        SendToClients(s, (int)num);
                        s = string.Empty;
                    }
                    // Вынужденная строчка для экономия ресурсов процессора.
                    // Неизящный способ.
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    // Перехватим возможные исключения
                    //textBoxReceive.Text += ex.Message;
                    ErrorSound();
                }
                if (stopNetwork == true) break;
            }
        }
        #endregion
        #region Визуализация сетевой работы
        // Получение сообщений от клиентов
        public void UpdateReceiveDisplay(int clientnum, string message)
        {
            //listBox1.Items.Add(connectedClients[clientnum].Name + ": " + message);
            textBoxReceive.Text += connectedClients[clientnum].Name + ": " + message.ToString()+"\r\n";
            
        }
        // Делегат доступа к элементу формы textbox из вспомогательного потока.
        protected delegate void UpdateReceiveDisplayDelegate(int clientcount, string message);
        public void UpdateClientsDisplay()
        {
            listBoxClients.Items.Clear();
            for(int i=0; i<connectedClients.Count;i++)
            {
                listBoxClients.Items.Add(connectedClients[i].Name + ": " + connectedClients[i].IP.ToString());
            }
            label3.Text = countClient.ToString();
        }
        // Делегат доступа к элементу формы labelCountClient из вспомогательного потока.
        protected delegate void UpdateClientsDisplayDelegate();
        public void UpdateReceiveDisplay(EndPoint ip)
        {
            textBoxReceive.Text += "Получен запрос на подключение от " + ip.ToString();
        }
        protected delegate void UpdateReceiveConnectionDelegate(EndPoint ip);
        // Звуковое оповещение о перехваченной ошибке.
        private void ErrorSound()
        {
            Console.Beep(3000, 80);
            Console.Beep(1000, 100);
        }
        #endregion
    }
}