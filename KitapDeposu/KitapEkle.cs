using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapDeposu
{
    class KitapEkle
    {
        string Kitap_Adı;
        string Kitap_Yazar;
        int Alım_Adet;

        public KitapEkle(string Kitap_Adi, string Kitap_Sayfa_Sayisi, string Kitap_Yazari, string Kitap_Bilgi_Metni, int Kitap_Stok, FlowLayoutPanel FLP, int Kitap_Fiyat)
        {
            Kitap_Adı = Kitap_Adi;
            Kitap_Yazar = Kitap_Yazari;

            int x = 0;
            int y = 0;
            //Panel
            Panel pnl = new Panel();
            pnl.Name = Kitap_Adi + Kitap_Yazari;
            pnl.Size = new Size(200, 500);
            FLP.Controls.Add(pnl);
            // Kitap Adı
            Label LBL = new Label();
            LBL.MinimumSize = new Size(200, 200);
            LBL.Location = new Point(x, y);
            LBL.Font = new Font("Arial", 15);
            LBL.TextAlign = ContentAlignment.MiddleCenter;
            LBL.BackColor = Color.Red;
            LBL.Text = Kitap_Adi;
            LBL.Name = "KitapAdi:" + Kitap_Adi + Kitap_Yazari;
            pnl.Controls.Add(LBL);
            // Bilgilendirici Metin
            RichTextBox RTB = new RichTextBox();
            RTB.Size = new Size(200, 100);
            RTB.ReadOnly = true;
            RTB.Location = new Point(x, y + 210);
            RTB.Text = "Kitap Adı: " + Kitap_Adi + "\n" + "Kitap Yazarı: " + Kitap_Yazari + "\n" + "Kitap Sayfası: " + Kitap_Sayfa_Sayisi + "\n" + "Kitap Stok: " + Kitap_Stok + "\nKitap Fiyatı: " + Kitap_Fiyat + "\n" + Kitap_Bilgi_Metni;
            RTB.Name = "BilgilendiriciMetin:" + Kitap_Adi + Kitap_Yazari;
            pnl.Controls.Add(RTB);
            // Ekle Buton
            Button btn = new Button();
            btn.Size = new Size(130, 50);
            btn.BackColor = Color.Red;
            btn.Name = "Buton" + Kitap_Adi + Kitap_Yazari;
            btn.Text = "Sepete Ekle";
            btn.Click += Btn_Click;
            btn.Location = new Point(x, y + 320);
            pnl.Controls.Add(btn);
            // Ekle NumericUpDown
            NumericUpDown NUD = new NumericUpDown();
            NUD.Size = new Size(60, 60);
            NUD.ReadOnly = true;
            NUD.ValueChanged += NUD_ValueChanged;
            NUD.Name = "NumericUpDown" + Kitap_Adi + Kitap_Yazari;
            NUD.Maximum = Kitap_Stok;
            NUD.Location = new Point(x + 140, y + 320 + (NUD.Size.Height / 2));
            pnl.Controls.Add(NUD);
        }

        private void NUD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Alım_Adet = Convert.ToInt32(((NumericUpDown)sender).Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (Alım_Adet != 0)
                {
                    string kitap_adlari = "";
                    SatisEkran SE = (SatisEkran)Application.OpenForms["SatisEkran"];

                    for (int i = 0; i < SE.listBox1.Items.Count; i++)
                    {
                        string[] kitap_bilgi = SE.listBox1.Items[i].ToString().Split('-');
                        kitap_adlari += " " + kitap_bilgi[0].ToString();
                    }
                    if (!kitap_adlari.Contains(Kitap_Adı))
                    {
                        SE.SepetEkle(Kitap_Adı, Alım_Adet, Kitap_Yazar);
                    }
                    else
                    {
                        for (int i = 0; i < SE.listBox1.Items.Count; i++)
                        {
                            if (Alım_Adet != 0)
                            {
                                string[] kitap_bilgi = SE.listBox1.Items[i].ToString().Split('-');
                                if (Kitap_Adı == kitap_bilgi[0])
                                {
                                    SE.listBox1.Items[i] = Kitap_Adı + "-" + Kitap_Yazar + "-" + Alım_Adet;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Sepete ekleme başarısız😥");
            }





        }
    }
}
