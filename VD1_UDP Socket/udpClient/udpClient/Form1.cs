using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace udpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nhap;
            nhap = txtnhap.Text;
            UdpClient udpClient = new UdpClient(); 
            udpClient.Connect(txtIP.Text, 80);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(nhap);
            udpClient.Send(sendBytes, sendBytes.Length);
        }
    }
}