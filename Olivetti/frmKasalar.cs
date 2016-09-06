using System;
using System.Windows.Forms;

namespace Olivetti
{
    public partial class frmKasalar : Form
    {
        frmAyarlar frmay;
        public frmKasalar(frmAyarlar frm)
        {
            frmay = frm;
            InitializeComponent();
        }

        private void frmKasalar_Load(object sender, EventArgs e)
        {
            Fonksiyon.kasaDoldur(lstKasalar);
        }

        private void lstKasalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKasalar.SelectedIndex > -1)
            {
                int index = lstKasalar.SelectedIndex;
                frmay.kasagetir(index);
                this.Close();
            }
        }
    }
}
