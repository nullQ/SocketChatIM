namespace ChatClient
{
    partial class MainWindow
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
            this.list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tServer = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tPort = new System.Windows.Forms.NumericUpDown();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tMessage = new System.Windows.Forms.RichTextBox();
            this.bPic = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tPort)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.list.GridLines = true;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list.HideSelection = false;
            this.list.Location = new System.Drawing.Point(12, 12);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(202, 452);
            this.list.TabIndex = 0;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Online";
            this.columnHeader1.Width = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // tServer
            // 
            this.tServer.Location = new System.Drawing.Point(267, 13);
            this.tServer.Name = "tServer";
            this.tServer.Size = new System.Drawing.Size(89, 21);
            this.tServer.TabIndex = 5;
            this.tServer.Text = "127.0.0.1";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(505, 13);
            this.tName.MaxLength = 15;
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(110, 21);
            this.tName.TabIndex = 6;
            this.tName.Text = "hyjiacan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(401, 14);
            this.tPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(63, 21);
            this.tPort.TabIndex = 8;
            this.tPort.Value = new decimal(new int[] {
            9527,
            0,
            0,
            0});
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(621, 11);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 23);
            this.bConnect.TabIndex = 9;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSend.Location = new System.Drawing.Point(606, 438);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(91, 26);
            this.bSend.TabIndex = 10;
            this.bSend.Text = "&Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "<- Picker a user to send, or send to ALL.";
            // 
            // tMessage
            // 
            this.tMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tMessage.Location = new System.Drawing.Point(222, 396);
            this.tMessage.Name = "tMessage";
            this.tMessage.Size = new System.Drawing.Size(377, 68);
            this.tMessage.TabIndex = 12;
            this.tMessage.Text = "";
            // 
            // bPic
            // 
            this.bPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bPic.Location = new System.Drawing.Point(606, 401);
            this.bPic.Name = "bPic";
            this.bPic.Size = new System.Drawing.Size(90, 27);
            this.bPic.TabIndex = 13;
            this.bPic.Text = "Picture";
            this.bPic.UseVisualStyleBackColor = true;
            this.bPic.Click += new System.EventHandler(this.bPic_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "图片|*.png;*.bmp;*.gif*.jpg;*.jpeg";
            this.openFileDialog.Title = "Pick picture";
            // 
            // pnHistory
            // 
            this.pnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnHistory.AutoScroll = true;
            this.pnHistory.BackColor = System.Drawing.Color.White;
            this.pnHistory.Location = new System.Drawing.Point(222, 41);
            this.pnHistory.Name = "pnHistory";
            this.pnHistory.Size = new System.Drawing.Size(474, 312);
            this.pnHistory.TabIndex = 14;
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(472, 369);
            this.tbTarget.MaxLength = 15;
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(127, 21);
            this.tbTarget.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(605, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "<-Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.bSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 484);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.pnHistory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bPic);
            this.Controls.Add(this.tMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.tServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperSocketChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tServer;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tPort;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tMessage;
        private System.Windows.Forms.Button bPic;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel pnHistory;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.Button button1;
    }
}