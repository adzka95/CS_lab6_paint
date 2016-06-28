namespace lab6v2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adresIP = new System.Windows.Forms.TextBox();
            this.numerPortu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.czarny = new System.Windows.Forms.Button();
            this.czerwony = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(587, 479);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.klik);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rusza);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.konczy);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // adresIP
            // 
            this.adresIP.Location = new System.Drawing.Point(646, 23);
            this.adresIP.Name = "adresIP";
            this.adresIP.Size = new System.Drawing.Size(100, 20);
            this.adresIP.TabIndex = 3;
            this.adresIP.Text = "172.20.16.177";
            // 
            // numerPortu
            // 
            this.numerPortu.Location = new System.Drawing.Point(646, 56);
            this.numerPortu.Name = "numerPortu";
            this.numerPortu.Size = new System.Drawing.Size(100, 20);
            this.numerPortu.TabIndex = 4;
            this.numerPortu.Text = "1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(646, 93);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Nie podlaczono";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Polacz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.polaczDoSerwera);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(623, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Rozlacz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.odlaczOdSerwera);
            // 
            // czarny
            // 
            this.czarny.BackColor = System.Drawing.Color.Black;
            this.czarny.Location = new System.Drawing.Point(623, 209);
            this.czarny.Name = "czarny";
            this.czarny.Size = new System.Drawing.Size(123, 23);
            this.czarny.TabIndex = 9;
            this.czarny.UseVisualStyleBackColor = false;
            this.czarny.Click += new System.EventHandler(this.ustawCzarny);
            // 
            // czerwony
            // 
            this.czerwony.BackColor = System.Drawing.Color.Red;
            this.czerwony.Location = new System.Drawing.Point(623, 238);
            this.czerwony.Name = "czerwony";
            this.czerwony.Size = new System.Drawing.Size(123, 24);
            this.czerwony.TabIndex = 10;
            this.czerwony.UseVisualStyleBackColor = false;
            this.czerwony.Click += new System.EventHandler(this.ustawCzerwony);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Kolor:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 503);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.czerwony);
            this.Controls.Add(this.czarny);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numerPortu);
            this.Controls.Add(this.adresIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adresIP;
        private System.Windows.Forms.TextBox numerPortu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button czarny;
        private System.Windows.Forms.Button czerwony;
        private System.Windows.Forms.Label label4;
    }
}

