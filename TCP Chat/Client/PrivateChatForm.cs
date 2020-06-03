using System;
using System.Windows.Forms;

namespace Client
{
    public partial class PrivateChatForm : Form
    {
        public PublicChatForm pChat;
        public string nameprchat;//ten de hien thi tren khung
        public PrivateChatForm(PublicChatForm pchat)
        {
            InitializeComponent();
            pChat = pchat;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = pChat.formLogin.tbName.Text + " to " + nameprchat;//ten form chat
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (txtInput.Text != string.Empty)
            {
                //string user = Text.Split('-')[1];
                //pChat.formLogin.Client.Send("pMessage|" + user + "|" + txtInput.Text);
                //txtReceive.Text += user + " says: " + txtInput.Text + "\r\n";
                //txtInput.Text = string.Empty;
                if(nameprchat!="Server")
                {
                    //chat thanh cong voi user
                    pChat.formLogin.Client.Send("pChatwithUser|" + pChat.formLogin.tbName.Text + "|" + txtInput.Text + "|" + nameprchat);
                    txtReceive.Text += pChat.formLogin.tbName.Text + ": " + txtInput.Text + "\r\n";
                    txtInput.Text = string.Empty;
                }
                else
                {
                    pChat.formLogin.Client.Send("pMessage|" + pChat.formLogin.tbName.Text + "|" + txtInput.Text);
                    txtReceive.Text += pChat.formLogin.tbName.Text + ": " + txtInput.Text + "\r\n";
                    txtInput.Text = string.Empty;
                }
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
    }
}