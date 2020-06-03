using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Main : Form
    {
        private readonly Listener listener;

        public List<Socket> clients = new List<Socket>(); // store all the clients into a list

        public void BroadcastData(string data) // send to all clients
        {
            foreach (var socket in clients)
            {
                try { socket.Send(Encoding.ASCII.GetBytes(data)); }
                catch (Exception) { }
            }
        }

        public Main()
        {
            pChat = new PrivateChat(this);
            InitializeComponent();
            listener = new Listener(2014);
            listener.SocketAccepted += listener_SocketAccepted;
        }

        private void listener_SocketAccepted(Socket e)
        {
            var client = new Client(e);
            client.Received += client_Received;
            client.Disconnected += client_Disconnected;
            this.Invoke(() =>
            {
                string ip = client.Ip.ToString().Split(':')[0];
                var item = new ListViewItem(ip); // ip
                item.SubItems.Add(" "); // nickname
                item.SubItems.Add(" "); // status
                item.Tag = client;
                clientList.Items.Add(item);
                clients.Add(e);
            });
        }

        private void client_Disconnected(Client sender)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < clientList.Items.Count; i++)
                {
                    var client = clientList.Items[i].Tag as Client;
                    if (client.Ip == sender.Ip)
                    {
                        txtReceive.Text += "<< " + clientList.Items[i].SubItems[1].Text + " has left the room >>\r\n";
                        BroadcastData("RefreshChat|" + txtReceive.Text);
                        clientList.Items.RemoveAt(i);
                    }
                }
            });
        }

        private PrivateChat pChat;

        private void client_Received(Client sender, byte[] data)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < clientList.Items.Count; i++)
                {
                    var client = clientList.Items[i].Tag as Client;
                    if (client == null || client.Ip != sender.Ip) continue;
                    var command = Encoding.ASCII.GetString(data).Split('|');
                    switch (command[0])
                    {
                        case "Connect":
                            //txtReceive.SelectionColor = System.Drawing.Color.Red;

                            txtReceive.Text += "<< " + command[1] + " joined the room >>\r\n";
                            
                            clientList.Items[i].SubItems[1].Text = command[1]; // nickname
                            clientList.Items[i].SubItems[2].Text = command[2]; // status
                            string users = string.Empty;
                            for (int j = 0; j < clientList.Items.Count; j++)
                            {
                                users += clientList.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData("Users|" + users.TrimEnd('|'));
                            BroadcastData("RefreshChat|" + command[1]);//nguoi vao sau khong thay nguoi vao truoc join room
                            break;
                        case "Message":
                            //public chat
                            txtReceive.Text += command[1] + ": " + command[2] + "\r\n";
                            BroadcastData("RefreshChat|" + command[1] + "|" + command[2]);
                            //***save message
                            using (LanChatDBDataContext db = new LanChatDBDataContext())
                            {
                                db.DeferredLoadingEnabled = false;

                                mMESSAGE mes = new mMESSAGE();
                                
                                var id = from Id in db.USERs
                                         where Id.UserName == command[1].ToString()
                                         select Id.ID;//lay id tu table users

                                string newid = id.FirstOrDefault().ToString();
                                var conversation = from c in db.mMESSAGEs
                                                   where c.IDSender == newid && c.IDReciever == "PUBLI"
                                                   select c;
                                if (conversation.Any())//co ton tai roi
                                {
                                    mMESSAGE nmes = conversation.First();
                                    nmes.Content += command[1] + ": " + command[2] + "|";
                                    
                                    db.SubmitChanges();
                                }
                                else//chua ton tai
                                {
                                    mes.IDSender = newid;
                                    mes.IDReciever = "PUBLI";
                                    mes.Content = command[1] + ": " + command[2] + "|";
                                    db.mMESSAGEs.InsertOnSubmit(mes);
                                    db.SubmitChanges();
                                }
                            }
                            //save message***
                            break;
                        case "pMessage":
                            //private chat client voi server
                            this.Invoke(() =>
                            {
                                pChat.txtReceive.Text += command[1] + ": " + command[2] + "\r\n";
                                //***save message
                                using (LanChatDBDataContext db = new LanChatDBDataContext())
                                {
                                    db.DeferredLoadingEnabled = false;

                                    mMESSAGE mes = new mMESSAGE();

                                    var id = from Id in db.USERs
                                             where Id.UserName == command[1].ToString()
                                             select Id.ID;//lay id tu table users

                                    string newid = id.FirstOrDefault().ToString();
                                    var conversation = from c in db.mMESSAGEs
                                                       where c.IDSender == newid && c.IDReciever == "SERVE"
                                                       select c;
                                    if (conversation.Any())//co ton tai roi
                                    {
                                        mMESSAGE nmes = conversation.First();
                                        nmes.Content += command[1] + ": " + command[2] + "|";

                                        db.SubmitChanges();
                                    }
                                    else//chua ton tai
                                    {
                                        mes.IDSender = newid;
                                        mes.IDReciever = "SERVE";
                                        mes.Content = command[1] + ": " + command[2] + "|";
                                        db.mMESSAGEs.InsertOnSubmit(mes);
                                        db.SubmitChanges();
                                    }
                                }
                            });
                            break;
                        case "pChat":

                            break;
                        case "pChatwithUser":
                            //private chat client voi client
                            this.Invoke(() =>
                            {
                                if (command[3] != "Server")
                                {
                                    txtReceive.Text += command[1] + " to " + command[3] + ": " + command[2] + "\r\n";
                                    string onlychat = Encoding.ASCII.GetString(data);
                                    BroadcastData(onlychat);
                                    //***save message
                                    using (LanChatDBDataContext db = new LanChatDBDataContext())
                                    {
                                        db.DeferredLoadingEnabled = false;

                                        mMESSAGE mes = new mMESSAGE();

                                        var id1 = from Id in db.USERs
                                                 where Id.UserName == command[1].ToString()
                                                 select Id.ID;//lay id tu table users

                                        var id2 = from Id in db.USERs
                                                  where Id.UserName == command[3].ToString()
                                                  select Id.ID;//lay id tu table users


                                        string newid = id1.FirstOrDefault().ToString();
                                        string newid2 = id2.FirstOrDefault().ToString();
                                        var conversation = from c in db.mMESSAGEs
                                                           where c.IDSender == newid && c.IDReciever == newid2
                                                           select c;
                                        if (conversation.Any())//co ton tai roi
                                        {
                                            mMESSAGE nmes = conversation.First();
                                            nmes.Content += command[1] + ": " + command[2] + "|";

                                            db.SubmitChanges();
                                        }
                                        else//chua ton tai
                                        {
                                            mes.IDSender = newid;
                                            mes.IDReciever = newid2;
                                            mes.Content = command[1] + ": " + command[2] + "|";
                                            db.mMESSAGEs.InsertOnSubmit(mes);
                                            db.SubmitChanges();
                                        }
                                    }

                                }
                            });
                            break;
                    }
                }
            });
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
        private void Main_Load(object sender, EventArgs e)
        {
            string ServerIP = GetLocalIPAddress();
            label1.Text = "Server IP: " + ServerIP;
            listener.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            listener.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                BroadcastData("Message|Admin|" + txtInput.Text);
                txtReceive.Text += "Admin: " + txtInput.Text + "\r\n";
                //***save message
                using (LanChatDBDataContext db = new LanChatDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;

                    mMESSAGE mes = new mMESSAGE();                                       
                    
                    var conversation = from c in db.mMESSAGEs
                                       where c.IDSender == "SERVE" && c.IDReciever == "PUBLI"
                                       select c;
                    if (conversation.Any())//co ton tai roi
                    {
                        mMESSAGE nmes = conversation.First();
                        nmes.Content += "Admin:" + txtInput.Text + "|";

                        db.SubmitChanges();
                    }
                    else//chua ton tai
                    {
                        mes.IDSender = "SERVE";
                        mes.IDReciever = "PUBLI";
                        mes.Content = "Admin:" + txtInput.Text + "|";
                        db.mMESSAGEs.InsertOnSubmit(mes);
                        db.SubmitChanges();
                    }
                }
                //save message***
                txtInput.Text = "";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in clientList.SelectedItems select (Client) item.Tag)
            {
                client.Send("Disconnect|");
            }
        }

        private void chatWithClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in clientList.SelectedItems select (Client) item.Tag)
            {
                client.Send("Chat|");
                pChat = new PrivateChat(this);
                pChat.Show();
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

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewDB viewDB = new ViewDB();
            viewDB.Show();
        }

        private void button1_Click(object sender, EventArgs e)//Messages Database
        {
            Messages_Database mdb = new Messages_Database();
            mdb.Show();
        }
    }
}