namespace LAB4
{
    partial class Bai3
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeInfor = new System.Windows.Forms.Label();
            this.weatherDescriptionInfor = new System.Windows.Forms.Label();
            this.cityNameInfor = new System.Windows.Forms.Label();
            this.temperatureInfor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.countryCodeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cityNameText = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.timeInfor);
            this.groupBox2.Controls.Add(this.weatherDescriptionInfor);
            this.groupBox2.Controls.Add(this.cityNameInfor);
            this.groupBox2.Controls.Add(this.temperatureInfor);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(265, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(270, 212);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weather Nowcasts";
            // 
            // timeInfor
            // 
            this.timeInfor.AutoSize = true;
            this.timeInfor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInfor.Location = new System.Drawing.Point(24, 39);
            this.timeInfor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.timeInfor.Name = "timeInfor";
            this.timeInfor.Size = new System.Drawing.Size(41, 19);
            this.timeInfor.TabIndex = 3;
            this.timeInfor.Text = "Time:";
            // 
            // weatherDescriptionInfor
            // 
            this.weatherDescriptionInfor.AutoSize = true;
            this.weatherDescriptionInfor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherDescriptionInfor.Location = new System.Drawing.Point(24, 164);
            this.weatherDescriptionInfor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.weatherDescriptionInfor.Name = "weatherDescriptionInfor";
            this.weatherDescriptionInfor.Size = new System.Drawing.Size(136, 19);
            this.weatherDescriptionInfor.TabIndex = 2;
            this.weatherDescriptionInfor.Text = "Weather Description:";
            // 
            // cityNameInfor
            // 
            this.cityNameInfor.AutoSize = true;
            this.cityNameInfor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityNameInfor.Location = new System.Drawing.Point(24, 75);
            this.cityNameInfor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cityNameInfor.Name = "cityNameInfor";
            this.cityNameInfor.Size = new System.Drawing.Size(73, 19);
            this.cityNameInfor.TabIndex = 1;
            this.cityNameInfor.Text = "City name:";
            // 
            // temperatureInfor
            // 
            this.temperatureInfor.AutoSize = true;
            this.temperatureInfor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureInfor.Location = new System.Drawing.Point(24, 118);
            this.temperatureInfor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.temperatureInfor.Name = "temperatureInfor";
            this.temperatureInfor.Size = new System.Drawing.Size(88, 19);
            this.temperatureInfor.TabIndex = 0;
            this.temperatureInfor.Text = "Temperature:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.countryCodeText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cityNameText);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(227, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Country code:";
            // 
            // countryCodeText
            // 
            this.countryCodeText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryCodeText.Location = new System.Drawing.Point(17, 118);
            this.countryCodeText.Margin = new System.Windows.Forms.Padding(1);
            this.countryCodeText.Name = "countryCodeText";
            this.countryCodeText.Size = new System.Drawing.Size(118, 26);
            this.countryCodeText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "City name:";
            // 
            // cityNameText
            // 
            this.cityNameText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityNameText.Location = new System.Drawing.Point(17, 53);
            this.cityNameText.Margin = new System.Windows.Forms.Padding(1);
            this.cityNameText.Name = "cityNameText";
            this.cityNameText.Size = new System.Drawing.Size(194, 26);
            this.cityNameText.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(90, 202);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 34);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.Name = "Bai3";
            this.Text = "Bài 3";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label timeInfor;
        private System.Windows.Forms.Label weatherDescriptionInfor;
        private System.Windows.Forms.Label cityNameInfor;
        private System.Windows.Forms.Label temperatureInfor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox countryCodeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cityNameText;
        private System.Windows.Forms.Button btnLoad;
    }
}