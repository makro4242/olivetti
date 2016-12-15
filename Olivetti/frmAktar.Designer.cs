namespace Olivetti
{
    partial class frmAktar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSaatAyari = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdBtnBirSaat = new System.Windows.Forms.RadioButton();
            this.rdBtnOtuzDakika = new System.Windows.Forms.RadioButton();
            this.rdBtnBesDakika = new System.Windows.Forms.RadioButton();
            this.rdBtnOnDakika = new System.Windows.Forms.RadioButton();
            this.lblBarko2 = new System.Windows.Forms.Label();
            this.lblBarkodSayisi = new System.Windows.Forms.Label();
            this.lblKartAktarBilgi = new System.Windows.Forms.Label();
            this.pnlkartaktarmagrubu = new System.Windows.Forms.Panel();
            this.rdbtnHepsi = new System.Windows.Forms.RadioButton();
            this.rdbtnTarihsel = new System.Windows.Forms.RadioButton();
            this.dtAktar1 = new System.Windows.Forms.DateTimePicker();
            this.dtAktar2 = new System.Windows.Forms.DateTimePicker();
            this.rdbtnTarihsel2 = new System.Windows.Forms.RadioButton();
            this.rdbtnHepsi2 = new System.Windows.Forms.RadioButton();
            this.dtHareket2 = new System.Windows.Forms.DateTimePicker();
            this.dtHareket1 = new System.Windows.Forms.DateTimePicker();
            this.lblkasalarahareketaktarimi = new System.Windows.Forms.Label();
            this.btnHareketAktar = new System.Windows.Forms.Button();
            this.grpKasalar = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKartAktar = new System.Windows.Forms.Button();
            this.lblHareketAktarma = new System.Windows.Forms.Label();
            this.lblkasalarabilgigonder = new System.Windows.Forms.Label();
            this.btnayarlar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblSure = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlkartaktarmagrubu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblSaatAyari);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblBarko2);
            this.panel1.Controls.Add(this.lblBarkodSayisi);
            this.panel1.Controls.Add(this.lblKartAktarBilgi);
            this.panel1.Controls.Add(this.pnlkartaktarmagrubu);
            this.panel1.Controls.Add(this.rdbtnTarihsel2);
            this.panel1.Controls.Add(this.rdbtnHepsi2);
            this.panel1.Controls.Add(this.dtHareket2);
            this.panel1.Controls.Add(this.dtHareket1);
            this.panel1.Controls.Add(this.lblkasalarahareketaktarimi);
            this.panel1.Controls.Add(this.btnHareketAktar);
            this.panel1.Controls.Add(this.grpKasalar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnKartAktar);
            this.panel1.Controls.Add(this.lblHareketAktarma);
            this.panel1.Controls.Add(this.lblkasalarabilgigonder);
            this.panel1.Location = new System.Drawing.Point(1, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 476);
            this.panel1.TabIndex = 5;
            // 
            // lblSaatAyari
            // 
            this.lblSaatAyari.AutoSize = true;
            this.lblSaatAyari.Location = new System.Drawing.Point(21, 140);
            this.lblSaatAyari.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaatAyari.Name = "lblSaatAyari";
            this.lblSaatAyari.Size = new System.Drawing.Size(123, 17);
            this.lblSaatAyari.TabIndex = 25;
            this.lblSaatAyari.Text = "Saat Yapılandırma";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdBtnBirSaat);
            this.panel2.Controls.Add(this.rdBtnOtuzDakika);
            this.panel2.Controls.Add(this.rdBtnBesDakika);
            this.panel2.Controls.Add(this.rdBtnOnDakika);
            this.panel2.Location = new System.Drawing.Point(19, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 66);
            this.panel2.TabIndex = 24;
            // 
            // rdBtnBirSaat
            // 
            this.rdBtnBirSaat.AutoSize = true;
            this.rdBtnBirSaat.Location = new System.Drawing.Point(287, 43);
            this.rdBtnBirSaat.Margin = new System.Windows.Forms.Padding(4);
            this.rdBtnBirSaat.Name = "rdBtnBirSaat";
            this.rdBtnBirSaat.Size = new System.Drawing.Size(92, 21);
            this.rdBtnBirSaat.TabIndex = 11;
            this.rdBtnBirSaat.Text = "60 Dakika";
            this.rdBtnBirSaat.UseVisualStyleBackColor = true;
            this.rdBtnBirSaat.CheckedChanged += new System.EventHandler(this.rdBtnBirSaat_CheckedChanged);
            // 
            // rdBtnOtuzDakika
            // 
            this.rdBtnOtuzDakika.AutoSize = true;
            this.rdBtnOtuzDakika.Location = new System.Drawing.Point(287, 4);
            this.rdBtnOtuzDakika.Margin = new System.Windows.Forms.Padding(4);
            this.rdBtnOtuzDakika.Name = "rdBtnOtuzDakika";
            this.rdBtnOtuzDakika.Size = new System.Drawing.Size(92, 21);
            this.rdBtnOtuzDakika.TabIndex = 10;
            this.rdBtnOtuzDakika.Text = "30 Dakika";
            this.rdBtnOtuzDakika.UseVisualStyleBackColor = true;
            this.rdBtnOtuzDakika.CheckedChanged += new System.EventHandler(this.rdBtnOtuzDakika_CheckedChanged);
            // 
            // rdBtnBesDakika
            // 
            this.rdBtnBesDakika.AutoSize = true;
            this.rdBtnBesDakika.Checked = true;
            this.rdBtnBesDakika.Location = new System.Drawing.Point(4, 4);
            this.rdBtnBesDakika.Margin = new System.Windows.Forms.Padding(4);
            this.rdBtnBesDakika.Name = "rdBtnBesDakika";
            this.rdBtnBesDakika.Size = new System.Drawing.Size(84, 21);
            this.rdBtnBesDakika.TabIndex = 8;
            this.rdBtnBesDakika.TabStop = true;
            this.rdBtnBesDakika.Text = "5 Dakika";
            this.rdBtnBesDakika.UseVisualStyleBackColor = true;
            this.rdBtnBesDakika.CheckedChanged += new System.EventHandler(this.rdBtnBesDakika_CheckedChanged);
            // 
            // rdBtnOnDakika
            // 
            this.rdBtnOnDakika.AutoSize = true;
            this.rdBtnOnDakika.Location = new System.Drawing.Point(4, 43);
            this.rdBtnOnDakika.Margin = new System.Windows.Forms.Padding(4);
            this.rdBtnOnDakika.Name = "rdBtnOnDakika";
            this.rdBtnOnDakika.Size = new System.Drawing.Size(92, 21);
            this.rdBtnOnDakika.TabIndex = 9;
            this.rdBtnOnDakika.Text = "10 Dakika";
            this.rdBtnOnDakika.UseVisualStyleBackColor = true;
            this.rdBtnOnDakika.CheckedChanged += new System.EventHandler(this.rdBtnOnDakika_CheckedChanged);
            // 
            // lblBarko2
            // 
            this.lblBarko2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBarko2.ForeColor = System.Drawing.Color.Maroon;
            this.lblBarko2.Location = new System.Drawing.Point(15, 400);
            this.lblBarko2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarko2.Name = "lblBarko2";
            this.lblBarko2.Size = new System.Drawing.Size(405, 33);
            this.lblBarko2.TabIndex = 24;
            // 
            // lblBarkodSayisi
            // 
            this.lblBarkodSayisi.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBarkodSayisi.ForeColor = System.Drawing.Color.Maroon;
            this.lblBarkodSayisi.Location = new System.Drawing.Point(15, 344);
            this.lblBarkodSayisi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarkodSayisi.Name = "lblBarkodSayisi";
            this.lblBarkodSayisi.Size = new System.Drawing.Size(405, 33);
            this.lblBarkodSayisi.TabIndex = 24;
            // 
            // lblKartAktarBilgi
            // 
            this.lblKartAktarBilgi.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKartAktarBilgi.ForeColor = System.Drawing.Color.Maroon;
            this.lblKartAktarBilgi.Location = new System.Drawing.Point(15, 259);
            this.lblKartAktarBilgi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKartAktarBilgi.Name = "lblKartAktarBilgi";
            this.lblKartAktarBilgi.Size = new System.Drawing.Size(405, 85);
            this.lblKartAktarBilgi.TabIndex = 24;
            // 
            // pnlkartaktarmagrubu
            // 
            this.pnlkartaktarmagrubu.Controls.Add(this.rdbtnHepsi);
            this.pnlkartaktarmagrubu.Controls.Add(this.rdbtnTarihsel);
            this.pnlkartaktarmagrubu.Controls.Add(this.dtAktar1);
            this.pnlkartaktarmagrubu.Controls.Add(this.dtAktar2);
            this.pnlkartaktarmagrubu.Location = new System.Drawing.Point(20, 70);
            this.pnlkartaktarmagrubu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlkartaktarmagrubu.Name = "pnlkartaktarmagrubu";
            this.pnlkartaktarmagrubu.Size = new System.Drawing.Size(384, 66);
            this.pnlkartaktarmagrubu.TabIndex = 23;
            // 
            // rdbtnHepsi
            // 
            this.rdbtnHepsi.AutoSize = true;
            this.rdbtnHepsi.Location = new System.Drawing.Point(4, 4);
            this.rdbtnHepsi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnHepsi.Name = "rdbtnHepsi";
            this.rdbtnHepsi.Size = new System.Drawing.Size(65, 21);
            this.rdbtnHepsi.TabIndex = 8;
            this.rdbtnHepsi.TabStop = true;
            this.rdbtnHepsi.Text = "Hepsi";
            this.rdbtnHepsi.UseVisualStyleBackColor = true;
            // 
            // rdbtnTarihsel
            // 
            this.rdbtnTarihsel.AutoSize = true;
            this.rdbtnTarihsel.Location = new System.Drawing.Point(4, 42);
            this.rdbtnTarihsel.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnTarihsel.Name = "rdbtnTarihsel";
            this.rdbtnTarihsel.Size = new System.Drawing.Size(80, 21);
            this.rdbtnTarihsel.TabIndex = 9;
            this.rdbtnTarihsel.TabStop = true;
            this.rdbtnTarihsel.Text = "Tarihsel";
            this.rdbtnTarihsel.UseVisualStyleBackColor = true;
            this.rdbtnTarihsel.CheckedChanged += new System.EventHandler(this.rdbtnTarihsel_CheckedChanged);
            // 
            // dtAktar1
            // 
            this.dtAktar1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAktar1.Location = new System.Drawing.Point(108, 37);
            this.dtAktar1.Margin = new System.Windows.Forms.Padding(4);
            this.dtAktar1.Name = "dtAktar1";
            this.dtAktar1.Size = new System.Drawing.Size(124, 22);
            this.dtAktar1.TabIndex = 6;
            this.dtAktar1.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtAktar1.Visible = false;
            // 
            // dtAktar2
            // 
            this.dtAktar2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAktar2.Location = new System.Drawing.Point(241, 37);
            this.dtAktar2.Margin = new System.Windows.Forms.Padding(4);
            this.dtAktar2.Name = "dtAktar2";
            this.dtAktar2.Size = new System.Drawing.Size(124, 22);
            this.dtAktar2.TabIndex = 7;
            this.dtAktar2.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtAktar2.Visible = false;
            // 
            // rdbtnTarihsel2
            // 
            this.rdbtnTarihsel2.AutoSize = true;
            this.rdbtnTarihsel2.Location = new System.Drawing.Point(427, 102);
            this.rdbtnTarihsel2.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnTarihsel2.Name = "rdbtnTarihsel2";
            this.rdbtnTarihsel2.Size = new System.Drawing.Size(80, 21);
            this.rdbtnTarihsel2.TabIndex = 22;
            this.rdbtnTarihsel2.TabStop = true;
            this.rdbtnTarihsel2.Text = "Tarihsel";
            this.rdbtnTarihsel2.UseVisualStyleBackColor = true;
            // 
            // rdbtnHepsi2
            // 
            this.rdbtnHepsi2.AutoSize = true;
            this.rdbtnHepsi2.Location = new System.Drawing.Point(425, 70);
            this.rdbtnHepsi2.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnHepsi2.Name = "rdbtnHepsi2";
            this.rdbtnHepsi2.Size = new System.Drawing.Size(65, 21);
            this.rdbtnHepsi2.TabIndex = 21;
            this.rdbtnHepsi2.TabStop = true;
            this.rdbtnHepsi2.Text = "Hepsi";
            this.rdbtnHepsi2.UseVisualStyleBackColor = true;
            // 
            // dtHareket2
            // 
            this.dtHareket2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHareket2.Location = new System.Drawing.Point(652, 98);
            this.dtHareket2.Margin = new System.Windows.Forms.Padding(4);
            this.dtHareket2.Name = "dtHareket2";
            this.dtHareket2.Size = new System.Drawing.Size(124, 22);
            this.dtHareket2.TabIndex = 20;
            this.dtHareket2.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtHareket2.Visible = false;
            // 
            // dtHareket1
            // 
            this.dtHareket1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHareket1.Location = new System.Drawing.Point(519, 98);
            this.dtHareket1.Margin = new System.Windows.Forms.Padding(4);
            this.dtHareket1.Name = "dtHareket1";
            this.dtHareket1.Size = new System.Drawing.Size(124, 22);
            this.dtHareket1.TabIndex = 19;
            this.dtHareket1.Value = new System.DateTime(2016, 8, 13, 16, 10, 50, 0);
            this.dtHareket1.Visible = false;
            // 
            // lblkasalarahareketaktarimi
            // 
            this.lblkasalarahareketaktarimi.AutoSize = true;
            this.lblkasalarahareketaktarimi.Location = new System.Drawing.Point(423, 41);
            this.lblkasalarahareketaktarimi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblkasalarahareketaktarimi.Name = "lblkasalarahareketaktarimi";
            this.lblkasalarahareketaktarimi.Size = new System.Drawing.Size(255, 17);
            this.lblkasalarahareketaktarimi.TabIndex = 18;
            this.lblkasalarahareketaktarimi.Text = "Kasalardan Satış Hareketlerini Aktarma";
            // 
            // btnHareketAktar
            // 
            this.btnHareketAktar.Location = new System.Drawing.Point(425, 438);
            this.btnHareketAktar.Margin = new System.Windows.Forms.Padding(4);
            this.btnHareketAktar.Name = "btnHareketAktar";
            this.btnHareketAktar.Size = new System.Drawing.Size(100, 28);
            this.btnHareketAktar.TabIndex = 17;
            this.btnHareketAktar.Text = "Aktar";
            this.btnHareketAktar.UseVisualStyleBackColor = true;
            this.btnHareketAktar.Click += new System.EventHandler(this.btnHareketAktar_Click);
            // 
            // grpKasalar
            // 
            this.grpKasalar.Location = new System.Drawing.Point(427, 134);
            this.grpKasalar.Margin = new System.Windows.Forms.Padding(4);
            this.grpKasalar.Name = "grpKasalar";
            this.grpKasalar.Padding = new System.Windows.Forms.Padding(4);
            this.grpKasalar.Size = new System.Drawing.Size(351, 210);
            this.grpKasalar.TabIndex = 16;
            this.grpKasalar.TabStop = false;
            this.grpKasalar.Text = "Kasalar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(15, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kart Aktarma";
            // 
            // btnKartAktar
            // 
            this.btnKartAktar.Location = new System.Drawing.Point(20, 436);
            this.btnKartAktar.Margin = new System.Windows.Forms.Padding(4);
            this.btnKartAktar.Name = "btnKartAktar";
            this.btnKartAktar.Size = new System.Drawing.Size(100, 28);
            this.btnKartAktar.TabIndex = 6;
            this.btnKartAktar.Text = "Aktar";
            this.btnKartAktar.UseVisualStyleBackColor = true;
            this.btnKartAktar.Click += new System.EventHandler(this.btnKartAktar_Click);
            // 
            // lblHareketAktarma
            // 
            this.lblHareketAktarma.AutoSize = true;
            this.lblHareketAktarma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHareketAktarma.Location = new System.Drawing.Point(421, 1);
            this.lblHareketAktarma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHareketAktarma.Name = "lblHareketAktarma";
            this.lblHareketAktarma.Size = new System.Drawing.Size(173, 25);
            this.lblHareketAktarma.TabIndex = 2;
            this.lblHareketAktarma.Text = "Hareket Aktarma";
            // 
            // lblkasalarabilgigonder
            // 
            this.lblkasalarabilgigonder.AutoSize = true;
            this.lblkasalarabilgigonder.Location = new System.Drawing.Point(16, 41);
            this.lblkasalarabilgigonder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblkasalarabilgigonder.Name = "lblkasalarabilgigonder";
            this.lblkasalarabilgigonder.Size = new System.Drawing.Size(200, 17);
            this.lblkasalarabilgigonder.TabIndex = 3;
            this.lblkasalarabilgigonder.Text = "Kasalara Stok Kartı Gönderme";
            // 
            // btnayarlar
            // 
            this.btnayarlar.Location = new System.Drawing.Point(681, 7);
            this.btnayarlar.Margin = new System.Windows.Forms.Padding(4);
            this.btnayarlar.Name = "btnayarlar";
            this.btnayarlar.Size = new System.Drawing.Size(100, 28);
            this.btnayarlar.TabIndex = 4;
            this.btnayarlar.Text = "Ayarlar";
            this.btnayarlar.UseVisualStyleBackColor = true;
            this.btnayarlar.Click += new System.EventHandler(this.btnayarlar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSure.Location = new System.Drawing.Point(24, 14);
            this.lblSure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(0, 17);
            this.lblSure.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAktar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 522);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnayarlar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAktar";
            this.Text = "Olivetti Aktarım";
            this.Load += new System.EventHandler(this.frmAktar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlkartaktarmagrubu.ResumeLayout(false);
            this.pnlkartaktarmagrubu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlkartaktarmagrubu;
        private System.Windows.Forms.RadioButton rdbtnHepsi;
        private System.Windows.Forms.RadioButton rdbtnTarihsel;
        private System.Windows.Forms.DateTimePicker dtAktar1;
        private System.Windows.Forms.DateTimePicker dtAktar2;
        private System.Windows.Forms.RadioButton rdbtnTarihsel2;
        private System.Windows.Forms.RadioButton rdbtnHepsi2;
        private System.Windows.Forms.DateTimePicker dtHareket2;
        private System.Windows.Forms.DateTimePicker dtHareket1;
        private System.Windows.Forms.Label lblkasalarahareketaktarimi;
        private System.Windows.Forms.Button btnHareketAktar;
        private System.Windows.Forms.GroupBox grpKasalar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKartAktar;
        private System.Windows.Forms.Label lblHareketAktarma;
        private System.Windows.Forms.Label lblkasalarabilgigonder;
        private System.Windows.Forms.Button btnayarlar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblKartAktarBilgi;
        private System.Windows.Forms.Label lblBarkodSayisi;
        private System.Windows.Forms.Label lblBarko2;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSaatAyari;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdBtnBirSaat;
        private System.Windows.Forms.RadioButton rdBtnOtuzDakika;
        private System.Windows.Forms.RadioButton rdBtnBesDakika;
        private System.Windows.Forms.RadioButton rdBtnOnDakika;
    }
}