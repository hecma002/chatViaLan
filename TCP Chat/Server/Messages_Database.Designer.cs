namespace Server
{
    partial class Messages_Database
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvMessage = new System.Windows.Forms.DataGridView();
            this.rbtnReciever = new System.Windows.Forms.RadioButton();
            this.rbtnSender = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSender = new System.Windows.Forms.TextBox();
            this.tbReciever = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMessage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvMessage
            // 
            this.dtgvMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.dtgvMessage.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMessage.Location = new System.Drawing.Point(12, 12);
            this.dtgvMessage.Name = "dtgvMessage";
            this.dtgvMessage.RowTemplate.Height = 24;
            this.dtgvMessage.Size = new System.Drawing.Size(468, 352);
            this.dtgvMessage.TabIndex = 0;
            // 
            // rbtnReciever
            // 
            this.rbtnReciever.AutoSize = true;
            this.rbtnReciever.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnReciever.Location = new System.Drawing.Point(24, 132);
            this.rbtnReciever.Name = "rbtnReciever";
            this.rbtnReciever.Size = new System.Drawing.Size(113, 21);
            this.rbtnReciever.TabIndex = 1;
            this.rbtnReciever.TabStop = true;
            this.rbtnReciever.Text = "ID Reciever";
            this.rbtnReciever.UseVisualStyleBackColor = true;
            // 
            // rbtnSender
            // 
            this.rbtnSender.AutoSize = true;
            this.rbtnSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSender.Location = new System.Drawing.Point(24, 38);
            this.rbtnSender.Name = "rbtnSender";
            this.rbtnSender.Size = new System.Drawing.Size(101, 21);
            this.rbtnSender.TabIndex = 1;
            this.rbtnSender.TabStop = true;
            this.rbtnSender.Text = "ID Sender";
            this.rbtnSender.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbSender);
            this.groupBox1.Controls.Add(this.tbReciever);
            this.groupBox1.Controls.Add(this.rbtnSender);
            this.groupBox1.Controls.Add(this.rbtnReciever);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(486, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 284);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Searching";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(79, 211);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 52);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSender
            // 
            this.tbSender.Location = new System.Drawing.Point(24, 65);
            this.tbSender.Name = "tbSender";
            this.tbSender.Size = new System.Drawing.Size(258, 27);
            this.tbSender.TabIndex = 2;
            // 
            // tbReciever
            // 
            this.tbReciever.Location = new System.Drawing.Point(24, 159);
            this.tbReciever.Name = "tbReciever";
            this.tbReciever.Size = new System.Drawing.Size(258, 27);
            this.tbReciever.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(645, 312);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(143, 52);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "     Refresh       (View all)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(486, 312);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 52);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Messages_Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 376);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgvMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Messages_Database";
            this.Text = "Messages Database";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMessage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvMessage;
        private System.Windows.Forms.RadioButton rbtnReciever;
        private System.Windows.Forms.RadioButton rbtnSender;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSender;
        private System.Windows.Forms.TextBox tbReciever;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
    }
}