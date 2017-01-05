namespace Olivetti
{
    partial class frmAyarlar
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
            this.grpboxHedefVeriTabaniAyarlari = new System.Windows.Forms.GroupBox();
            this.btnVeriTabaniAyarlariKaydet = new System.Windows.Forms.Button();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtsqlip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpKasaTanimlari = new System.Windows.Forms.GroupBox();
            this.txtKasaEta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btneditKasaKodu = new DevExpress.XtraEditors.ButtonEdit();
            this.txtKasaDosyaYolu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtKasaAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpboxHedefVeriTabaniAyarlari.SuspendLayout();
            this.grpKasaTanimlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btneditKasaKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxHedefVeriTabaniAyarlari
            // 
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.btnVeriTabaniAyarlariKaydet);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.txtSqlPassword);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.txtSqlUser);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.txtDatabase);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.txtsqlip);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.label4);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.label3);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.label2);
            this.grpboxHedefVeriTabaniAyarlari.Controls.Add(this.label1);
            this.grpboxHedefVeriTabaniAyarlari.Location = new System.Drawing.Point(3, 4);
            this.grpboxHedefVeriTabaniAyarlari.Name = "grpboxHedefVeriTabaniAyarlari";
            this.grpboxHedefVeriTabaniAyarlari.Size = new System.Drawing.Size(387, 148);
            this.grpboxHedefVeriTabaniAyarlari.TabIndex = 1;
            this.grpboxHedefVeriTabaniAyarlari.TabStop = false;
            this.grpboxHedefVeriTabaniAyarlari.Text = "Kaynak Veri Tabanı Ayarları";
            // 
            // btnVeriTabaniAyarlariKaydet
            // 
            this.btnVeriTabaniAyarlariKaydet.Location = new System.Drawing.Point(12, 119);
            this.btnVeriTabaniAyarlariKaydet.Name = "btnVeriTabaniAyarlariKaydet";
            this.btnVeriTabaniAyarlariKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnVeriTabaniAyarlariKaydet.TabIndex = 5;
            this.btnVeriTabaniAyarlariKaydet.Text = "Kaydet";
            this.btnVeriTabaniAyarlariKaydet.UseVisualStyleBackColor = true;
            this.btnVeriTabaniAyarlariKaydet.Click += new System.EventHandler(this.btnVeriTabaniAyarlariKaydet_Click);
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(166, 97);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Size = new System.Drawing.Size(143, 20);
            this.txtSqlPassword.TabIndex = 4;
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(166, 75);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(143, 20);
            this.txtSqlUser.TabIndex = 3;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(166, 52);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(143, 20);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtsqlip
            // 
            this.txtsqlip.Location = new System.Drawing.Point(166, 28);
            this.txtsqlip.Name = "txtsqlip";
            this.txtsqlip.Size = new System.Drawing.Size(143, 20);
            this.txtsqlip.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sql Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sql User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server İp / İnstance Name";
            // 
            // grpKasaTanimlari
            // 
            this.grpKasaTanimlari.Controls.Add(this.txtKasaEta);
            this.grpKasaTanimlari.Controls.Add(this.label7);
            this.grpKasaTanimlari.Controls.Add(this.btneditKasaKodu);
            this.grpKasaTanimlari.Controls.Add(this.txtKasaDosyaYolu);
            this.grpKasaTanimlari.Controls.Add(this.label6);
            this.grpKasaTanimlari.Controls.Add(this.button2);
            this.grpKasaTanimlari.Controls.Add(this.txtKasaAciklama);
            this.grpKasaTanimlari.Controls.Add(this.label5);
            this.grpKasaTanimlari.Controls.Add(this.label8);
            this.grpKasaTanimlari.Location = new System.Drawing.Point(3, 152);
            this.grpKasaTanimlari.Name = "grpKasaTanimlari";
            this.grpKasaTanimlari.Size = new System.Drawing.Size(387, 162);
            this.grpKasaTanimlari.TabIndex = 2;
            this.grpKasaTanimlari.TabStop = false;
            this.grpKasaTanimlari.Text = "Kasa Tanımları";
            // 
            // txtKasaEta
            // 
            this.txtKasaEta.Location = new System.Drawing.Point(166, 102);
            this.txtKasaEta.Name = "txtKasaEta";
            this.txtKasaEta.Size = new System.Drawing.Size(143, 20);
            this.txtKasaEta.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Kasa Eta Kodu";
            // 
            // btneditKasaKodu
            // 
            this.btneditKasaKodu.Location = new System.Drawing.Point(166, 28);
            this.btneditKasaKodu.Name = "btneditKasaKodu";
            this.btneditKasaKodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btneditKasaKodu.Size = new System.Drawing.Size(143, 20);
            this.btneditKasaKodu.TabIndex = 1;
            this.btneditKasaKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btneditKasaKodu_ButtonClick);
            // 
            // txtKasaDosyaYolu
            // 
            this.txtKasaDosyaYolu.Location = new System.Drawing.Point(166, 76);
            this.txtKasaDosyaYolu.Name = "txtKasaDosyaYolu";
            this.txtKasaDosyaYolu.Size = new System.Drawing.Size(143, 20);
            this.txtKasaDosyaYolu.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Kasa Dosya Yolu";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Kaydet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtKasaAciklama
            // 
            this.txtKasaAciklama.Location = new System.Drawing.Point(166, 52);
            this.txtKasaAciklama.Name = "txtKasaAciklama";
            this.txtKasaAciklama.Size = new System.Drawing.Size(143, 20);
            this.txtKasaAciklama.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Kasa Açıklama";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Kasa Kodu";
            // 
            // frmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 315);
            this.Controls.Add(this.grpKasaTanimlari);
            this.Controls.Add(this.grpboxHedefVeriTabaniAyarlari);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAyarlar_Load);
            this.grpboxHedefVeriTabaniAyarlari.ResumeLayout(false);
            this.grpboxHedefVeriTabaniAyarlari.PerformLayout();
            this.grpKasaTanimlari.ResumeLayout(false);
            this.grpKasaTanimlari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btneditKasaKodu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxHedefVeriTabaniAyarlari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVeriTabaniAyarlariKaydet;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtsqlip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpKasaTanimlari;
        private System.Windows.Forms.TextBox txtKasaDosyaYolu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtKasaAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.ButtonEdit btneditKasaKodu;
        private System.Windows.Forms.TextBox txtKasaEta;
        private System.Windows.Forms.Label label7;
    }
}