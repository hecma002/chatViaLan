using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;



namespace Server
{
    public partial class ViewDB : Form
    {
        public ViewDB()
        {
            InitializeComponent();
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;//
                dbDTGV.DataSource = db.USERs.Select(p=>p);
            }
        }
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private int idlength = 5;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;//
                dbDTGV.DataSource = db.USERs.Select(p => p);
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
                    string ID = dbDTGV.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                    USER delete = db.USERs.Where(p => p.ID.Equals(ID)).SingleOrDefault();
                    db.USERs.DeleteOnSubmit(delete);
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

                if (rbtnName.Checked == true)
                    dbDTGV.DataSource = db.USERs.Where(p => p.UserName.Equals(tbName.Text));
                
                if (rbtnID.Checked == true)
                    dbDTGV.DataSource = db.USERs.Where(p => p.ID.Equals(tbID.Text));
            }
            tbID.Text="";
            tbName.Text = "";
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }

        public bool DuplicateIDCheck(LanChatDBDataContext db ,string id)
        {
            bool notduplicate;
            var q = db.USERs.Where(p => p.ID.Equals(id));
            if (q.Any())
            {
                notduplicate = false;
            }
            else
            {
                notduplicate = true;
            }
            return notduplicate;
        }

        public bool DuplicateNameCheck(LanChatDBDataContext db, string name)
        {
            bool notduplicate;
            var q = db.USERs.Where(p => p.UserName.Equals(name));
            if (q.Any())
            {
                notduplicate = false;
            }
            else
            {
                notduplicate = true;
            }
            return notduplicate;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            
            using (LanChatDBDataContext db = new LanChatDBDataContext())
            {
                db.DeferredLoadingEnabled = false;//
                string id = dbDTGV.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                string name = dbDTGV.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                
                if (DuplicateNameCheck(db,name))
                {
                    
                    USER change = db.USERs.Where(p => p.ID.Equals(id)).SingleOrDefault();
                    //change.ID = id; khong the thay doi id vi id la khoa chinh
                    //khong can check id trung
                    change.UserName = name;
                    //change.HashPassword = pwd;
                    db.SubmitChanges();
                    MessageBox.Show("Success!");
                }
                else MessageBox.Show("Fail!");
            }
            btnRefresh_Click(sender, e);//refresh
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (idlength == (tbaID.Text).Length)
            {
                using (LanChatDBDataContext db = new LanChatDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;//
                    string id = tbaID.Text;
                    string name = tbaName.Text;
                    if (DuplicateIDCheck(db,id) && DuplicateNameCheck(db,name))
                    {
                        MD5 mh = MD5.Create();
                        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tbaPwd.Text);//plaintext to bytes

                        byte[] hash = mh.ComputeHash(inputBytes);

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; i++)
                        {
                            sb.Append(hash[i].ToString("X2"));//X2 in hoa, x2 in thuong
                        }

                        USER add = new USER();

                        add.ID = tbaID.Text;
                        add.UserName = tbaName.Text;
                        add.HashPassword = sb.ToString();

                        db.USERs.InsertOnSubmit(add);
                        db.SubmitChanges();
                        MessageBox.Show("Success!");
                    }
                    else MessageBox.Show("Duplicated data!");
                    btnRefresh_Click(sender, e);//refresh
                    tbaID.Text = "";
                    tbaName.Text = "";
                    tbaPwd.Text = "";
                }
            }
            else MessageBox.Show("Id's length must equal 5!!!");
        }
    }
}
