using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapDeposu
{
    class KitapEkle
    {
        public KitapEkle(string Kitap_Adi, string Kitap_Sayfa_Sayisi, string Kitap_Yazari, string Kitap_Bilgi_Metni,int Kitap_Stok,FlowLayoutPanel FLP)
        {
            int x = 0;
            int y = 0;
            //Panel
            Panel pnl = new Panel();
            pnl.Size = new Size(200, 500);
            FLP.Controls.Add(pnl);
            // Kitap Adı
            Label LBL = new Label();
            LBL.MinimumSize = new Size(200, 200);
            LBL.Location = new Point(x, y);
            LBL.Font = new Font("Arial",15);
            LBL.TextAlign = ContentAlignment.MiddleCenter;
            LBL.BackColor = Color.Red;
            LBL.Text = Kitap_Adi;
            LBL.Name = "KitapAdi:"+Kitap_Adi+Kitap_Yazari;
            pnl.Controls.Add(LBL);
            // Bilgilendirici Metin
            Label LBL_Metin = new Label();
            LBL_Metin.Size = new Size(200, 100);
            LBL_Metin.Location = new Point(x, y + 210);
            LBL_Metin.Text = "Kitap Adı: "+Kitap_Adi+"\n"+"Kitap Yazarı: "+Kitap_Yazari+"\n"+"Kitap Sayfası: "+Kitap_Sayfa_Sayisi+ "\n"+"Kitap Stok: "+Kitap_Stok+"\n" + Kitap_Bilgi_Metni;
            LBL_Metin.Name = "BilgilendiriciMetin:"+ Kitap_Adi + Kitap_Yazari;
            pnl.Controls.Add(LBL_Metin);
            // Ekle Buton
            Button btn = new Button();
            btn.Size = new Size(130, 50);
            btn.BackColor = Color.Red;
            btn.Name = "Buton"+ Kitap_Adi + Kitap_Yazari;
            btn.Text = "Sepete Ekle";
            btn.Location = new Point(x, y + 320);
            pnl.Controls.Add(btn);
            // Ekle NumericUpDown
            NumericUpDown NUD = new NumericUpDown();
            NUD.Size = new Size(60, 60);
            NUD.Name = "NumericUpDown"+ Kitap_Adi + Kitap_Yazari;
            NUD.Maximum = Kitap_Stok;
            NUD.Location = new Point(x + 140, y + 320 + (NUD.Size.Height / 2));
            pnl.Controls.Add(NUD);
        }
    }
}
