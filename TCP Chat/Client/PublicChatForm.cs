using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;

namespace Client
{
    public partial class PublicChatForm : Form
    {

        
        public PublicChatForm()
        {
            pChat = new PrivateChatForm(this);
            InitializeComponent();
        }
        
        public readonly LoginForm formLogin = new LoginForm();//data login form

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            formLogin.Client.Received += _client_Received;
            formLogin.Client.Disconnected += Client_Disconnected;
           

            formLogin.ShowDialog();
            Text = "<<" + formLogin.tbName.Text + ">>";
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
        private static void Client_Disconnected(ClientSettings cs)
        {
            
        }

        private readonly PrivateChatForm pChat;

        public void _client_Received(ClientSettings cs, string received)
        {
            var cmd = received.Split('|');
            switch (cmd[0])
            {
                case "Users":
                    this.Invoke(() =>
                    {
                        userList.Items.Clear();
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            if (cmd[i] != "Connected" | cmd[i] != "RefreshChat")
                            {
                                userList.Items.Add(cmd[i]);
                            }
                        }
                    });
                    break;
                case "Message":
                    this.Invoke(() =>
                    {
                        txtReceive.Text += cmd[1] + ": " + cmd[2] + "\r\n";
                    });
                    break;
                case "RefreshChat":
                    this.Invoke(() =>
                    {
                        if(cmd.Length<3)
                        {
                            txtReceive.Text += "<<" + cmd[1] + " joined the room >>\r\n"; 
                        }
                        else
                        {
                            if (cmd[1] != formLogin.tbName.Text.ToString())
                                txtReceive.Text += cmd[1] + ": " + cmd[2] + "\r\n";
                        }
                    });
                    break;
                case "Chat":
                    this.Invoke(() =>
                    {
                        pChat.nameprchat = "Server";
                        pChat.Text = formLogin.tbName.Text + " to Server ";
                        pChat.Show();
                    });
                    break;
                case "pMessage":
                    this.Invoke(() =>
                    {
                        pChat.txtReceive.Text += "Admin: " + cmd[1] + "\r\n";
                    });
                    break;
                case "pChatwithUser":
                    this.Invoke(() =>
                    {
                        //chat private thanh cong voi user khac
                        if(cmd[3]==formLogin.tbName.Text)
                        {
                            pChat.nameprchat = cmd[1];
                            pChat.Show();
                            pChat.txtReceive.Text += cmd[1] + ": " + cmd[2] + "\r\n";
                        }
                    });
                    break;
                //case "Picture":
                //    this.Invoke(() => { });
                case "Disconnect":
                    Application.Exit();
                    break;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                formLogin.Client.Send("Message|" + formLogin.tbName.Text + "|" + txtInput.Text);
                txtReceive.Text += formLogin.tbName.Text + ": " + txtInput.Text + "\r\n";
                txtInput.Text = string.Empty;
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.SelectionStart = txtReceive.TextLength;
        }

        private void privateChat_Click(object sender, EventArgs e)
        {
        //    formLogin.Client.Send("pChat|" + formLogin.tbName.Text);
            
        }



        //them tu day - gui Hinh Anh
        string bPic;//byte picture
        string picAddress;

        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picAddress = openFile.FileName;
                bPic = Convert.ToBase64String(converImgToByte());
            }

            formLogin.Client.Send("Message|" + formLogin.tbName.Text + "|" + bPic);//gui bPic
            txtReceive.Text += formLogin.tbName.Text + "sends a pic: " + bPic + "\r\n";
                        
        }
       
        private byte[] converImgToByte()
        {
            FileStream fs;
            fs = new FileStream(picAddress, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            pChat.nameprchat = userList.SelectedItem.ToString();//ten cua client yeu cau chat private
            formLogin.Client.Send("pChat|" + formLogin.tbName.Text + "|" + userList.SelectedItem.ToString());
            pChat.Show();
        }
    }
}