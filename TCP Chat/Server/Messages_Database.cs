using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Messages_Database : Form
    {
        public Messages_Database()
        {
            InitializeComponent();
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;
                dtgvMessage.DataSource = db.mMESSAGEs.Select(p => p);                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;
                dtgvMessage.DataSource = db.mMESSAGEs.Select(p => p);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete selected data?!", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                using (LanChatDBDataContext db = new LanChatDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;//
                    string IDs = dtgvMessage.SelectedCells[0].OwningRow.Cells["IDSender"].Value.ToString();
                    string IDr = dtgvMessage.SelectedCells[0].OwningRow.Cells["IDReciever"].Value.ToString();
                    mMESSAGE delete = db.mMESSAGEs.Where(p => p.IDSender.Equals(IDs) && p.IDReciever.Equals(IDr)).SingleOrDefault();
                    db.mMESSAGEs.DeleteOnSubmit(delete);
                    db.SubmitChanges();
                }
                btnRefresh_Click(sender, e);//refresh
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;//

                if (rbtnSender.Checked == true)
                    dtgvMessage.DataSource = db.mMESSAGEs.Where(p => p.IDSender.Equals(tbSender.Text));

                if (rbtnReciever.Checked == true)
                    dtgvMessage.DataSource = db.mMESSAGEs.Where(p => p.IDReciever.Equals(tbReciever.Text));
            }
            tbSender.Text = "";
            tbReciever.Text = "";
        }
    }
}
