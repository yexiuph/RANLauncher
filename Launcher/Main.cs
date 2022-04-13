using System;
using System.Windows.Forms;
using YXPHStudios;
using System.Net.Sockets;

namespace Launcher
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        Http Data = new Http();

        private void Launcher_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel1.Visible = false;
                LoginPanel.Visible = true;
            } else
            {
                MessageBox.Show("Please agree to continue", "Error");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter your username/password.", "Error");
            } else
            {

                    await Data.FindUserAsync(textBox1.Text, textBox2.Text);
   
                
            }
            
        }

        public static bool IsAPIAlive(String hostName)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    tcpClient.Connect(hostName, 3268);
                    return true;
                }
            }
            catch (SocketException)
            {

                return false;
            }
        }
    }
}
