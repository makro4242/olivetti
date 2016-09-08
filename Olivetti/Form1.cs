using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Olivetti
{
    public partial class frmAnaForm : Form
    {
        Fonksiyon f = new Fonksiyon();
        myEntities db = new myEntities();
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

            /* FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\alanlar.txt", FileMode.OpenOrCreate, FileAccess.Write);

             StreamWriter sw = new StreamWriter(fs);
             string dosya_yolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\projeler\\olivetti\\URUN.GTF";
             FileStream fsRead = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

             StreamReader swRead = new StreamReader(fsRead);
             string t = swRead.ReadLine();*/
            // t = swRead.ReadLine();
            /*
            while (t != null)
            {
                
                if (t.Substring(0, 2) == "01")
                {
                    sw.WriteLine("stok kodu " + t.Substring(5, 24));
                    sw.WriteLine("eski stok kodu " + t.Substring(29, 24));
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
                    sw.WriteLine("İkinci birim kodu " + t.Substring(313, 8));
                    sw.WriteLine("üçüncü birim kodu " + t.Substring(321, 8));

                    sw.WriteLine("Birinci birimden ikinci birime geçiş katsayısı " + t.Substring(329, 12));
                    sw.WriteLine("Birinci birimden üçüncü birime geçiş katsayısı " + t.Substring(341, 12));
                    sw.WriteLine("Birinci birimden ikinci birime geçiş katsayısı çarpar (1)/böler (0) flag " + t.Substring(353, 1));
                    sw.WriteLine("Birinci birimden üçüncü birime geçiş katsayısı çarpar (1)/böler (0) flag " + t.Substring(354, 1));

                    sw.WriteLine("Satış fiyatı 1 " + t.Substring(355, 15));
                    sw.WriteLine("Satış fiyatı 2 " + t.Substring(370, 15));
                    sw.WriteLine("Satış fiyatı 3 " + t.Substring(385, 15));
                    sw.WriteLine("Satış fiyatı 4 " + t.Substring(400, 15));
                    sw.WriteLine("Satış fiyatı 5 " + t.Substring(415, 15));
                    sw.WriteLine("Alış fiyatı 1 " + t.Substring(430, 15));
                    sw.WriteLine("Alış fiyatı 2 " + t.Substring(445, 15));
                    sw.WriteLine("Alış fiyatı 3 " + t.Substring(460, 15));
                    sw.WriteLine("Alış fiyatı 4 " + t.Substring(475, 15));
                    sw.WriteLine("Alış fiyatı 5 " + t.Substring(490, 15));

                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 1. (Ödeme türü olarak girilen bilgilerin hangisinin seçildiği) " + t.Substring(505, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 2. " + t.Substring(507, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 3. " + t.Substring(509, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 4. " + t.Substring(511, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 5. " + t.Substring(513, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 1. " + t.Substring(515, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 2. " + t.Substring(517, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 3. " + t.Substring(519, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 4. " + t.Substring(521, 2));
                    sw.WriteLine("0-39 fiyatın indexi(TL-4-v.s.) 5. " + t.Substring(523, 2));

                    sw.WriteLine("KDV'ler fiyatlara dahil (1)/hariç (0) bit flagleri (1-5 satış fiyatlarına,6-10 alış fiyatlarına) Örnek:Tüm fiyatların KDV dahil olması için (alış ve satış) 1023 olarak gönderilmeli " + t.Substring(525, 6));



                    sw.WriteLine("Satış KDV grup numarası (0’dan başlar. Max 9) KDV yüzdesi (%0,%1,%8..) değildir. " + t.Substring(531, 3));
                    sw.WriteLine("Alış KDV grup numarası (0’dan başlar) " + t.Substring(534, 3));
                    sw.WriteLine("KDV Kullanım şekli  " + t.Substring(537, 1));

                    sw.WriteLine("İzin verilen min. satış adedi, 0: Kontrol etme  " + t.Substring(538, 15));
                    sw.WriteLine("İzin verilen max. satış adedi, 0: Kontrol etme  " + t.Substring(553, 15));
                    sw.WriteLine("Kasiyerin yapabileceği max. indirim yüzdesi  " + t.Substring(568, 3));
                    sw.WriteLine("Kasiyerin yapabileceği max. indirim (TL)  " + t.Substring(571, 15));


                    sw.WriteLine("Satış durumu   " + t.Substring(586, 1));
                    sw.WriteLine("Adetli satış durumu  " + t.Substring(587, 1));
                    sw.WriteLine("Fiyatlı satış durumu,   " + t.Substring(588, 1));
                    sw.WriteLine("İade edilebilirlik,   " + t.Substring(589, 1));

                    sw.WriteLine("Satıcı girişi,  " + t.Substring(590, 1));
                    sw.WriteLine("Kod ile satış,   " + t.Substring(591, 1));
                    sw.WriteLine("İndirimli satış,   " + t.Substring(592, 1));
                    sw.WriteLine("Ürün siparişi verilebilir,   " + t.Substring(593, 1));

                    sw.WriteLine("Teminci Kodu,   " + t.Substring(594, 20));



                    sw.WriteLine("Kredi Şablonu (Taksitli Satış şablonu),   " + t.Substring(614, 6));
                    sw.WriteLine("Kaç gün içinde temin edilebildiği,   " + t.Substring(620, 15));
                    sw.WriteLine("Sipariş katsayısı, ortalama sipariş sayısına oranı,   " + t.Substring(635, 6));
                    sw.WriteLine("Depo sipariş seviyesi   " + t.Substring(641, 15));
                    sw.WriteLine("Depo kritik seviyesi   " + t.Substring(656, 15));
                    sw.WriteLine("Depo maksimum seviyesi   " + t.Substring(671, 15));
                    sw.WriteLine("Terazi Durumu   " + t.Substring(686, 1));
                    sw.WriteLine("Katsayı1   " + t.Substring(687, 15));
                    sw.WriteLine("Katsayı2   " + t.Substring(702, 15));
                    sw.WriteLine("Katsayı3   " + t.Substring(717, 15));
                    sw.WriteLine("Katsayı4   " + t.Substring(732, 15));
                    sw.WriteLine("Katsayı5   " + t.Substring(747, 15));
                    sw.WriteLine("Katsayı6   " + t.Substring(762, 15));
                    sw.WriteLine("Katsayı7   " + t.Substring(777, 15));
                    sw.WriteLine("Katsayı8   " + t.Substring(792, 15));

                    sw.WriteLine("Stok kartı puan bilgisi   " + t.Substring(807, 15));
                    sw.WriteLine("Üretim bilgisi. OR Flag.   " + t.Substring(822, 6));

                    sw.WriteLine("Etikete (Birim Fiyat/Birim) şeklinde yazilacak satirdaki birim fiyat (Örn:330 Cl Coke 250.000 TL ise birim lt ve birim fiyat 800.000 TL olacak)  " + t.Substring(828, 15));
                    sw.WriteLine("Etikete (Birim Fiyat/Birim) şeklinde yazilacak satirdaki birim         (Örn:330 Cl Coke 250.000 TL ise birim lt ve birim fiyat 800.000 TL olacak)  " + t.Substring(843, 5));

                }




                sw.WriteLine("-------------------------------------------------------------------------------------------------\n\n");
                 
                t = swRead.ReadLine();

            }
            * */

            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            //sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            //sw.Close();
            //fs.Close();
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
            stokAktar();
        }

        public void birinciSatir(STKKART item)
        {
            StringBuilder sb = new StringBuilder();
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

            sb.Append(satirNo + islemTuru + stkKodu + eskiStkKodu + stokAciklama + extraAciklama + posEkraniAciklama + rafEtiketiAciklama + teraziAciklama + stokBolumu + reyonTanimi + urunTipi + indirimGrubu + indirimDurumu + indirimYuzdesi + indirimTutari + reserved
                + bagliStokKodu);
            string birim = "0";//0 adet,1 ağırlık,2uzunluk,3litre

            string birimBoleni = "".boslukTamamla(15);//!=0
            string birimCarpani = "".boslukTamamla(15);//!=0
            string ikinciBirimKodu = item.STKBIRIM2.boslukTamamla(15);
            string ucuncuBirimKodu = item.STKBIRIM.boslukTamamla(15);
            string gecisKatSayisi1 = "".boslukTamamla(12);
            string gecisKatSayisi2 = "".boslukTamamla(12);
            string gecisKatSayisiCarpar1 = "".boslukTamamla(1);//1 çarpar,0 böler
            string gecisKatSayisiCarpar2 = "".boslukTamamla(1);

            sb.Append(birim + birimBoleni + birimCarpani + ikinciBirimKodu + ucuncuBirimKodu + gecisKatSayisi1 + gecisKatSayisi2 + gecisKatSayisiCarpar1 + gecisKatSayisiCarpar2);
            var satisFiyat=from d in db.STKFIYAT.Where(d=>d.STKFIYSTKKOD==item.STKKOD && d.STKFIYNO==1)
                           select new
                           {
                               d.STKFIYTUTAR,
                               d.STKFIYISKYUZ1
                           };
            string satisFiyatGelen = "";
            foreach (var itemFiyat in satisFiyat)
            {
                satisFiyatGelen = itemFiyat.STKFIYTUTAR.ToString();
            }
            string satisFiyati = satisFiyatGelen.boslukTamamla(1);
            string satisFiyati2 = "".boslukTamamla(1);
            string satisFiyati3 = "".boslukTamamla(1);
            string satisFiyati4 = "".boslukTamamla(1);
            string satisFiyati5 = "".boslukTamamla(1);
            string alisFiyati = "".boslukTamamla(1);
            string alisFiyati1 = "".boslukTamamla(1);
            string alisFiyati2 = "".boslukTamamla(1);
            string alisFiyati3 = "".boslukTamamla(1);
            string alisFiyati4 = "".boslukTamamla(1);
            string alisFiyati5 = "".boslukTamamla(1);
            sb.Append(satisFiyati + satisFiyati2 + satisFiyati3 + satisFiyati4 + satisFiyati5 + alisFiyati + alisFiyati1 + alisFiyati2 + alisFiyati3 + alisFiyati4 + alisFiyati5);
            string fiyatinIndexi = "".boslukTamamla(1);
            string fiyatinIndexi2 = "".boslukTamamla(1);
            string fiyatinIndexi3 = "".boslukTamamla(1);
            string fiyatinIndexi4 = "".boslukTamamla(1);
            string fiyatinIndexi5 = "".boslukTamamla(1);
            string fiyatinIndexi6 = "".boslukTamamla(1);
            string fiyatinIndexi7 = "".boslukTamamla(1);
            string fiyatinIndexi8 = "".boslukTamamla(1);
            string fiyatinIndexi9 = "".boslukTamamla(1);
            string fiyatinIndexi10 = "".boslukTamamla(1);
            sb.Append(fiyatinIndexi + fiyatinIndexi2 + fiyatinIndexi3 + fiyatinIndexi4 + fiyatinIndexi5 + fiyatinIndexi6 + fiyatinIndexi7 + fiyatinIndexi8 + fiyatinIndexi9 + fiyatinIndexi10);
            string kdvlerFiyataDahil = "".boslukTamamla(1);//haric (0) bit flagları (1-5 satış fiyatlarına ,6-10 alış fiyatlarına)
            string satisKdvGrupNo = item.STKGENKDVNO.boslukTamamla(1);
            string alisKdvGrupNo = "".boslukTamamla(1);
            string kdvKullanimSekli = "".boslukTamamla(1);//0 kendi kdvsi,1 bölüm kdvsi, 2 reyon kdvsi
            string izinVerMinSatAdedi = "".boslukTamamla(1);//0 kontrolEtme
            string izinVerMaxSatAdedi = "".boslukTamamla(1);//0 kontrolEtme
            string kasMaxIndYuzde = "".boslukTamamla(1);
            string kasMaxInd = "".boslukTamamla(1);
            string satisDurumu = "".boslukTamamla(1);//0.satılabilr,1:satış durduruldu
            string adetliSatisDurumu = "".boslukTamamla(1);
            string fiyatliSatisDurumu = "".boslukTamamla(1);
            sb.Append(kdvlerFiyataDahil + satisKdvGrupNo + alisKdvGrupNo + kdvKullanimSekli + izinVerMinSatAdedi + izinVerMaxSatAdedi + kasMaxIndYuzde + kasMaxInd + satisDurumu + adetliSatisDurumu + fiyatliSatisDurumu);
            string iadeEdilebilirlik = "".boslukTamamla(1);
            string saticiGirisi = "".boslukTamamla(1);
            string kodlaSatis = "".boslukTamamla(1);
            string indirimliSatis = "".boslukTamamla(1);
            string siparisVerilebilir = "".boslukTamamla(1);
            string teminciKodu = "".boslukTamamla(1);
            string krediSablonu = "".boslukTamamla(1);
            string teminGunSayisi = "".boslukTamamla(1);
            string siparisKatSayisi = "".boslukTamamla(1);
            string depoSiparis = "".boslukTamamla(1);
            string depoKritik = "".boslukTamamla(1);
            string depoMaxSeviye = "".boslukTamamla(1);
            string terazi = "".boslukTamamla(1);
            string katSayi1 = "".boslukTamamla(1);
            string katSayi2 = "".boslukTamamla(1);
            string katSayi3 = "".boslukTamamla(1);
            string katSayi4 = "".boslukTamamla(1);
            string katSayi5 = "".boslukTamamla(1);
            string katSayi6 = "".boslukTamamla(1);
            string katSayi7 = "".boslukTamamla(1);
            string katSayi8 = "".boslukTamamla(1);
            string stokKartiPuan = "".boslukTamamla(1);
            string uretimBilgisi = "".boslukTamamla(1);
            string etiketeYazilacakFiyat = "".boslukTamamla(1);
            string etiketeFiyat = "".boslukTamamla(1);
            sb.Append(iadeEdilebilirlik + saticiGirisi + kodlaSatis + indirimliSatis + siparisVerilebilir + teminciKodu + krediSablonu + teminGunSayisi + siparisKatSayisi + depoSiparis + depoKritik + depoMaxSeviye + terazi + katSayi1 + katSayi2 + katSayi3 + katSayi4 + katSayi5 + katSayi6 + katSayi7 + katSayi8 + stokKartiPuan + uretimBilgisi + etiketeYazilacakFiyat + etiketeFiyat);
            Fonksiyon.dosyayaYaz(sb.ToString());
            var q = from D in db.STKBARKOD.Where(d => d.STKBARSTKKOD == item.STKKOD)
                    select new
                    {
                        D.STKBARKOD1,
                        D.STKBARSTKKOD,
                        D.STKBARBRMNO,
                        D.STKBARTIP
                    };
            int sirano = 0;
            foreach (var item2 in q)
            {
                sirano++;
                STKBARKOD sbr = new STKBARKOD();
                sbr.STKBARKOD1 = item2.STKBARKOD1;
                sbr.STKBARSTKKOD = item2.STKBARSTKKOD;
                sbr.STKBARBRMNO = item2.STKBARBRMNO;
                sbr.STKBARTIP = item2.STKBARTIP;
                ikinciSatir(sbr, sirano);
            }
        }

        public void ikinciSatir(STKBARKOD stk, int sirano)
        {
            string satirKodu = "02".boslukTamamla(4);
            string islemTuru = "1".boslukTamamla(1);
            string iliskiliStkKodu = stk.STKBARSTKKOD.boslukTamamla(24);
            string barkodu = stk.STKBARKOD1.boslukTamamla(24);
            string eskiBarkodu = stk.STKBARKOD1.boslukTamamla(24);
            string birimMiktar = "".boslukTamamla(6);
            string barkodTipi = stk.STKBARTIP.boslukTamamla(1);
            string fiyatBilgisi = "0".boslukTamamla(1);
            string siraNo = sirano.ToString().boslukTamamla(2);
            string barkodFiyati = "".boslukTamamla(15);
            StringBuilder sb = new StringBuilder();
            sb.Append(satirKodu + islemTuru + iliskiliStkKodu + barkodu + eskiBarkodu + birimMiktar + barkodTipi + fiyatBilgisi + sirano + barkodFiyati);
            Fonksiyon.dosyayaYaz(sb.ToString());

        }
        public void stokAktar()
        {
            var stklar = from C in db.STKKART.Take(10)
                         select new
                         {
                             C.STKBIRIM,
                             C.STKBIRIM2,
                             C.STKBIRIM3,
                             C.STKKOD,
                             C.STKCINSI,
                             C.STKCINSI2,
                             C.STKCINSI3
                         };

            STKKART stk = new STKKART();

            foreach (var item in stklar)
            {
                stk.STKBIRIM = item.STKBIRIM;
                stk.STKBIRIM2 = item.STKBIRIM2;
                stk.STKBIRIM3 = item.STKBIRIM3;
                stk.STKKOD = item.STKKOD;
                stk.STKCINSI = item.STKCINSI;
                stk.STKCINSI2 = item.STKCINSI2;
                stk.STKCINSI3 = item.STKCINSI3;
                birinciSatir(stk);

            }
        }

    }
    public static class bosluk
    {
        public static string boslukTamamla(this object o, int uzunluk)
        {
            string str = o.ToString();
            if (str.Length > uzunluk)
            {
                str = str.Substring(0, uzunluk);
            }
            while (str.Length < uzunluk)
            {
                str += " ";
            }
            return str;
        }
    }
}
