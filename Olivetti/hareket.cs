using System.Collections.Generic;

namespace Olivetti
{
    class hareket
    {
        public string tarih { get; set; }
        public string fisKodu { get; set; }
        public string saat { get; set; }
        public string magazaNo { get; set; }
        public string belgeTipi { get; set; }
        public string belgeDurumu { get; set; }
        public string genelToplam { get; set; }
        public string kdvToplam { get; set; }
        public string toplamIndirim { get; set; }
        public string satirlarToplamIndirim { get; set; }
        public string otomatikIndirim { get; set; }
        public string cariIndirim { get; set; }
        public string promosyonIndirim { get; set; }
        public string yuvarlama { get; set; }
        public string musteriNo { get; set; }
        public string taksitliSatis { get; set; }
        public List<stokHareket> lstStokHareket { get; set; }
        public hareket()
        {
            lstStokHareket = new List<stokHareket>();
        }
    }
    class stokHareket
    {
        public string stokKodu { get; set; }
        public string hareketTip { get; set; }
        public string saticiKodu { get; set; }
        public string KDVReferans { get; set; }
        public byte KDVYuzde { get; set; }
        public string miktar { get; set; }
        public string birim { get; set; }
        public string birimFiyat { get; set; }
        public string toplamFiyat { get; set; }
        public string toplamKDV { get; set; }
        public string toplamIndirim { get; set; }
        public string kasiyerIndirim { get; set; }
        public string otomatikIndirim { get; set; }
        public string musteriIndirimi { get; set; }
        public string promosyonIndirimi { get; set; }
        public string satisDurumu { get; set; }
        public string barkodSatis { get; set; }
        public string odemeTipiReferansi { get; set; }
        public string fiyatDurumu { get; set; }
        public string anahtarKullanimi { get; set; }
        public string satisTipi { get; set; }

    }
}
