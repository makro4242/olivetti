using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olivetti
{
    public partial class frmAktar : Form
    {
        Fonksiyon f = new Fonksiyon();
        public frmAktar()
        {
            CheckForIllegalCrossThreadCalls = false;
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
      
            rdbtnHepsi.Checked = true;
            rdbtnHepsi2.Checked = true;

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
        public void stokKartiAktar()
        {
            string dosyaYolu = Properties.Settings.Default.Kasalar[0].Split('*')[2] + "\\URUN.GTF";
            if (File.Exists(dosyaYolu))
            {
                File.Delete(dosyaYolu);
            }
            Fonksiyon.dosyayaYaz("<SIGNATURE=GNDPLU.GDF><VERSION=0223000>", dosyaYolu);
            string where = "";
            string prm = "";
            if (rdbtnTarihsel.Checked)
            {
                string date1 = dtAktar1.Value.ToString("yyyy-MM-dd");
                string date2 = dtAktar2.Value.ToString("yyyy-MM-dd");
                where += " and STKSYFTARIHI between @tarih1 and @tarih2";
                prm = "tarih1=" + date1 + ",tarih2=" + date2;

            }
            myDbHelper db = new myDbHelper(new sqlDbHelper());
            string adet = db.exReaderTekSutun(CommandType.Text, "select count(*) from stkkart where len(stkkod)>2" + where, prm);
            lblKartAktarBilgi.Text = "Toplam " + adet + " kart bilgisi veritabanından çekiliyor...";
            DataTable dt = db.exReaderDT(CommandType.Text, "select * from stkkart where len(stkkod)>2" + where, prm);
            if (dt != null)
            {

                int yapilanIslem = 0;
                foreach (DataRow item in dt.Rows)
                {
                    DataTable dtStkFiyat = db.exReaderDT(CommandType.Text, "select STKFIYKDVNO,STKFIYTUTAR,STKFIYISKYUZ1  from STKFIYAT where STKFIYSTKKOD=@stokKodu and STKFIYNO=@stkFiyNo", "stokKodu=" + item["STKKOD"].ToString().stringKaldir() + ",stkFiyNo=" + item["STKOTOGIRFIY"].ToString().stringKaldir());
                    DataTable dtBarkodlar = db.exReaderDT(CommandType.Text, "select STKBARKOD,STKBARSTKKOD,STKBARBRMNO,STKBARTIP,STKBARITEMNO from stkbarkod where stkbarstkkod=@stokKodu order by STKBARITEMNO", "stokKodu=" + item["STKKOD"].ToString().stringKaldir());
                    string STKFIYKDVNO = "0";
                    string STKFIYTUTAR = "0";
                    string STKFIYISKYUZ1 = "0";
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


                    stk.birim = "0".boslukTamamla(1);
                    stk.ekle(282, stk.birim);


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

                    stk.ekle(534, stk.satisKDVGrupNo);


                    stk.satisDurumu = "0".boslukTamamla(1);
                    stk.ekle(586, stk.satisDurumu);

                    stk.indirimliSatis = "2".boslukTamamla(1);
                    stk.ekle(592, stk.satisDurumu);

                    stk.teraziDurumu = "0".boslukTamamla(1);
                    stk.ekle(686, stk.teraziDurumu);

                    stk.stokKartiPuanBilgisi = "0".boslukTamamla(15);
                    stk.ekle(807, stk.stokKartiPuanBilgisi);

                    stk.yaz = stk.yaz.boslukTamamla(850);

                    Fonksiyon.dosyayaYaz(stk.yaz, dosyaYolu);
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

                            Fonksiyon.dosyayaYaz(brkd.yaz, dosyaYolu);
                        }
                    }
                    yapilanIslem++;
                    lblKartAktarBilgi.Text = adet + " /  " + yapilanIslem + " kart aktarıldı";
                }
                MessageBox.Show("Aktarma tamamlandı.Toplam " + yapilanIslem + " başarıyla aktarıldı");
                btnKartAktar.Enabled = true;
            }
        }
        private void btnKartAktar_Click(object sender, EventArgs e)
        {
            btnKartAktar.Enabled = false;
            backgroundWorker1.RunWorkerAsync();

        }

        private void btnHareketAktar_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpKasalar.Controls)
            {
                if (item is CheckBox && (item as CheckBox).Checked)
                {
                    int kasaIndex = Convert.ToInt32(item.Text.Replace("Kasa ", "")) - 1;
                    hareketAktar(rdbtnHepsi2.Checked, dtHareket1.Value, dtHareket2.Value, kasaIndex);
                    MessageBox.Show(kasaIndex + 1 + " . Kasa Aktarıldı");
                }
            }

        }
        public void hareketAktar(bool hepsi, DateTime tarih1, DateTime tarih2, int kasaIndex)
        {
            myDbHelper db = new myDbHelper(new sqlDbHelper());
            string dosya_yolu = Properties.Settings.Default.Kasalar[kasaIndex].Split('*')[2] + "\\SATIS.GTF";
            string kasaKodu = Properties.Settings.Default.Kasalar[kasaIndex].Split('*')[0];
            StreamReader sr = f.dosyaOkuyucu(dosya_yolu);

            bool kayit = false;
            hareket h = new hareket();
            if (sr != null)
            {
                string satir = sr.ReadLine();

                while (satir != null)
                {
                    string islemKodu = satir.Substring(0, 2);
                    #region kontroller
                    if (islemKodu == "01")
                    {
                        string tarih = satir.Substring(9, 14).Trim();
                        string fisKodu = satir.Substring(23, 12).Trim();

                        if (hareketKayitKontrol(h.tarih, kasaKodu, h.fisKodu))
                        {
                            if (hepsi)
                            {
                                //stok hareketlerini oku
                                //kaydet
                                //satir = sr.ReadLine();
                                kayit = true;
                            }
                            else
                            {
                                DateTime dtFatTar = Convert.ToDateTime(h.tarih);
                                TimeSpan tsFark = dtFatTar.Subtract(tarih1);
                                if (tsFark.Days >= 0)
                                {
                                    tsFark = tarih2.Subtract(dtFatTar);
                                    if (tsFark.Days >= 0)
                                    {
                                        kayit = true;
                                    }
                                    else
                                    {
                                        kayit = false;
                                        satir = null;
                                        break;
                                    }
                                }
                                else
                                {
                                    satir = sonrakiKayitaGit(satir, sr);
                                    kayit = false;
                                }
                            }
                        }
                        else
                        {
                            satir = sonrakiKayitaGit(satir, sr);
                            kayit = false;
                        }
                    }
                    #endregion
                    if (kayit)
                    {
                        if (islemKodu == "01")
                        {
                            h = new hareket();
                            h.tarih = satir.Substring(9, 14).Trim();
                            h.fisKodu = satir.Substring(23, 12).Trim();
                            h.saat = satir.Substring(35, 12).Trim();
                            h.magazaNo = satir.Substring(47, 6).Trim();
                            h.belgeTipi = (satir.Substring(61, 1)).Trim();
                            h.belgeDurumu = (satir.Substring(62, 1)).Trim();
                            h.genelToplam = satir.Substring(91, 15).Trim().Replace(",", "."); ;
                            h.kdvToplam = satir.Substring(106, 15).Trim().Replace(",", "."); ;
                            h.toplamIndirim = satir.Substring(121, 15).Trim().Replace(",", "."); ;
                            h.satirlarToplamIndirim = satir.Substring(136, 15).Trim().Replace(",", "."); ;
                            h.otomatikIndirim = satir.Substring(151, 15).Trim().Replace(",", "."); ;
                            h.promosyonIndirim = satir.Substring(181, 15).Trim().Replace(",", "."); ;
                            h.yuvarlama = satir.Substring(196, 15).Trim().Replace(",", "."); ;
                            h.musteriNo = satir.Substring(211, 24).Trim();
                            h.taksitliSatis = satir.Substring(235, 1).Trim();

                            satir = sr.ReadLine();
                        }
                        else if (islemKodu == "02")
                        {
                            stokHareket stk = new stokHareket();
                            stk.stokKodu = satir.Substring(9, 24).Trim();
                            stk.hareketTip = satir.Substring(33, 1);//0 normal, 1 iptal
                            stk.saticiKodu = satir.Substring(34, 6);
                            stk.KDVReferans = satir.Substring(40, 2);//fiyata kdv dahil olup olmadığı
                            stk.KDVYuzde = Convert.ToByte(satir.Substring(42, 3));
                            stk.miktar = Convert.ToInt32(satir.Substring(45, 15)).ToString();
                            stk.birim = satir.Substring(60, 1);//0:adet,1:kilogram,2:metre,3:litre,4:metre^2,metre^3;
                            stk.birimFiyat = satir.Substring(61, 15).Replace(",", ".");
                            stk.toplamFiyat = satir.Substring(76, 15).Replace(",", ".");
                            stk.toplamKDV = satir.Substring(91, 15).Replace(",", ".");
                            stk.toplamIndirim = satir.Substring(106, 15).Replace(",", ".");
                            stk.kasiyerIndirim = satir.Substring(121, 15).Replace(",", ".");
                            stk.otomatikIndirim = satir.Substring(136, 15).Replace(",", ".");
                            stk.musteriIndirimi = satir.Substring(151, 15).Replace(",", ".");
                            stk.promosyonIndirimi = satir.Substring(166, 15).Replace(",", ".");
                            stk.satisDurumu = satir.Substring(181, 1);//0:normal satış,1:bağlantılı satış,2:mix&match olarak satıldı ,
                            stk.barkodSatis = satir.Substring(182, 24);
                            stk.odemeTipiReferansi = satir.Substring(221, 2);
                            stk.satisTipi = satir.Substring(225, 1);//0:barkodlusatış,1:stok kodu
                            h.lstStokHareket.Add(stk);
                            satir = sr.ReadLine();
                        }
                        else
                        {
                            string strFatFis = db.exReaderTekSutun(CommandType.Text, "select harrefdeger from HARREFNO where harrefmodul=3 and harrefkonu=1", "").ToString();
                            int fatFisHarRefNo = 0;
                            //  try
                            {
                                fatFisHarRefNo = Convert.ToInt32(strFatFis);
                                db.nonQuery(CommandType.Text, "update harrefno set harrefdeger=(harrefdeger+1) where harrefmodul=3 and harrefkonu=1");
                                StringBuilder sbInsertFatFis = new StringBuilder();

                                sbInsertFatFis.Append("insert into FATFIS");
                                sbInsertFatFis.Append("(FATFISTAR,FATFISREFNO,FATFISTIPI,FATFISGCFLAG,FATFISKAYONC,FATFISKAYNAK,FATFISKAPFLAG,FATFISKDVDAHILFLAG,FATFISANADEPO,FATFISADRESNO,FATFISSAAT,FATFISEVRAKNO1,FATFISKDVORANI,FATFISMALTOP,FATFISKALINDYTOP,FATFISBRUTTOPLAM,FATFISKDVMATRAHI,FATFISKDVTUTARI,FATFISARATOPLAM,FATFISGENTOPLAM,FATFISSEVNO,FATFISTOPOTUT )");
                                sbInsertFatFis.Append("values ( @FatFisTar,@FATFISREFNO,@FATFISTIPI,2,1,@FATFISKAYNAK,1,@FATFISKDVDAHILFLAG,'D-01',1,@FATFISSAAT,@FATFISEVRAKNO1,@FATFISKDVORANI,@FATFISMALTOP,@FATFISKALINDYTOP,@FATFISBRUTTOPLAM,@FATFISKDVMATRAHI,@FATFISKDVTUTARI,@FATFISARATOPLAM,@FATFISGENTOPLAM,1,@FATFISTOPOTUT)");
                                // values ( '20160829',101790,13,2,1,3,1,1,'D-01',1,'11:26','4299',8,22.4,4.19,18.21,16.86,1.35,18.21,18.21,1,18.21 )

                                string FatFisTar = Convert.ToDateTime(h.tarih).ToString("yyyMMdd");
                                string FATFISREFNO = fatFisHarRefNo.ToString();
                                string FATFISTIPI = kasaKodu;
                                string FATFISKAYNAK = "3";//kasadan alınacak
                                string FATFISKDVDAHILFLAG = "1";
                                string FATFISSAAT = h.saat.Substring(0, 2) + ":" + h.saat.Substring(2, 2);
                                string FATFISEVRAKNO1 = h.fisKodu.stringKaldir();//doğrulunu kontrol et
                                string FATFISKDVORANI = "8";//burası fişte yok , her ürün için ayrı ayrı var.
                                string FATFISMALTOP = h.genelToplam.stringKaldir();//maltoplam
                                string FATFISKALINDYTOP = h.satirlarToplamIndirim.stringKaldir();//toplam indirim
                                string FATFISBRUTTOPLAM = h.genelToplam.stringKaldir();//brut toplam
                                string FATFISKDVMATRAHI = h.genelToplam.stringKaldir();//kdv matrahı
                                string FATFISKDVTUTARI = "10";
                                string FATFISARATOPLAM = h.genelToplam.stringKaldir();//aratoplam fiyatı bulunacak
                                string FATFISGENTOPLAM = h.genelToplam.stringKaldir();
                                string FATFISTOPOTUT = h.genelToplam.stringKaldir();
                                string prmFatFis = "FatFisTar=" + FatFisTar + ",FATFISREFNO=" + FATFISREFNO + ",FATFISTIPI=" + FATFISTIPI + ",FATFISKAYNAK=" + FATFISKAYNAK + ",FATFISKDVDAHILFLAG=" + FATFISKDVDAHILFLAG + ",FATFISSAAT=" + FATFISSAAT + ",FATFISEVRAKNO1=" + FATFISEVRAKNO1 + ",FATFISKDVORANI=" + FATFISKDVORANI + ",FATFISMALTOP=" + FATFISMALTOP + ",FATFISKALINDYTOP=" + FATFISKALINDYTOP + ",FATFISBRUTTOPLAM=" + FATFISBRUTTOPLAM + ",FATFISKDVMATRAHI=" + FATFISKDVMATRAHI + ",FATFISKDVTUTARI=" + FATFISKDVTUTARI + ",FATFISARATOPLAM=" + FATFISARATOPLAM + ",FATFISGENTOPLAM=" + FATFISGENTOPLAM + ",FATFISTOPOTUT=" + FATFISTOPOTUT;

                                int sonuc = db.nonQuery(CommandType.Text, sbInsertFatFis.ToString(), prmFatFis);
                                if (sonuc == 1)
                                {
                                    int fatHarTipi = 13;
                                    int fatHarSiraNo = 0;
                                    foreach (stokHareket item in h.lstStokHareket)
                                    {
                                        #region fatura-hareket-kayıt
                                        fatHarSiraNo++;
                                        StringBuilder sbInsertFatHar = new StringBuilder();
                                        sbInsertFatHar.Append("insert into FATHAR(");
                                        sbInsertFatHar.Append("FATHARTAR,FATHARREFNO,FATHARTIPI,FATHARGCFLAG,FATHARKAYONC,FATHARKAYNAK,FATHARSIRANO,FATHARKODTIP,FATHARSTKKOD,FATHARSTKCINS,FATHARSTKBRM,FATHARDEPOKOD,FATHARBARKOD,FATHARMIKTAR,FATHARFIYTIP,FATHARFIYAT,FATHARTUTAR,FATHARKDVYUZ,FATHARISKYUZ1,FATHARISKYTUT1,FATHARTOPLAMIND,FATHARKDVMATRAH,FATHARKDVTUTAR,FATHARTOPLAMTUT,FATHARNETTUTAR,FATHARNETFIYAT,FATHAROTVMATRAH,FATHAROTVTUTAR)");
                                        sbInsertFatHar.Append("values (@FATHARTAR,@FATHARREFNO,@FATHARTIPI,2,1,@FATHARKAYNAK,@FATHARSIRANO,@FATHARKODTIP,@FATHARSTKKOD,@FATHARSTKCINS,'AD.','D-01',@FATHARBARKOD,@FATHARMIKTAR,@FATHARFIYTIP,@FATHARFIYAT,@FATHARTUTAR,@FATHARKDVYUZ,@FATHARISKYUZ1,@FATHARISKYTUT1,@FATHARTOPLAMIND,@FATHARKDVMATRAH,@FATHARKDVTUTAR,@FATHARTOPLAMTUT,@FATHARNETTUTAR,@FATHARNETFIYAT,@FATHAROTVMATRAH,@FATHAROTVTUTAR)");
                                        string FATHARTAR = FatFisTar.stringKaldir();
                                        string FATHARREFNO = FATFISREFNO.stringKaldir();
                                        string FATHARTIPI = fatHarTipi.ToString().stringKaldir();//nerden geldiğine bakılacak;
                                        string FATHARKAYNAK = FATFISKAYNAK.stringKaldir();
                                        string FATHARSIRANO = fatHarSiraNo.ToString().stringKaldir();
                                        string FATHARKODTIP = "1";//1=stok kartı,2=hizmet kartı, 3=açıklama s., 4=indirim s.,5=masraf,6=paket,7=paket/stok, 8=paket/hiz,9=demirbaş
                                        string FATHARSTKKOD = item.stokKodu.stringKaldir();
                                        string FATHARSTKCINS = db.exReaderTekSutun(CommandType.Text, "select STKCINSI from stkKart where STKKOD=@stkKod", "stkKod=" + item.stokKodu).stringKaldir();
                                        string FATHARBARKOD = item.barkodSatis.Trim().stringKaldir();
                                        string FATHARMIKTAR = item.miktar.Trim().stringKaldir();
                                        string FATHARFIYTIP = "1";
                                        string FATHARFIYAT = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARTUTAR = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARKDVYUZ = item.KDVYuzde.ToString().Replace(",", ".").Trim().stringKaldir();
                                        string FATHARISKYUZ1 = item.toplamIndirim.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARISKYTUT1 = item.toplamIndirim.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARTOPLAMIND = item.toplamIndirim.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARKDVMATRAH = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir(); //düzenlenecek.fiyat-kdv 
                                        string FATHARKDVTUTAR = item.toplamKDV.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARTOPLAMTUT = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();//kdv eklenmiş tutar
                                        string FATHARNETTUTAR = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();
                                        string FATHARNETFIYAT = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();
                                        string FATHAROTVMATRAH = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();
                                        string FATHAROTVTUTAR = item.toplamFiyat.Trim().Replace(",", ".").stringKaldir();

                                        string prmFatHar = "FATHARTAR=" + FATHARTAR + "," + "FATHARREFNO=" + FATHARREFNO + "," + "FATHARTIPI=" + FATHARTIPI + "," + "FATHARKAYNAK=" + FATHARKAYNAK + "," + "FATHARSIRANO=" + FATHARSIRANO + "," + "FATHARKODTIP=" + FATHARKODTIP + "," + "FATHARSTKKOD=" + FATHARSTKKOD + "," + "FATHARSTKCINS=" + FATHARSTKCINS + "," + "FATHARBARKOD=" + FATHARBARKOD + "," + "FATHARMIKTAR=" + FATHARMIKTAR + "," + "FATHARFIYTIP=" + FATHARFIYTIP + "," + "FATHARFIYAT=" + FATHARFIYAT + "," + "FATHARTUTAR=" + FATHARTUTAR + "," + "FATHARKDVYUZ=" + FATHARKDVYUZ + "," + "FATHARISKYUZ1=" + FATHARISKYUZ1 + "," + "FATHARISKYTUT1=" + FATHARISKYTUT1 + "," + "FATHARTOPLAMIND=" + FATHARTOPLAMIND + "," + "FATHARKDVMATRAH=" + FATHARKDVMATRAH + "," + "FATHARKDVTUTAR=" + FATHARKDVTUTAR + "," + "FATHARTOPLAMTUT=" + FATHARTOPLAMTUT + "," + "FATHARNETTUTAR=" + FATHARNETTUTAR + "," + "FATHARNETFIYAT=" + FATHARNETFIYAT + "," + "FATHAROTVMATRAH=" + FATHAROTVMATRAH + "," + "FATHAROTVTUTAR=" + FATHAROTVTUTAR;
                                        sonuc = db.nonQuery(CommandType.Text, sbInsertFatHar.ToString(), prmFatHar);
                                        if (sonuc == 0)
                                        {
                                            MessageBox.Show("Kayıt yapılamadı");
                                            break;
                                        }
                                        #endregion
                                    }

                                    #region FATFISTOPLAM kayıt
                                    StringBuilder sbFatFisToplam = new StringBuilder();
                                    string FFTTAR = "";
                                    string FFTREFNO = "";
                                    string FFTTIPI = "";
                                    string FFTKAYNAK = "";
                                    string FFTKDVDAHILFLAG = "";
                                    string FFTEVRAKNO1 = "";
                                    string FFTKONU = "";
                                    string FFTBASLIK = "";
                                    decimal kdvBol = 1.08M;//fatura kdv oranı
                                    string FFTTUTAR = "";
                                    string FFTMATRAH = "";
                                    string prmFatFisToplam = "";
                                    FFTTAR = FatFisTar.stringKaldir();
                                    FFTREFNO = fatFisHarRefNo.ToString().stringKaldir();
                                    FFTTIPI = kasaKodu.stringKaldir();
                                    FFTKAYNAK = FATFISKAYNAK.stringKaldir();
                                    FFTKDVDAHILFLAG = "1";
                                    FFTEVRAKNO1 = h.fisKodu.stringKaldir();
                                    kdvBol = 1.08M;//fatura kdv oranı
                                    if (h.toplamIndirim.Trim().Length > 0 && h.toplamIndirim.Trim() != "0")
                                    {
                                        sbFatFisToplam.Append("insert into FATFISTOPLAM");
                                        sbFatFisToplam.Append("( FFTTAR,FFTREFNO,FFTTIPI,FFTGCFLAG,FFTKAYONC,FFTKAYNAK,FFTKDVDAHILFLAG,FFTEVRAKNO1,FFTKONU,FFTBASLIK,FFTTUTAR,FFTMATRAH)");
                                        sbFatFisToplam.Append("values ( @FFTTAR,@FFTREFNO,@FFTTIPI,2,1,@FFTKAYNAK,@FFTKDVDAHILFLAG,@FFTEVRAKNO1,@FFTKONU,@FFTBASLIK,@FFTTUTAR,@FFTMATRAH )");

                                        FFTKONU = "1";
                                        FFTBASLIK = "Kal.İnd.1 (%)";
                                        FFTTUTAR = (Convert.ToDecimal(h.toplamIndirim) / kdvBol).ToString().stringKaldir();
                                        FFTMATRAH = h.toplamIndirim.stringKaldir();
                                        prmFatFisToplam = "FFTTAR=" + FFTTAR + "," + "FFTREFNO=" + FFTREFNO + "," + "FFTTIPI=" + FFTTIPI + "," + "FFTKAYNAK=" + FFTKAYNAK + "," + "FFTKDVDAHILFLAG=" + FFTKDVDAHILFLAG + "," + "FFTEVRAKNO1=" + FFTEVRAKNO1 + "," + "FFTKONU=" + FFTKONU + "," + "FFTBASLIK=" + FFTBASLIK + "," + "FFTTUTAR=" + FFTTUTAR + "," + "FFTMATRAH=" + FFTMATRAH;
                                        db.nonQuery(CommandType.Text, sbFatFisToplam.ToString(), prmFatFisToplam);
                                    }
                                    sbFatFisToplam.Clear();
                                    string FFTKDVORAN = "8";//burası çözülecek
                                    FFTKONU = "101";
                                    FFTBASLIK = "KDV(%8)";
                                    FFTTUTAR = h.genelToplam.stringKaldir();
                                    FFTMATRAH = h.genelToplam.stringKaldir();
                                    sbFatFisToplam.Append("insert into FATFISTOPLAM");
                                    sbFatFisToplam.Append("( FFTTAR,FFTREFNO,FFTTIPI,FFTGCFLAG,FFTKAYONC,FFTKAYNAK,FFTKDVDAHILFLAG,FFTEVRAKNO1,FFTKONU,FFTBASLIK,FFTTUTAR,FFTMATRAH,FFTKDVORAN )");
                                    sbFatFisToplam.Append("values(@FFTTAR,@FFTREFNO,@FFTTIPI,2,1,@FFTKAYNAK,@FFTKDVDAHILFLAG,@FFTEVRAKNO1,@FFTKONU,@FFTBASLIK,@FFTTUTAR,@FFTMATRAH,@FFTKDVORAN)");

                                    prmFatFisToplam = "FFTTAR=" + FFTTAR + "," + "FFTREFNO=" + FFTREFNO + "," + "FFTTIPI=" + FFTTIPI + "," + "FFTKAYNAK=" + FFTKAYNAK + "," + "FFTKDVDAHILFLAG=" + FFTKDVDAHILFLAG + "," + "FFTEVRAKNO1=" + FFTEVRAKNO1 + "," + "FFTKONU=" + FFTKONU + "," + "FFTBASLIK=" + FFTBASLIK + "," + "FFTTUTAR=" + FFTTUTAR + "," + "FFTMATRAH=" + FFTMATRAH + ",FFTKDVORAN=" + FFTKDVORAN;
                                    db.nonQuery(CommandType.Text, sbFatFisToplam.ToString(), prmFatFisToplam);
                                    #endregion

                                    string strStkFis = db.exReaderTekSutun(CommandType.Text, "select harrefdeger from HARREFNO where harrefmodul=1 and harrefkonu=1", "").ToString();
                                    int stkFisRefNo = Convert.ToInt32(strStkFis);
                                    db.nonQuery(CommandType.Text, "update harrefno set harrefdeger=(harrefdeger+1) where harrefmodul=1 and harrefkonu=1");

                                    #region stkFis kayıt
                                    StringBuilder sbStkFis = new StringBuilder();
                                    sbStkFis.Append("insert into STKFIS");
                                    sbStkFis.Append("(STKFISTAR,STKFISREFNO,STKFISTIPI,STKFISGCFLAG,STKFISKAYONC,STKFISKAYNAK,STKFISANADEPO,STKFISEVRAKNO1,STKFISEVRAKNO2,STKFISDOVTAR,STKFISTOPBTUT,STKFISTOPISK,STKFISTOPNTUT,STKFISTOPKDV,STKFISTOPKTUT,STKFISSEVNO,STKFISTOPOTUT )");
                                    sbStkFis.Append("values(@STKFISTAR,@STKFISREFNO,@STKFISTIPI,2,2,@STKFISKAYNAK,'D-01',@STKFISEVRAKNO1,@STKFISEVRAKNO2,@STKFISDOVTAR,@STKFISTOPBTUT,@STKFISTOPISK,@STKFISTOPNTUT,@STKFISTOPKDV,@STKFISTOPKTUT,1,@STKFISTOPOTUT)");
                                    string STKFISTAR = FatFisTar.stringKaldir();
                                    string STKFISREFNO = stkFisRefNo.ToString().stringKaldir();
                                    string STKFISTIPI = "32";
                                    string STKFISKAYNAK = "3";//kasadan;
                                    string STKFISEVRAKNO1 = DateTime.Now.ToString("yyyyMMdd") + h.fisKodu;
                                    string STKFISEVRAKNO2 = DateTime.Now.ToString("yyyyMMdd") + h.fisKodu;//?????
                                    string STKFISDOVTAR = FatFisTar.stringKaldir();
                                    string STKFISTOPBTUT = h.genelToplam.stringKaldir();
                                    string STKFISTOPISK = h.toplamIndirim.stringKaldir();
                                    string STKFISTOPNTUT = (Convert.ToDecimal(h.genelToplam) - Convert.ToDecimal(h.toplamIndirim)).ToString().stringKaldir();
                                    string STKFISTOPKDV = h.kdvToplam.stringKaldir();
                                    string STKFISTOPKTUT = h.genelToplam.stringKaldir();//buralara detaylı bakılacak.
                                    string STKFISTOPOTUT = h.genelToplam.stringKaldir();
                                    string prmStkFis = "STKFISTAR=" + STKFISTAR + "," + "STKFISREFNO=" + STKFISREFNO + "," + "STKFISTIPI=" + STKFISTIPI + "," + "STKFISKAYNAK=" + STKFISKAYNAK + ",STKFISEVRAKNO1=" + STKFISEVRAKNO1 + "," + "STKFISEVRAKNO2=" + STKFISEVRAKNO2 + "," + "STKFISDOVTAR=" + STKFISDOVTAR + "," + "STKFISTOPBTUT=" + STKFISTOPBTUT + "," + "STKFISTOPISK=" + STKFISTOPISK + "," + "STKFISTOPNTUT=" + STKFISTOPNTUT + "," + "STKFISTOPKDV=" + STKFISTOPKDV + "," + "STKFISTOPKTUT=" + STKFISTOPKTUT + ",STKFISTOPOTUT=" + STKFISTOPOTUT;
                                    db.nonQuery(CommandType.Text, sbStkFis.ToString(), prmStkFis);
                                    #endregion
                                    #region stkHareketKayit
                                    int gridSira = 0;
                                    foreach (stokHareket item in h.lstStokHareket)
                                    {
                                        gridSira++;
                                        StringBuilder sbStkHar = new StringBuilder();
                                        sbStkHar.Append("insert into STKHAR");
                                        sbStkHar.Append("(STKHARTAR,STKHARREFNO,STKHARTIPI,STKHARGCFLAG,STKHARKAYONC,STKHARKAYNAK,STKHARANADEPO,STKHARSTKKOD,STKHARSTKCINS,STKHARSTKBRM,STKHARBARKOD,STKHARMIKTAR,STKHARFIYAT,STKHARTUTAR,STKHARKDVYUZ,STKHARISKYUZ1,STKHARISKYTUT1,STKHARTOPLAMIND,STKHARKDVMATRAH,STKHARKDVTUTAR,STKHARTOPLAMTUT,STKHARFIYTIP,STKHARSIRANO,STKHARNETTUTAR,STKHARNETFIYAT,STKHAROTVMATRAH,STKHAROTVTUTAR)");
                                        sbStkHar.Append("values(@STKHARTAR,@STKHARREFNO,@STKHARTIPI,2,2,@STKHARKAYNAK,'D-01',@STKHARSTKKOD,@STKHARSTKCINS,'AD.',@STKHARBARKOD,@STKHARMIKTAR,@STKHARFIYAT,@STKHARTUTAR,@STKHARKDVYUZ,@STKHARISKYUZ1,@STKHARISKYTUT1,@STKHARTOPLAMIND,@STKHARKDVMATRAH,@STKHARKDVTUTAR,@STKHARTOPLAMTUT,'1',@STKHARSIRANO,@STKHARNETTUTAR,@STKHARNETFIYAT,@STKHAROTVMATRAH,@STKHAROTVTUTAR)");
                                        string STKHARTAR = FatFisTar.stringKaldir();
                                        string STKHARREFNO = stkFisRefNo.ToString().stringKaldir();
                                        string STKHARTIPI = STKFISKAYNAK.stringKaldir();

                                        string STKHARKAYNAK = FATFISKAYNAK.stringKaldir();
                                        string STKHARSTKKOD = item.stokKodu.stringKaldir();
                                        string STKHARSTKCINS = db.exReaderTekSutun(CommandType.Text, "select STKCINSI from stkKart where STKKOD=@stkKod", "stkKod=" + item.stokKodu).stringKaldir();
                                        string STKHARBARKOD = item.barkodSatis.stringKaldir();
                                        string STKHARMIKTAR = item.miktar.stringKaldir();
                                        string STKHARFIYAT = item.toplamFiyat.stringKaldir();
                                        string STKHARTUTAR = item.toplamFiyat.stringKaldir();
                                        string STKHARKDVYUZ = item.KDVYuzde.ToString().stringKaldir();
                                        string STKHARISKYUZ1 = "0";
                                        string STKHARISKYTUT1 = item.kasiyerIndirim.stringKaldir();
                                        string STKHARTOPLAMIND = item.toplamIndirim.stringKaldir();
                                        string STKHARKDVMATRAH = item.toplamFiyat.stringKaldir();
                                        string STKHARKDVTUTAR = item.toplamKDV.stringKaldir();
                                        string STKHARTOPLAMTUT = item.toplamFiyat.stringKaldir();
                                        string STKHARSIRANO = gridSira.ToString().stringKaldir();
                                        string STKHARNETTUTAR = item.toplamFiyat.stringKaldir();
                                        string STKHARNETFIYAT = item.toplamFiyat.stringKaldir();
                                        string STKHAROTVMATRAH = item.toplamFiyat.stringKaldir();
                                        string STKHAROTVTUTAR = item.toplamFiyat.stringKaldir();
                                        string prmStkHar = "";
                                        prmStkHar += "STKHARTAR=" + STKHARTAR + ",STKHARREFNO=" + STKHARREFNO + ",STKHARTIPI=" + STKHARTIPI + ",STKHARKAYNAK=" + STKHARKAYNAK + ",STKHARSTKKOD=" + STKHARSTKKOD + ",STKHARSTKCINS=" + STKHARSTKCINS + ",STKHARBARKOD=" + STKHARBARKOD + ",STKHARMIKTAR=" + STKHARMIKTAR + ",STKHARFIYAT=" + STKHARFIYAT + ",STKHARTUTAR=" + STKHARTUTAR + ",STKHARKDVYUZ=" + STKHARKDVYUZ + ",STKHARISKYUZ1=" + STKHARISKYUZ1 + ",STKHARISKYTUT1=" + STKHARISKYTUT1 + ",STKHARTOPLAMIND=" + STKHARTOPLAMIND + ",STKHARKDVMATRAH=" + STKHARKDVMATRAH + ",STKHARKDVTUTAR=" + STKHARKDVTUTAR + ",STKHARTOPLAMTUT=" + STKHARTOPLAMTUT + ",STKHARSIRANO=" + STKHARSIRANO + ",STKHARNETTUTAR=" + STKHARNETTUTAR + ",STKHARNETFIYAT=" + STKHARNETFIYAT + ",STKHAROTVMATRAH=" + STKHAROTVMATRAH + ",STKHAROTVTUTAR=" + STKHAROTVTUTAR;
                                        db.nonQuery(CommandType.Text, sbStkHar.ToString(), prmStkHar);
                                    }
                                    #endregion

                                }
                                else
                                {
                                    MessageBox.Show("Kayıt Yapılamadı");
                                    break;
                                }



                                satir = sonrakiKayitaGit(satir, sr);
                            }
                            /*
                             catch (Exception ex)
                             {

                                 MessageBox.Show("Bir hata oluştu." + Environment.NewLine + ex.Message);
                             }**/
                        }
                    }
                    else
                    {
                        satir = sr.ReadLine();
                    }
                }
                sr.Close();
            }
        }

        public string sonrakiKayitaGit(string satir, StreamReader sr)
        {
            satir = sr.ReadLine();
            while (satir != null && satir.Substring(0, 2) != "01")
            {
                satir = sr.ReadLine();
            }
            return satir;
        }
        public bool hareketKayitKontrol(string fatfistar, string fatfistip, string fatfiskasrefno)
        {
            DateTime dtFisTar = Convert.ToDateTime(fatfistar);
            //  int adet = db.FATFIS.ToList().Where(d => d.FATFISTAR == dtFisTar).Count();
            int adet = 0;


            return true ? adet == 0 : false;
        }

        private void rdbtnTarihsel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTarihsel.Checked)
            {
                dtAktar1.Visible = true;
                dtAktar2.Visible = true;
            }
            else
            {
                dtAktar1.Visible = false;
                dtAktar2.Visible = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            stokKartiAktar();
        }
    }
}
