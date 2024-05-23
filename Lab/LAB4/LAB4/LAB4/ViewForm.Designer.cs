namespace LAB4
{
    partial class ViewForm
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
            this.HTTPContent = new System.Windows.Forms.RichTextBox();
            this.listHeaderInfo = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // HTTPContent
            // 
            this.HTTPContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HTTPContent.Location = new System.Drawing.Point(8, 11);
            this.HTTPContent.Name = "HTTPContent";
            this.HTTPContent.Size = new System.Drawing.Size(509, 606);
            this.HTTPContent.TabIndex = 0;
            this.HTTPContent.Text = "";
            // 
            // listHeaderInfo
            // 
            this.listHeaderInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.Header,
            this.HeaderValue});
            this.listHeaderInfo.HideSelection = false;
            this.listHeaderInfo.Location = new System.Drawing.Point(523, 11);
            this.listHeaderInfo.Name = "listHeaderInfo";
            this.listHeaderInfo.Size = new System.Drawing.Size(377, 606);
            this.listHeaderInfo.TabIndex = 4;
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
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 629);
            this.Controls.Add(this.listHeaderInfo);
            this.Controls.Add(this.HTTPContent);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.Load += new System.EventHandler(this.ViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox HTTPContent;
        private System.Windows.Forms.ListView listHeaderInfo;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.ColumnHeader HeaderValue;
    }
}