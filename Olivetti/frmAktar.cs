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
            string dosyaYolu = Properties.Settings.Default.Kasalar[0].Split('*')[2] + "\\URUN.GTF";
            if (File.Exists(dosyaYolu))
            {
                File.Delete(dosyaYolu);
            }
            Fonksiyon.dosyayaYaz("<SIGNATURE=GNDPLU.GDF><VERSION=0223000>", dosyaYolu);

            myDbHelper db = new myDbHelper(new sqlDbHelper());
            DataTable dt = db.exReaderDT(CommandType.Text, "select top 10 * from stkkart where len(stkkod)>2");
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

                }
            }

        }

        private void btnHareketAktar_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpKasalar.Controls)
            {
                if (item is CheckBox && (item as CheckBox).Checked)
                {
                    int kasaIndex = Convert.ToInt32(item.Text.Replace("Kasa ", "")) - 1;
                    //hareketAktar(rdbtnHepsi2.Checked, dtHareket1.Value, dtHareket2.Value, kasaIndex);
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
                            h.genelToplam = satir.Substring(91, 15).Trim();
                            h.kdvToplam = satir.Substring(106, 15).Trim();
                            h.toplamIndirim = satir.Substring(121, 15).Trim();
                            h.satirlarToplamIndirim = satir.Substring(136, 15).Trim();
                            h.otomatikIndirim = satir.Substring(151, 15).Trim();
                            h.promosyonIndirim = satir.Substring(181, 15).Trim();
                            h.yuvarlama = satir.Substring(196, 15).Trim();
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
                            stk.birimFiyat = satir.Substring(61, 15);
                            stk.toplamFiyat = satir.Substring(76, 15);
                            stk.toplamKDV = satir.Substring(91, 15);
                            stk.toplamIndirim = satir.Substring(106, 15);
                            stk.kasiyerIndirim = satir.Substring(121, 15);
                            stk.otomatikIndirim = satir.Substring(136, 15);
                            stk.musteriIndirimi = satir.Substring(151, 15);
                            stk.promosyonIndirimi = satir.Substring(166, 15);
                            stk.satisDurumu = satir.Substring(181, 1);//0:normal satış,1:bağlantılı satış,2:mix&match olarak satıldı ,
                            stk.barkodSatis = satir.Substring(182, 24);
                            stk.odemeTipiReferansi = satir.Substring(221, 2);
                            stk.satisTipi = satir.Substring(225, 1);//0:barkodlusatış,1:stok kodu
                            h.lstStokHareket.Add(stk);
                            satir = sr.ReadLine();
                        }
                        else
                        {
                            FATFIS myFatFis = new FATFIS();
                            string strFatFis = db.exReaderTekSutun(CommandType.Text, "select harrefdeger from HARREFNO where harrefmodul=3 and harrefkonu=1", "").ToString();
                            int fatFisHarRefNo = 0;
                            try
                            {
                                fatFisHarRefNo = Convert.ToInt32(strFatFis);


                                db.nonQuery(CommandType.Text, "update harrefno set harrefdeger=(harrefdeger+1) where harrefmodul=3 and harrefkonu=1");
                                StringBuilder sbInsertFatFis = new StringBuilder();

                                sbInsertFatFis.Append("insert into FATFIS");
                                sbInsertFatFis.Append("( FATFISTAR,FATFISREFNO,FATFISTIPI,FATFISGCFLAG,FATFISKAYONC,FATFISKAYNAK,FATFISKAPFLAG,FATFISKDVDAHILFLAG,FATFISANADEPO,FATFISADRESNO,FATFISSAAT,FATFISEVRAKNO1,FATFISKDVORANI,FATFISMALTOP,FATFISKALINDYTOP,FATFISBRUTTOPLAM,FATFISKDVMATRAHI,FATFISKDVTUTARI,FATFISARATOPLAM,FATFISGENTOPLAM,FATFISSEVNO,FATFISTOPOTUT )");
                                sbInsertFatFis.Append("values ( @FatFisTar,@FATFISREFNO,@FATFISTIPI,2,1,@FATFISKAYNAK,1,@FATFISKDVDAHILFLAG,'D-01',1,'@FATFISSAAT','@FATFISEVRAKNO1',@FATFISKDVORANI,@FATFISMALTOP,@FATFISKALINDYTOP,@FATFISBRUTTOPLAM,@FATFISKDVMATRAHI,@FATFISKDVTUTARI,@FATFISARATOPLAM,@FATFISGENTOPLAM,1,@FATFISTOPOTUT)");
                                // values ( '20160829',101790,13,2,1,3,1,1,'D-01',1,'11:26','4299',8,22.4,4.19,18.21,16.86,1.35,18.21,18.21,1,18.21 )

                                string FatFisTar = Convert.ToDateTime(h.tarih).ToString("yyyMMdd");
                                string FATFISREFNO = fatFisHarRefNo.ToString();
                                string FATFISTIPI = kasaKodu;
                                string FATFISKAYNAK = "3";//kasadan alınacak
                                string FATFISKDVDAHILFLAG = "1";

                                //FATFISKAYNAK=1 kaynak programı modül no???
                                //HARREFNO fatFisHarRefNo = db.FirstOrDefault(c => c.HARREFMODUL == 3 && c.HARREFKONU == 1);
                                int fatFisRefNo = 0;
                                // fatFisHarRefNo.HARREFDEGER = fatFisHarRefNo.HARREFDEGER + 1;
                                myFatFis.FATFISTAR = Convert.ToDateTime(h.tarih);
                                myFatFis.FATFISREFNO = fatFisRefNo;
                                myFatFis.FATFISTIPI = Convert.ToInt32(kasaKodu);
                                myFatFis.FATFISGCFLAG = 2;
                                myFatFis.FATFISKAYONC = 1;
                                myFatFis.FATFISKAYNAK = 3; //kasadan gelecek
                                myFatFis.FATFISKAPFLAG = 1;
                                myFatFis.FATFISKDVDAHILFLAG = 1;
                                myFatFis.FATFISANADEPO = "D-01";
                                myFatFis.FATFISADRESNO = 1;
                                myFatFis.FATFISSAAT = h.saat.Substring(0, 2) + ":" + h.saat.Substring(2, 2);
                                myFatFis.FATFISEVRAKNO1 = h.fisKodu; //fiş kodu
                                myFatFis.FATFISKDVORANI = 8; // burası fişte yok, her ürün için ayrı ayrı var
                                myFatFis.FATFISMALTOP = Convert.ToDecimal(h.genelToplam);//brüt toplam(5.46+0.44) ham fiyat + kdv
                                myFatFis.FATFISKALINDYTOP = Convert.ToDecimal(h.satirlarToplamIndirim); //
                                myFatFis.FATFISBRUTTOPLAM = Convert.ToDecimal(h.genelToplam);//indirimden sonraki fiyat
                                myFatFis.FATFISKDVMATRAHI = Convert.ToDecimal(h.genelToplam); //kdvsiz fiyat
                                myFatFis.FATFISKDVTUTARI = Convert.ToDecimal(h.kdvToplam);
                                myFatFis.FATFISARATOPLAM = Convert.ToDecimal(h.genelToplam);//aratoplam fiyatı bulunacak
                                myFatFis.FATFISGENTOPLAM = Convert.ToDecimal(h.genelToplam);
                                myFatFis.FATFISDOVTAR = Convert.ToDateTime(h.tarih);
                                myFatFis.FATFISSEVNO = 1;
                                myFatFis.FATFISTOPOTUT = Convert.ToDecimal(h.genelToplam);//ötv'li fiş toplamı
                                //db.FATFIS.Add(myFatFis);
                                // db.SaveChanges();
                                //0.89 indirim, 5.01 indirimli fiyat., 5.9 doğal fiyat,
                                int fatHarTipi = 13;
                                int fatHarSiraNo = 1;
                                foreach (stokHareket item in h.lstStokHareket)
                                {
                                    FATHAR myFatHar = new FATHAR();
                                    myFatHar.FATHARTAR = myFatFis.FATFISTAR;
                                    myFatHar.FATHARREFNO = myFatFis.FATFISREFNO;
                                    myFatHar.FATHARTIPI = fatHarTipi;//13 nerden geliyor bakılacak, kasadan geliyor
                                    myFatHar.FATHARGCFLAG = myFatFis.FATFISGCFLAG;
                                    myFatHar.FATHARKAYONC = myFatFis.FATFISKAYONC;
                                    myFatHar.FATHARKAYNAK = myFatFis.FATFISKAYNAK;
                                    myFatHar.FATHARSIRANO = fatHarSiraNo;//for içinde düzenle
                                    myFatHar.FATHARKODTIP = 1;//1=stok kartı,2=hizmet kartı, 3=açıklama s., 4=indirim s.,5=masraf,6=paket,7=paket/stok, 8=paket/hiz,9=demirbaş
                                    myFatHar.FATHARSTKKOD = item.stokKodu;
                                    myFatHar.FATHARSTKCINS = "stok açıklaması";
                                    myFatHar.FATHARSTKBRM = "AD.";
                                    myFatHar.FATHARDEPOKOD = "D-01";
                                    myFatHar.FATHARBARKOD = item.barkodSatis;
                                    myFatHar.FATHARMIKTAR = Convert.ToInt32(item.miktar);
                                    myFatHar.FATHARFIYTIP = "1";
                                    fatHarSiraNo++;
                                }

                                FATFISTOPLAM myFatFisToplam = new FATFISTOPLAM();
                                myFatFisToplam.FFTTAR = myFatFis.FATFISTAR;
                                myFatFisToplam.FFTREFNO = myFatFis.FATFISREFNO;
                                myFatFisToplam.FFTTIPI = fatHarTipi;
                                myFatFisToplam.FFTGCFLAG = myFatFis.FATFISGCFLAG;
                                myFatFisToplam.FFTKAYONC = 1;
                                myFatFisToplam.FFTKAYNAK = myFatFis.FATFISKAYNAK;
                                myFatFisToplam.FFTKDVDAHILFLAG = 1;
                                myFatFisToplam.FFTEVRAKNO1 = myFatFis.FATFISEVRAKNO1;
                                myFatFisToplam.FFTKONU = 1;
                                myFatFisToplam.FFTBASLIK = "Kal.İnd.1 (%)";
                                myFatFisToplam.FFTTUTAR = Convert.ToDecimal(0);//3.88 değerinin ne olduğunu anlamadım //FATHARISKYTUT1 değerleri toplamı
                                myFatFisToplam.FFTMATRAH = Convert.ToDecimal(h.toplamIndirim);
                                //db.FATFISTOPLAM.Add(myFatFisToplam);
                                /* insert into FATFISTOPLAM
    ( ,,,FFTBASLIK,FFTTUTAR,FFTMATRAH ) 
    values ( ,'','Kal.İnd.1 (%)',3.88,4.19 )*/

                                FATFISTOPLAM myFatFisToplam2 = new FATFISTOPLAM();

                                //stok hareketleri
                              //  HARREFNO harRefStkFisRef = db.HARREFNO.FirstOrDefault(c => c.HARREFMODUL == 1 && c.HARREFKONU == 1);
                              //  int STKFISREFNO = harRefStkFisRef.HARREFDEGER;
                                //harRefStkFisRef.HARREFDEGER++;

                                STKFIS myStkFis = new STKFIS();
                                myStkFis.STKFISTAR = myFatFis.FATFISTAR;
                              //  myStkFis.STKFISREFNO = STKFISREFNO;
                                myStkFis.STKFISTIPI = 32;//kasaya göre değişiyor..
                                myStkFis.STKFISGCFLAG = 2;
                                /*
                                 *   //0.89 indirim, 5.01 indirimli fiyat., 5.9 doğal fiyat,

                                /*insert into FATFIS
                                    FATFISTAR=20160826+
                                   FATFISREFNO=101771
                                 ,FATFISTIPI=13,FATFISGCFLAG=2,FATFISKAYONC=1,FATFISKAYNAK=3,FATFISKAPFLAG=1,FATFISKDVDAHILFLAG=1,FATFISANADEPO=D-01,FATFISADRESNO=1,FATFISSAAT=20:34,FATFISEVRAKNO1=34,FATFISKDVORANI=8,FATFISMALTOP=5.9,FATFISKALINDYTOP=0.89,FATFISBRUTTOPLAM=5.01,FATFISKDVMATRAHI=4.64,FATFISKDVTUTARI=0.37,FATFISARATOPLAM=5.01,FATFISGENTOPLAM=5.01,FATFISDOVTAR=20160826,FATFISSEVNO=1,FATFISTOPOTUT=5.01 */

                               // db.SaveChanges();
                                satir = sonrakiKayitaGit(satir, sr);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Bir hata oluştu." + Environment.NewLine + ex.Message);
                            }
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
    }
}
