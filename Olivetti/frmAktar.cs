using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olivetti
{
    public partial class frmAktar : Form
    {
        myDbHelper db = new myDbHelper(new sqlDbHelper());
        public frmAktar()
        {
            InitializeComponent();
        }
        private void btnayarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar frm = new frmAyarlar(this);
            frm.ShowDialog();
        }
        public void kasalariGetir()
        {
            if (Properties.Settings.Default.Kasalar != null)
            {
                grpKasalar.Controls.Clear();
                int i = 0;
                foreach (string item in Properties.Settings.Default.Kasalar)
                {
                    Point p = new Point(10, (i + 1) * 20);
                    CheckBox a = new CheckBox();
                    a.Location = p;
                    a.Text = "Kasa " + (i + 1);
                    grpKasalar.Controls.Add(a);
                    i++;
                }
            }
        }

        private void frmAktar_Load(object sender, EventArgs e)
        {
           
            if (Properties.Settings.Default.SqlDatabase.Trim().Length > 0)
            {
                kasalariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen ayarlar bölümünden veritabanı bilgilerini girin");
                frmAyarlar frm = new frmAyarlar(this);
                frm.ShowDialog();
            }
        }

        private void btnKartAktar_Click(object sender, EventArgs e)
        {

            DataTable dt = db.exReaderDT(CommandType.Text, "select top 10 * from stkkart");
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtStkFiyat = db.exReaderDT(CommandType.Text, "select STKFIYKDVNO,STKFIYTUTAR,STKFIYISKYUZ1  from STKFIYAT where STKFIYSTKKOD=@stokKodu and STKFIYNO=@stkFiyNo", "stokKodu=" + item["STKKOD"] + ",stkFiyNo=" + item["STKOTOGIRFIY"]);
                    DataTable dtBarkodlar = db.exReaderDT(CommandType.Text, "select STKBARKOD,STKBARSTKKOD,STKBARBRMNO,STKBARTIP,STKBARITEMNO from stkbarkod where stkbarstkkod=@stokKodu order by STKBARITEMNO", "stokKodu=" + item["STKKOD"]);
                    string STKFIYKDVNO = "";
                    string STKFIYTUTAR = "";
                    string STKFIYISKYUZ1 = "";
                    if (dtStkFiyat != null && dtStkFiyat.Rows.Count > 0)
                    {
                        STKFIYKDVNO = dtStkFiyat.Rows[0]["STKFIYKDVNO"].ToString();
                        STKFIYTUTAR = dtStkFiyat.Rows[0]["STKFIYTUTAR"].ToString();
                        STKFIYISKYUZ1 = dtStkFiyat.Rows[0]["STKFIYISKYUZ1"].ToString();
                    }

                    stokOku stk = new stokOku();

                    stk.sirano = "01".boslukTamamla(4);
                    stk.ekle(0, stk.sirano);

                    stk.islemTuru = "0".boslukTamamla(1);
                    stk.ekle(4, stk.islemTuru);
                    stk.stokKodu = item["STKKOD"].boslukTamamla(24);
                    stk.ekle(5, stk.stokKodu);
                    stk.eskiStokKodu = stk.stokKodu;
                    stk.ekle(29, stk.eskiStokKodu);

                    stk.stokAciklama = item["STKCINSI"].boslukTamamla(40);
                    stk.ekle(53, stk.stokAciklama);


                    stk.posAciklama = item["STKCINSI"].boslukTamamla(20);
                    stk.ekle(133, stk.posAciklama);

                    stk.rafAciklama = stk.posAciklama;
                    stk.ekle(153, stk.rafAciklama);

                    stk.teraziAciklama = item["STKCINSI"].boslukTamamla(16);
                    stk.ekle(173, stk.teraziAciklama);


                    stk.stokBolumu = STKFIYKDVNO.boslukTamamla(8);
                    stk.ekle(189, stk.stokBolumu);

                    stk.reyonTanimi = "1".boslukTamamla(8);
                    stk.ekle(197, stk.reyonTanimi);

                    stk.urunTipi = "1".boslukTamamla(8);
                    stk.ekle(205, stk.urunTipi);

                    stk.birimBoleni = "1".boslukTamamla(15);
                    stk.ekle(283, stk.birimBoleni);

                    stk.satisFiyati = STKFIYTUTAR.boslukTamamla(15);
                    stk.ekle(355, stk.satisFiyati);

                    stk.satisFiyati2 = stk.satisFiyati;
                    stk.ekle(370, stk.satisFiyati2);

                    stk.satisFiyati3 = stk.satisFiyati;
                    stk.ekle(385, stk.satisFiyati3);

                    stk.satisFiyati4 = stk.satisFiyati;
                    stk.ekle(400, stk.satisFiyati4);

                    stk.satisKDVGrupNo = STKFIYKDVNO.boslukTamamla(3);
                    stk.ekle(531, stk.satisKDVGrupNo);

                    stk.satisDurumu = "0".boslukTamamla(1);
                    stk.ekle(586, stk.satisDurumu);

                    stk.indirimliSatis = "2".boslukTamamla(1);
                    stk.ekle(592, stk.satisDurumu);

                    stk.teraziDurumu = "0".boslukTamamla(1);
                    stk.ekle(686, stk.teraziDurumu);

                    stk.stokKartiPuanBilgisi = "0".boslukTamamla(15);
                    stk.ekle(807, stk.stokKartiPuanBilgisi);

                    stk.yaz = stk.yaz.boslukTamamla(850);

                    Fonksiyon.dosyayaYaz(stk.yaz);
                    if (dtBarkodlar != null)
                    {
                        foreach (DataRow barkod in dtBarkodlar.Rows)
                        {
                            barkodOku brkd = new barkodOku();
                            brkd.sirano = "02".boslukTamamla(4);
                            brkd.ekle(0, brkd.sirano);

                            brkd.islemTuru = "0".boslukTamamla(1);
                            brkd.ekle(4, brkd.islemTuru);

                            brkd.iliskiliStkKodu = stk.stokKodu.boslukTamamla(24);
                            brkd.ekle(5, brkd.iliskiliStkKodu);

                            brkd.barkodu = barkod["STKBARKOD"].boslukTamamla(24);
                            brkd.ekle(29, brkd.barkodu);

                            brkd.eskiBarkodu = brkd.barkodu;
                            brkd.ekle(53, brkd.eskiBarkodu);

                            brkd.birimMiktar = "1".boslukTamamla(6);//buraya bakılacak
                            brkd.ekle(77, brkd.birimMiktar);

                            brkd.barkodTipi = barkod["STKBARTIP"].ToString().boslukTamamla(1);
                            brkd.ekle(83, brkd.barkodTipi);

                            brkd.fiyatBilgisi = "0".boslukTamamla(1);
                            brkd.ekle(84, brkd.fiyatBilgisi);

                            brkd.sirano = barkod["STKBARITEMNO"].boslukTamamla(2);
                            brkd.ekle(85, brkd.sirano);

                            brkd.barkodFiyati = "".boslukTamamla(15);
                            brkd.ekle(87, brkd.barkodFiyati);

                            Fonksiyon.dosyayaYaz(brkd.yaz);
                        }
                    }

                }
            }

        }
    }
}
