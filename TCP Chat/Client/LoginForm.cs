using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class LoginForm : Form
    {
        public ClientSettings Client { get; set; }
        

        public LoginForm()
        {
            Client = new ClientSettings();
            InitializeComponent();
        }

        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(tbName.Text, tbPassword.Text))
            { 
                Client.Connected += Client_Connected;
                Client.Connect(txtIP.Text, 2014);
                Client.Send("Connect|" + tbName.Text + "|connected");
            }
            else MessageBox.Show("Invalid Name or Password!!!","Notification",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private bool IsvalidUser(string userName, string password)
        {
            //hash MD5
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tbPassword.Text);//plaintext to bytes
           
            byte[] hash = mh.ComputeHash(inputBytes);
          
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));//X2 in hoa, x2 in thuong
            }
            
            
            //check
            UserDBDataContext context = new UserDBDataContext();
            var q = from p in context.USERs
                    where p.UserName == tbName.Text
                    && p.HashPassword == sb.ToString()
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Client_Connected(object sender, EventArgs e)
        {
            this.Invoke(Close);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIP.Focus();
            }
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
            }
        }

        private void txtIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect.PerformClick();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbName.Focus();
        }
    }
}