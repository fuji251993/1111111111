using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace UDPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(80);
                while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                listBox.Items.Add(RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban that su muon thoat chuong trinh ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}