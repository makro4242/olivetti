using System;
using System.Windows.Forms;
namespace Olivetti
{
    public partial class frmAyarlar : Form
    {
        Fonksiyon f = new Fonksiyon();
        int kasaid = -1;
        frmAnaForm frm;
   
        public void kasagetir(int kasaid)
        {
            string arl = Properties.Settings.Default.Kasalar[kasaid];
            try
            {
                string[] bilgiler = arl.Split('*');
                btneditKasaKodu.Text = bilgiler[0];
                this.kasaid = kasaid;
                txtKasaAciklama.Text = bilgiler[1];
                txtKasaDosyaYolu.Text = bilgiler[2];
                txtKasaEta.Text = bilgiler[3];
            }
            catch (Exception)
            {
            }
        }
        public frmAyarlar(frmAnaForm frm)
        {
            this.frm = frm;
            InitializeComponent();
        }

        private void btnVeriTabaniAyarlariKaydet_Click(object sender, EventArgs e)
        {

            bool test = f.Connect(txtsqlip.Text, txtDatabase.Text, txtSqlUser.Text, txtSqlPassword.Text);
            if (test)
            {
                Properties.Settings.Default.SqlServeripinstancename = txtsqlip.Text;
                Properties.Settings.Default.SqlDatabase = txtDatabase.Text;
                Properties.Settings.Default.SqlUser = txtSqlUser.Text;
                Properties.Settings.Default.SqlPassword = txtSqlPassword.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Bağlantı Kuruldu, Ayarlar Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Connection bilgilerinizde sorun var");
            }
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            propertigetir();
        }

        void propertigetir()
        {
            txtsqlip.Text = Properties.Settings.Default.SqlServeripinstancename;
            txtDatabase.Text = Properties.Settings.Default.SqlDatabase;
            txtSqlUser.Text = Properties.Settings.Default.SqlUser;
            txtSqlPassword.Text = Properties.Settings.Default.SqlPassword;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kasakayit();
        }

        void kasakayit()
        {
            if (Properties.Settings.Default.Kasalar == null)
            {
                Properties.Settings.Default.Kasalar = new System.Collections.Specialized.StringCollection();
            }
            if (kasaid == -1)
            {
                Properties.Settings.Default.Kasalar.Add(btneditKasaKodu.Text + "*" + txtKasaAciklama.Text + "*" + txtKasaDosyaYolu.Text + "*" + txtKasaEta.Text);
            }
            else
            {
                Properties.Settings.Default.Kasalar[kasaid] = btneditKasaKodu.Text + "*" + txtKasaAciklama.Text + "*" + txtKasaDosyaYolu.Text + "*" + txtKasaEta.Text;
            }
            Properties.Settings.Default.Save();

            f.txtleritemizle(grpKasaTanimlari);
            frm.kasalariGetir();
        }

        private void btneditKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmKasalar frm = new frmKasalar(this);
            frm.ShowDialog();
        }


    }
}
