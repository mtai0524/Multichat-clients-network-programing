namespace TCPChat
{
    partial class TCPChat
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
            this.results = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonListen = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.newText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.FormattingEnabled = true;
            this.results.ItemHeight = 16;
            this.results.Location = new System.Drawing.Point(48, 132);
            this.results.Margin = new System.Windows.Forms.Padding(4);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(580, 292);
            this.results.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Enter text String:";
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(530, 63);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(100, 28);
            this.ButtonConnect.TabIndex = 9;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            // 
            // ButtonListen
            // 
            this.ButtonListen.Location = new System.Drawing.Point(386, 15);
            this.ButtonListen.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonListen.Name = "ButtonListen";
            this.ButtonListen.Size = new System.Drawing.Size(100, 28);
            this.ButtonListen.TabIndex = 8;
            this.ButtonListen.Text = "Listen";
            this.ButtonListen.UseVisualStyleBackColor = true;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(386, 63);
            this.ButtonSend.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(100, 28);
            this.ButtonSend.TabIndex = 7;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(48, 63);
            this.newText.Margin = new System.Windows.Forms.Padding(4);
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(311, 22);
            this.newText.TabIndex = 6;
            // 
            // TCPChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 438);
            this.Controls.Add(this.results);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.ButtonListen);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.newText);
            this.Name = "TCPChat";
            this.Text = "TCPChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox results;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonListen;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.TextBox newText;
    }
}

