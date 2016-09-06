using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Olivetti
{
    public partial class frmAnaForm : Form
    {
        Fonksiyon f = new Fonksiyon();
        ETA_DENEME_2016Entities db = new ETA_DENEME_2016Entities();
        public frmAnaForm()
        {
            InitializeComponent();
        }

        private void rdbtnTarihsel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTarihsel.Checked)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }

        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            string t = "01  04275                    4275                    BLADE DEO 150ML FASTER                                                          BLADE DEO 150ML FASTBLADE DEO 150ML FASTBLADE DEO 150ML 1       1       1                                                                            01                                                                                  4,89           4,89           4,89           4,89                                                                                                                      3                                                    0     2                                                                                             0                                                                                                         0              0                                      ";
            MessageBox.Show(t.Substring(828, 15));
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\alanlar.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.WriteLine("stok kodu " + t.Substring(5, 24));
            sw.WriteLine("stok açıklaması " + t.Substring(53, 40));
            sw.WriteLine("extra açıklama " + t.Substring(93, 40));
            sw.WriteLine("pos açıklama " + t.Substring(133, 20));
            sw.WriteLine("raf etiketi açıklama " + t.Substring(153, 20));
            sw.WriteLine("terazi etiketi açıklama " + t.Substring(173, 16));
            sw.WriteLine("stok bölümü " + t.Substring(189, 8));
            sw.WriteLine("reyon tanımı " + t.Substring(197, 8));
            sw.WriteLine("ürün tipi " + t.Substring(205, 8));
            sw.WriteLine("indirim grubu " + t.Substring(213, 8));
            sw.WriteLine("indirim durum kodu " + t.Substring(221, 1));
            sw.WriteLine("indirim yüzdesi " + t.Substring(222, 15));
            sw.WriteLine("indirim tutarı " + t.Substring(237, 15));
            sw.WriteLine("reserved " + t.Substring(252, 6));
            sw.WriteLine("Bağlı stok kodu " + t.Substring(258, 24));
            sw.WriteLine("birim " + t.Substring(282, 1));
            sw.WriteLine("birim böleni " + t.Substring(283, 15));
            sw.WriteLine("birim çarpanı " + t.Substring(298, 15));
            sw.WriteLine("satış fiyatı " + t.Substring(335, 15));
            sw.WriteLine("satış fiyatı2 " + t.Substring(370, 15));
            sw.WriteLine("satış fiyatı3 " + t.Substring(385, 15));
            sw.WriteLine("alış fiyatı " + t.Substring(430, 15));
            sw.WriteLine("0-39 fiyatın indexi " + t.Substring(505, 2));
            sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 2. " + t.Substring(505, 2));
            sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 3. " + t.Substring(507, 2));
            sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 4. " + t.Substring(509, 2));

            sw.WriteLine("KDV'ler fiyatlara dahil (1)/hariç (0) bit flagleri (1-5 satış fiyatlarına,6-10 alış fiyatlarına) Örnek:Tüm fiyatların KDV dahil olması için (alış ve satış) 1023 olarak gönderilmeli  :" + t.Substring(525, 5));
            sw.WriteLine("Satış KDV grup numarası (0’dan başlar. Max 9) KDV yüzdesi (%0,%1,%8..) değildir. ", t.Substring(531, 3));



            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
            kasalariGetir();
        }
        public void hareketAktar(bool hepsi, DateTime tarih1, DateTime tarih2, int kasaIndex)
        {
            string dosya_yolu = Properties.Settings.Default.Kasalar[kasaIndex].Split('*')[2];
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
                        }
                        else
                        {
                            FATFIS myFatFis = new FATFIS();
                            HARREFNO fatFisHarRefNo = db.HARREFNO.FirstOrDefault(c => c.HARREFMODUL == 3 && c.HARREFKONU == 1);
                            int fatFisRefNo = fatFisHarRefNo.HARREFDEGER;
                            fatFisHarRefNo.HARREFDEGER++;
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
                            db.FATFIS.Add(myFatFis);
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
                            db.FATFISTOPLAM.Add(myFatFisToplam);
                            /* insert into FATFISTOPLAM
( ,,,FFTBASLIK,FFTTUTAR,FFTMATRAH ) 
values ( ,'','Kal.İnd.1 (%)',3.88,4.19 )*/

                            FATFISTOPLAM myFatFisToplam2 = new FATFISTOPLAM();

                            //stok hareketleri
                            HARREFNO harRefStkFisRef = db.HARREFNO.FirstOrDefault(c => c.HARREFMODUL == 1 && c.HARREFKONU == 1);
                            int STKFISREFNO = harRefStkFisRef.HARREFDEGER;
                            harRefStkFisRef.HARREFDEGER++;

                            STKFIS myStkFis = new STKFIS();
                            myStkFis.STKFISTAR = myFatFis.FATFISTAR;
                            myStkFis.STKFISREFNO = STKFISREFNO;
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
            int adet = (from fis in db.FATFIS where fis.FATFISTAR == dtFisTar select fis).ToList().Count;
            return true ? adet == 0 : false;
        }
        public void hareketKayit()
        {

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
        private void btnayarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar frm = new frmAyarlar(this);
            frm.ShowDialog();
        }

        private void rdbtnTarihsel2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTarihsel2.Checked)
            {
                dtHareket1.Visible = true;
                dtHareket2.Visible = true;
            }
            else
            {
                dtHareket1.Visible = false;
                dtHareket2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpKasalar.Controls)
            {
                if (item is CheckBox && (item as CheckBox).Checked)
                {
                    int kasaIndex = Convert.ToInt32(item.Text.Replace("Kasa ", "")) - 1;
                    hareketAktar(rdbtnHepsi.Checked, dtHareket1.Value, dtHareket2.Value, kasaIndex);
                }
            }
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {

        }
        public void stokAktar()
        {
            var stkList = db.STKKART.ToList();
            foreach (STKKART item in stkList)
            {
                string satirNo = "01".boslukTamamla(4);
                string islemTuru = "0";
                string stkKodu = item.STKKOD.ToString().boslukTamamla(24);
                string eskiStkKodu = item.STKKOD.ToString().boslukTamamla(24);
                string stokAciklama = item.STKCINSI.ToString().boslukTamamla(40);
                string extraAciklama = item.STKCINSI.boslukTamamla(40);
                string posEkraniAciklama = item.STKCINSI.boslukTamamla(20);
                string rafEtiketiAciklama = item.STKCINSI.boslukTamamla(20);
                string teraziAciklama = item.STKCINSI.boslukTamamla(16);
                string stokBolumu = "1".boslukTamamla(8);
                string reyonTanimi = "1".boslukTamamla(8);
                string urunTipi = "1".boslukTamamla(8);
                string indirimGrubu = "".boslukTamamla(8);
                string indirimDurumu = "".boslukTamamla(1);//0 indirim yok,1 yüzde,2 bölüm,3 grup
                string indirimYuzdesi = "".boslukTamamla(15);//burası hangi tablodan alınacak
                string indirimTutari = "".boslukTamamla(15);//||
                string reserved = "".boslukTamamla(6);
                string bagliStokKodu = "".boslukTamamla(24);//bilinmiyor;
                string birim = "0";//0 adet,1 ağırlık,2uzunluk,3litre

                var d = from c in db.STKBIRIM select new { c.STKBIRIMBOLEN, c.STKBIRIMCARPAN, c.STKBIRIMAD };

                string birimBoleni = "".boslukTamamla(15);//!=0
                string birimCarpani = d.boslukTamamla(15);//!=0
                string ikinciBirimKodu = item.STKBIRIM2.boslukTamamla(15);
                string ucuncuBirimKodu = item.STKBIRIM.boslukTamamla(15);
                string gecisKatSayisi1 = "";
                string gecisKatSayisi2 = "";
                string gecisKatSayisiCarpar1 = "";//1 çarpar,0 böler
                string gecisKatSayisiCarpar2 = "";
                string satisFiyati = "";
                string satisFiyati2 = "";
                string satisFiyati3 = "";
                string satisFiyati4 = "";
                string satisFiyati5 = "";
                string alisFiyati = "";
                string alisFiyati1 = "";
                string alisFiyati2 = "";
                string alisFiyati3 = "";
                string alisFiyati4 = "";
                string alisFiyati5 = "";
                string fiyatinIndexi = "";
                string fiyatinIndexi2 = "";
                string fiyatinIndexi3 = "";
                string fiyatinIndexi4 = "";
                string fiyatinIndexi5 = "";
                string fiyatinIndexi6 = "";
                string fiyatinIndexi7 = "";
                string fiyatinIndexi8 = "";
                string fiyatinIndexi9 = "";
                string fiyatinIndexi10 = "";
                string kdvlerFiyataDahil = "";//haric (0) bit flagları (1-5 satış fiyatlarına ,6-10 alış fiyatlarına)
                string satisKdvGrupNo = "";
                string alisKdvGrupNo = "";
                string kdvKullanimSekli = "";//0 kendi kdvsi,1 bölüm kdvsi, 2 reyon kdvsi
                string izinVerMinSatAdedi = "";//0 kontrolEtme
                string izinVerMaxSatAdedi = "";//0 kontrolEtme
                string kasMaxIndYuzde = "";
                string kasMaxInd = "";
                string satisDurumu = "";//0.satılabilr,1:satış durduruldu
                string adetliSatisDurumu = "";
                string fiyatliSatisDurumu = "";
                string iadeEdilebilirlik = "";
                string saticiGirisi = "";
                string kodlaSatis = "";
                string indirimliSatis = "";
                string siparisVerilebilir = "";
                string teminciKodu = "";
                string krediSablonu = "";
                string teminGunSayisi = "";
                string siparisKatSayisi = "";
                string depoSiparis = "";
                string depoKritik = "";
                string depoMaxSeviye = "";
                string terazi = "";
                string katSayi1 = "";
                string katSayi2 = "";
                string katSayi3 = "";
                string katSayi4 = "";
                string katSayi5 = "";
                string katSayi6 = "";
                string katSayi7 = "";
                string katSayi8 = "";
                string stokKartiPuan = "";
                string uretimBilgisi = "";
                string etiketeYazilacakFiyat = "";
                string etiketeFiyat = "";
            }
        }

    }
    public static class bosluk
    {
        public static string boslukTamamla(this object o, int uzunluk)
        {
            string str = o.ToString();
            while (str.Length < uzunluk)
            {
                str += " ";
            }
            return str;
        }
    }
}
