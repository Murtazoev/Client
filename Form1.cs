using System.Net.Security;
using System.Text;
using System.Timers;
using System.Net;
using System.Net.Sockets;

namespace chat
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        static Socket client = Program.client;
        public Form1( )
        {
            InitializeComponent();
            SetTimer();
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {   
            string message = textBox1.Text;
            sendMessage(message);
        }

        private void sendMessage(String message){          
            byte[] buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(message);
            client.Send(buffer);
            // listBox1.Items.Add(message);
        }

        private async void receiveMessage(){
            byte[] buffer = new byte[1024];
            await client.ReceiveAsync(buffer);
            String message = Encoding.UTF8.GetString(buffer);
            if (message != null)
                listBox1.Items.Add(message);
        }
        private void SetTimer()
        {
            timer.Tick += new EventHandler(TimerEventProcessor);
        
            timer.Interval = 1000;
            timer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
           // receiveMessage();
        }
    }
}
