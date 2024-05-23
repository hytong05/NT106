namespace LAB4
{
    partial class Bai1
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
            this.buttonDownload = new System.Windows.Forms.Button();
            this.HTTPContent = new System.Windows.Forms.RichTextBox();
            this.listHeaderInfo = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textURL
            // 
            this.textURL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textURL.Location = new System.Drawing.Point(12, 24);
            this.textURL.Name = "textURL";
            this.textURL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textURL.Size = new System.Drawing.Size(480, 29);
            this.textURL.TabIndex = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDownload.Location = new System.Drawing.Point(498, 18);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(133, 38);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // HTTPContent
            // 
            this.HTTPContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HTTPContent.Location = new System.Drawing.Point(12, 72);
            this.HTTPContent.Name = "HTTPContent";
            this.HTTPContent.Size = new System.Drawing.Size(479, 366);
            this.HTTPContent.TabIndex = 2;
            this.HTTPContent.Text = "";
            // 
            // listHeaderInfo
            // 
            this.listHeaderInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.Header,
            this.HeaderValue});
            this.listHeaderInfo.HideSelection = false;
            this.listHeaderInfo.Location = new System.Drawing.Point(498, 70);
            this.listHeaderInfo.Name = "listHeaderInfo";
            this.listHeaderInfo.Size = new System.Drawing.Size(377, 365);
            this.listHeaderInfo.TabIndex = 3;
            this.listHeaderInfo.UseCompatibleStateImageBehavior = false;
            this.listHeaderInfo.View = System.Windows.Forms.View.Details;
            // 
            // STT
            // 
            this.STT.Text = "STT";
            this.STT.Width = 46;
            // 
            // Header
            // 
            this.Header.Text = "Header";
            this.Header.Width = 140;
            // 
            // HeaderValue
            // 
            this.HeaderValue.Text = "Value";
            this.HeaderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HeaderValue.Width = 200;
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.listHeaderInfo);
            this.Controls.Add(this.HTTPContent);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textURL);
            this.Name = "Bai1";
            this.Text = "Bài 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textURL;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.RichTextBox HTTPContent;
        private System.Windows.Forms.ListView listHeaderInfo;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.ColumnHeader HeaderValue;
    }
}