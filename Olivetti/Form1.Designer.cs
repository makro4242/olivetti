namespace Olivetti
{
    partial class frmAnaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnaForm));
            this.btnayarlar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlkartaktarmagrubu = new System.Windows.Forms.Panel();
            this.rdbtnHepsi = new System.Windows.Forms.RadioButton();
            this.rdbtnTarihsel = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.rdbtnTarihsel2 = new System.Windows.Forms.RadioButton();
            this.rdbtnHepsi2 = new System.Windows.Forms.RadioButton();
            this.dtHareket2 = new System.Windows.Forms.DateTimePicker();
            this.dtHareket1 = new System.Windows.Forms.DateTimePicker();
            this.lblkasalarahareketaktarimi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grpKasalar = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAktar = new System.Windows.Forms.Button();
            this.lblHareketAktarma = new System.Windows.Forms.Label();
            this.lblkasalarabilgigonder = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.pnlkartaktarmagrubu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnayarlar
            // 
            this.btnayarlar.Location = new System.Drawing.Point(591, 9);
            this.btnayarlar.Name = "btnayarlar";
            this.btnayarlar.Size = new System.Drawing.Size(75, 23);
            this.btnayarlar.TabIndex = 0;
            this.btnayarlar.Text = "Ayarlar";
            this.btnayarlar.UseVisualStyleBackColor = true;
            this.btnayarlar.Click += new System.EventHandler(this.btnayarlar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pnlkartaktarmagrubu);
            this.panel1.Controls.Add(this.rdbtnTarihsel2);
            this.panel1.Controls.Add(this.rdbtnHepsi2);
            this.panel1.Controls.Add(this.dtHareket2);
            this.panel1.Controls.Add(this.dtHareket1);
            this.panel1.Controls.Add(this.lblkasalarahareketaktarimi);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.grpKasalar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAktar);
            this.panel1.Controls.Add(this.lblHareketAktarma);
            this.panel1.Controls.Add(this.lblkasalarabilgigonder);
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 315);
            this.panel1.TabIndex = 3;
            // 
            // pnlkartaktarmagrubu
            // 
            this.pnlkartaktarmagrubu.Controls.Add(this.rdbtnHepsi);
            this.pnlkartaktarmagrubu.Controls.Add(this.rdbtnTarihsel);
            this.pnlkartaktarmagrubu.Controls.Add(this.dateTimePicker1);
            this.pnlkartaktarmagrubu.Controls.Add(this.dateTimePicker2);
            this.pnlkartaktarmagrubu.Location = new System.Drawing.Point(15, 57);
            this.pnlkartaktarmagrubu.Name = "pnlkartaktarmagrubu";
            this.pnlkartaktarmagrubu.Size = new System.Drawing.Size(288, 54);
            this.pnlkartaktarmagrubu.TabIndex = 23;
            // 
            // rdbtnHepsi
            // 
            this.rdbtnHepsi.AutoSize = true;
            this.rdbtnHepsi.Location = new System.Drawing.Point(3, 3);
            this.rdbtnHepsi.Name = "rdbtnHepsi";
            this.rdbtnHepsi.Size = new System.Drawing.Size(52, 17);
            this.rdbtnHepsi.TabIndex = 8;
            this.rdbtnHepsi.TabStop = true;
            this.rdbtnHepsi.Text = "Hepsi";
            this.rdbtnHepsi.UseVisualStyleBackColor = true;
            // 
            // rdbtnTarihsel
            // 
            this.rdbtnTarihsel.AutoSize = true;
            this.rdbtnTarihsel.Location = new System.Drawing.Point(3, 34);
            this.rdbtnTarihsel.Name = "rdbtnTarihsel";
            this.rdbtnTarihsel.Size = new System.Drawing.Size(62, 17);
            this.rdbtnTarihsel.TabIndex = 9;
            this.rdbtnTarihsel.TabStop = true;
            this.rdbtnTarihsel.Text = "Tarihsel";
            this.rdbtnTarihsel.UseVisualStyleBackColor = true;
            this.rdbtnTarihsel.CheckedChanged += new System.EventHandler(this.rdbtnTarihsel_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(181, 30);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dateTimePicker2.Visible = false;
            // 
            // rdbtnTarihsel2
            // 
            this.rdbtnTarihsel2.AutoSize = true;
            this.rdbtnTarihsel2.Location = new System.Drawing.Point(320, 83);
            this.rdbtnTarihsel2.Name = "rdbtnTarihsel2";
            this.rdbtnTarihsel2.Size = new System.Drawing.Size(62, 17);
            this.rdbtnTarihsel2.TabIndex = 22;
            this.rdbtnTarihsel2.TabStop = true;
            this.rdbtnTarihsel2.Text = "Tarihsel";
            this.rdbtnTarihsel2.UseVisualStyleBackColor = true;
            this.rdbtnTarihsel2.CheckedChanged += new System.EventHandler(this.rdbtnTarihsel2_CheckedChanged);
            // 
            // rdbtnHepsi2
            // 
            this.rdbtnHepsi2.AutoSize = true;
            this.rdbtnHepsi2.Location = new System.Drawing.Point(319, 57);
            this.rdbtnHepsi2.Name = "rdbtnHepsi2";
            this.rdbtnHepsi2.Size = new System.Drawing.Size(52, 17);
            this.rdbtnHepsi2.TabIndex = 21;
            this.rdbtnHepsi2.TabStop = true;
            this.rdbtnHepsi2.Text = "Hepsi";
            this.rdbtnHepsi2.UseVisualStyleBackColor = true;
            // 
            // dtHareket2
            // 
            this.dtHareket2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHareket2.Location = new System.Drawing.Point(489, 80);
            this.dtHareket2.Name = "dtHareket2";
            this.dtHareket2.Size = new System.Drawing.Size(94, 20);
            this.dtHareket2.TabIndex = 20;
            this.dtHareket2.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtHareket2.Visible = false;
            // 
            // dtHareket1
            // 
            this.dtHareket1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHareket1.Location = new System.Drawing.Point(389, 80);
            this.dtHareket1.Name = "dtHareket1";
            this.dtHareket1.Size = new System.Drawing.Size(94, 20);
            this.dtHareket1.TabIndex = 19;
            this.dtHareket1.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtHareket1.Visible = false;
            // 
            // lblkasalarahareketaktarimi
            // 
            this.lblkasalarahareketaktarimi.AutoSize = true;
            this.lblkasalarahareketaktarimi.Location = new System.Drawing.Point(317, 33);
            this.lblkasalarahareketaktarimi.Name = "lblkasalarahareketaktarimi";
            this.lblkasalarahareketaktarimi.Size = new System.Drawing.Size(149, 13);
            this.lblkasalarahareketaktarimi.TabIndex = 18;
            this.lblkasalarahareketaktarimi.Text = "Kasalara Stok Kartı Gönderme";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Aktar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpKasalar
            // 
            this.grpKasalar.Location = new System.Drawing.Point(320, 109);
            this.grpKasalar.Name = "grpKasalar";
            this.grpKasalar.Size = new System.Drawing.Size(263, 171);
            this.grpKasalar.TabIndex = 16;
            this.grpKasalar.TabStop = false;
            this.grpKasalar.Text = "Kasalar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kart Aktarma";
            // 
            // btnAktar
            // 
            this.btnAktar.Location = new System.Drawing.Point(14, 286);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(75, 23);
            this.btnAktar.TabIndex = 6;
            this.btnAktar.Text = "Aktar";
            this.btnAktar.UseVisualStyleBackColor = true;
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // lblHareketAktarma
            // 
            this.lblHareketAktarma.AutoSize = true;
            this.lblHareketAktarma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHareketAktarma.Location = new System.Drawing.Point(316, 1);
            this.lblHareketAktarma.Name = "lblHareketAktarma";
            this.lblHareketAktarma.Size = new System.Drawing.Size(145, 20);
            this.lblHareketAktarma.TabIndex = 2;
            this.lblHareketAktarma.Text = "Hareket Aktarma";
            // 
            // lblkasalarabilgigonder
            // 
            this.lblkasalarabilgigonder.AutoSize = true;
            this.lblkasalarabilgigonder.Location = new System.Drawing.Point(12, 33);
            this.lblkasalarabilgigonder.Name = "lblkasalarabilgigonder";
            this.lblkasalarabilgigonder.Size = new System.Drawing.Size(149, 13);
            this.lblkasalarabilgigonder.TabIndex = 3;
            this.lblkasalarabilgigonder.Text = "Kasalara Stok Kartı Gönderme";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 356);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnayarlar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Olivetti";
            this.Load += new System.EventHandler(this.frmAnaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlkartaktarmagrubu.ResumeLayout(false);
            this.pnlkartaktarmagrubu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnayarlar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHareketAktarma;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblkasalarabilgigonder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton rdbtnTarihsel;
        private System.Windows.Forms.RadioButton rdbtnHepsi;
        private System.Windows.Forms.Button btnAktar;
        private System.Windows.Forms.GroupBox grpKasalar;
        private System.Windows.Forms.Label lblkasalarahareketaktarimi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbtnTarihsel2;
        private System.Windows.Forms.RadioButton rdbtnHepsi2;
        private System.Windows.Forms.DateTimePicker dtHareket2;
        private System.Windows.Forms.DateTimePicker dtHareket1;
        private System.Windows.Forms.Panel pnlkartaktarmagrubu;
    }
}

