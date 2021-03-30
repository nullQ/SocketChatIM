namespace ChatClient
{
    partial class MsgItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.user = new System.Windows.Forms.LinkLabel();
            this.time = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.lType = new System.Windows.Forms.Label();
            this.lPrivate = new System.Windows.Forms.Label();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(138, 3);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(65, 12);
            this.user.TabIndex = 0;
            this.user.TabStop = true;
            this.user.Text = "linkLabel1";
            this.user.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.user_LinkClicked);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(3, 3);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(41, 12);
            this.time.TabIndex = 1;
            this.time.Text = "label1";
            // 
            // pnHeader
            // 
            this.pnHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnHeader.Controls.Add(this.time);
            this.pnHeader.Controls.Add(this.lPrivate);
            this.pnHeader.Controls.Add(this.lType);
            this.pnHeader.Controls.Add(this.user);
            this.pnHeader.Location = new System.Drawing.Point(3, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Padding = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.pnHeader.Size = new System.Drawing.Size(345, 20);
            this.pnHeader.TabIndex = 2;
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.ForeColor = System.Drawing.Color.Green;
            this.lType.Location = new System.Drawing.Point(115, 3);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(17, 12);
            this.lType.TabIndex = 2;
            this.lType.Text = "[]";
            // 
            // lPrivate
            // 
            this.lPrivate.AutoSize = true;
            this.lPrivate.ForeColor = System.Drawing.Color.Blue;
            this.lPrivate.Location = new System.Drawing.Point(50, 3);
            this.lPrivate.Name = "lPrivate";
            this.lPrivate.Size = new System.Drawing.Size(59, 12);
            this.lPrivate.TabIndex = 3;
            this.lPrivate.Text = "[private]";
            // 
            // MsgItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnHeader);
            this.Name = "MsgItem";
            this.Size = new System.Drawing.Size(351, 23);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel user;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.FlowLayoutPanel pnHeader;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lPrivate;
    }
}
