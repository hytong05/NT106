namespace LAB4
{
    partial class Bai4
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
            this.URLtxt = new System.Windows.Forms.TextBox();
            this.Go_btn = new System.Windows.Forms.Button();
            this.Download_btn = new System.Windows.Forms.Button();
            this.View_btn = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // URLtxt
            // 
            this.URLtxt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLtxt.Location = new System.Drawing.Point(12, 12);
            this.URLtxt.Name = "URLtxt";
            this.URLtxt.Size = new System.Drawing.Size(637, 29);
            this.URLtxt.TabIndex = 0;
            // 
            // Go_btn
            // 
            this.Go_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Go_btn.Location = new System.Drawing.Point(655, 11);
            this.Go_btn.Name = "Go_btn";
            this.Go_btn.Size = new System.Drawing.Size(75, 29);
            this.Go_btn.TabIndex = 1;
            this.Go_btn.Text = "Go";
            this.Go_btn.UseVisualStyleBackColor = true;
            this.Go_btn.Click += new System.EventHandler(this.Go_btn_Click);
            // 
            // Download_btn
            // 
            this.Download_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Download_btn.Location = new System.Drawing.Point(736, 11);
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.Size = new System.Drawing.Size(106, 29);
            this.Download_btn.TabIndex = 2;
            this.Download_btn.Text = "Download";
            this.Download_btn.UseVisualStyleBackColor = true;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            // 
            // View_btn
            // 
            this.View_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_btn.Location = new System.Drawing.Point(848, 11);
            this.View_btn.Name = "View_btn";
            this.View_btn.Size = new System.Drawing.Size(75, 29);
            this.View_btn.TabIndex = 3;
            this.View_btn.Text = "View";
            this.View_btn.UseVisualStyleBackColor = true;
            this.View_btn.Click += new System.EventHandler(this.View_btn_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(12, 51);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(910, 537);
            this.webBrowser.TabIndex = 4;
            // 
            // Bai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 602);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.View_btn);
            this.Controls.Add(this.Download_btn);
            this.Controls.Add(this.Go_btn);
            this.Controls.Add(this.URLtxt);
            this.Name = "Bai4";
            this.Text = "Bai4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLtxt;
        private System.Windows.Forms.Button Go_btn;
        private System.Windows.Forms.Button Download_btn;
        private System.Windows.Forms.Button View_btn;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}