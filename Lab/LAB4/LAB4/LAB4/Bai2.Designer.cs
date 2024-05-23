namespace LAB4
{
    partial class Bai2
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
            this.textURL = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBoxUserAgent = new System.Windows.Forms.ComboBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // textURL
            // 
            this.textURL.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textURL.Location = new System.Drawing.Point(12, 12);
            this.textURL.Name = "textURL";
            this.textURL.Size = new System.Drawing.Size(476, 26);
            this.textURL.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(360, 47);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(118, 31);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(476, 650);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // comboBoxUserAgent
            // 
            this.comboBoxUserAgent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUserAgent.FormattingEnabled = true;
            this.comboBoxUserAgent.Location = new System.Drawing.Point(18, 50);
            this.comboBoxUserAgent.Name = "comboBoxUserAgent";
            this.comboBoxUserAgent.Size = new System.Drawing.Size(323, 27);
            this.comboBoxUserAgent.TabIndex = 4;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(494, 12);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(732, 730);
            this.webBrowser.TabIndex = 5;
            // 
            // Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 754);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.comboBoxUserAgent);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.textURL);
            this.Name = "Bai2";
            this.Text = "Bài 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textURL;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBoxUserAgent;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}