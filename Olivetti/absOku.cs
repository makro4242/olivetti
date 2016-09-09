using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olivetti
{
    public abstract class absOku
    {
        public string yaz { get; set; }
        public string sirano { get; set; }
        public void ekle(int start, string text)
        {
            while (this.yaz.Length < start)
            {
                this.yaz += " ";
            }
            this.yaz += text;
        }
        public absOku()
        {
            this.yaz = "";
        }
    }
}
