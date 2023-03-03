
namespace SocketClient
{
    partial class Form1
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
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.ccbNguoiGui = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ccbNguoiNhan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(13, 67);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(433, 294);
            this.tbLog.TabIndex = 0;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(13, 368);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(343, 62);
            this.tbMessage.TabIndex = 1;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(363, 368);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(83, 62);
            this.btSend.TabIndex = 2;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // ccbNguoiGui
            // 
            this.ccbNguoiGui.FormattingEnabled = true;
            this.ccbNguoiGui.Items.AddRange(new object[] {
            "Hoa",
            "Lan",
            "Binh",
            "Trung",
            "Hai",
            "Nam",
            "Thu"});
            this.ccbNguoiGui.Location = new System.Drawing.Point(71, 10);
            this.ccbNguoiGui.Name = "ccbNguoiGui";
            this.ccbNguoiGui.Size = new System.Drawing.Size(121, 21);
            this.ccbNguoiGui.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nguoi gui";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nguoi nhan";
            // 
            // ccbNguoiNhan
            // 
            this.ccbNguoiNhan.FormattingEnabled = true;
            this.ccbNguoiNhan.Items.AddRange(new object[] {
            "Hoa",
            "Lan",
            "Binh",
            "Trung",
            "Hai",
            "Nam",
            "Thu"});
            this.ccbNguoiNhan.Location = new System.Drawing.Point(325, 10);
            this.ccbNguoiNhan.Name = "ccbNguoiNhan";
            this.ccbNguoiNhan.Size = new System.Drawing.Size(121, 21);
            this.ccbNguoiNhan.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 442);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ccbNguoiNhan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ccbNguoiGui);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbLog);
            this.Name = "Form1";
            this.Text = "Socket Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.ComboBox ccbNguoiGui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ccbNguoiNhan;
    }
}

