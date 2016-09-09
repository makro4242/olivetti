using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Olivetti
{
    class Fonksiyon
    {
        //PROJE CLASSES

        public StreamReader dosyaOkuyucu(string dosyaYolu)
        {
            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            return sw;
        }


        public static void dosyayaYaz(string metin, string dosya_yolu)
        {

            if (!File.Exists(dosya_yolu))
            {
                FileStream fs = File.Create(dosya_yolu);
                fs.Close();
            }
            StreamWriter sw = new StreamWriter(dosya_yolu, true);
            sw.WriteLine(metin);
            sw.Flush();
            sw.Close();
        }
        public static void kasaDoldur(ListBox lstKasalar)
        {
            if (Properties.Settings.Default.Kasalar != null)
            {
                foreach (string item in Properties.Settings.Default.Kasalar)
                {
                    lstKasalar.Items.Add("Kasa " + item.Split('*')[0]);
                }
            }
        }
        public void txtleritemizle(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (item is TextBox || item is ButtonEdit)
                {
                    item.Text = "";
                }
            }

        }

        public bool Connect(string server, string db, string user, string pass)
        {
            bool kontrol = true;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=" + server + ";initial Catalog=" + db + ";User Id=" + user + ";Password=" + pass;
            try
            {
                baglanti.Open();
            }
            catch (Exception)
            {
                kontrol = false;
            }
            finally
            {
                baglanti.Close();
            }
            return kontrol;

        }


        public SqlConnection baglan()
        {

            SqlConnection baglanti = new SqlConnection("Data Source=THINKPAD,1433; Initial Catalog=Nakliye; User Id=sa; Password=sapass");
            //TextReader txtDosya = File.OpenText("D:\\Sehasoft\\V10\\SehasoftBaglanti.txt");
            //string conString = txtDosya.ReadLine();
            //SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            return (baglanti);
        }

        public int cmd(string Sqlcumle)
        {
            SqlConnection baglan = this.baglan();
            SqlCommand sorgu = new SqlCommand(Sqlcumle, baglan);
            int sonuc = 0;

            try
            {
                sonuc = sorgu.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // MessageBox.Show(ex.Message + "(" + Sqlcumle + ")");
                throw new Exception(ex.Message + "(" + Sqlcumle + ")");
            }
            sorgu.Dispose();
            baglan.Close();
            baglan.Dispose();
            return (sonuc);
        }

        public DataTable GetDataTable(string Sql)//
        {
            SqlConnection baglanti = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, baglanti);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                // MessageBox.Show(ex.Message + "(" + Sql + ")");
                throw new Exception(ex.Message + "(" + Sql + ")");
            }
            adapter.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return dt;
        }
        public DataRow GetDataRow(string Sql)
        {
            DataTable table = GetDataTable(Sql);
            if (table.Rows.Count == 0) return null;
            return table.Rows[0];
        }

        public string GetDataCell(string Sql)
        {
            DataTable table = GetDataTable(Sql);
            if (table.Rows.Count == 0) return null;
            return table.Rows[0][0].ToString();
        }
        public DataSet GetDataSet(string Sql)//
        {
            SqlConnection baglanti = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, baglanti);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                // MessageBox.Show(ex.Message + "(" + Sql + ")");
                throw new Exception(ex.Message + "(" + Sql + ")");

            }
            adapter.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return ds;
        }
        public string yaziyaCevir(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TL ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";
            else
                yazi += "SIFIR Kr.";

            return yazi;
        }
        //kontrollerimiz
        public string Temizle(string Metin)
        {
            string deger = Metin;

            deger = deger.Replace("'", "''");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("SELECT", "");
            deger = deger.Replace("DELETE", "");
            deger = deger.Replace("INSERT", "");
            deger = deger.Replace("select", "");
            deger = deger.Replace("delete", "");
            deger = deger.Replace("insert", "");

            return deger;
        }

        public string tirnakDuzelt(string Metin)
        {
            string deger = Metin;
            deger = deger.Replace("'", "''");
            return deger;
        }

        public string urlSeo(string Metin)
        {
            string deger = Metin;

            deger = deger.Replace("'", "");
            deger = deger.Replace(" ", "-");
            deger = deger.Replace(".", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("ı", "i");
            deger = deger.Replace("ö", "o");
            deger = deger.Replace("ü", "u");
            deger = deger.Replace("ş", "s");
            deger = deger.Replace("ç", "c");
            deger = deger.Replace("ğ", "g");
            deger = deger.Replace("İ", "i");
            deger = deger.Replace("Ö", "o");
            deger = deger.Replace("Ü", "u");
            deger = deger.Replace("Ş", "s");
            deger = deger.Replace("Ç", "c");
            deger = deger.Replace("Ğ", "g");
            deger = deger.Replace("?", "");

            return deger;
        }

        public string dosyaAdiDuzelt(string Metin)
        {
            string deger = Metin;

            deger = deger.Replace("'", "");
            deger = deger.Replace(" ", "-");
            deger = deger.Replace(">", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("ı", "i");
            deger = deger.Replace("ö", "o");
            deger = deger.Replace("ü", "u");
            deger = deger.Replace("ş", "s");
            deger = deger.Replace("ç", "c");
            deger = deger.Replace("ğ", "g");
            deger = deger.Replace("İ", "I");
            deger = deger.Replace("Ö", "O");
            deger = deger.Replace("Ü", "U");
            deger = deger.Replace("Ş", "S");
            deger = deger.Replace("Ç", "C");
            deger = deger.Replace("Ğ", "G");

            return deger;
        }


        public string tarihTemizle(string Metin)
        {
            string deger = Metin;

            deger = deger.Replace(".", "");
            deger = deger.Replace("-", "");
            deger = deger.Replace(":", "");
            deger = deger.Replace(" ", "");
            deger = deger.Replace("ı", "i");
            deger = deger.Replace("ö", "o");
            deger = deger.Replace("ü", "u");
            deger = deger.Replace("ş", "s");
            deger = deger.Replace("ç", "c");
            deger = deger.Replace("ğ", "g");
            deger = deger.Replace("İ", "i");
            deger = deger.Replace("Ö", "o");
            deger = deger.Replace("Ü", "u");
            deger = deger.Replace("Ş", "s");
            deger = deger.Replace("Ç", "c");
            deger = deger.Replace("Ğ", "g");

            return deger;
        }




        //DATAREADER ÖRNEĞİ
        //public void btnDataReader()
        //{
        //    SqlConnection con = new SqlConnection(baglan);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "SELECT Adi FROM Kisiler";
        //    con.Open();

        //    SqlDataReader dr = cmd.ExecuteReader();

        //    ArrayList Isimler = new ArrayList();

        //    while (dr.Read())
        //    {
        //        Isimler.Add(dr["Adi"]);
        //    }

        //    dr.Close();
        //    con.Close();
        //}  

    }
}
