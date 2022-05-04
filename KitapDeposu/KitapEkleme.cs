using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KitapDeposu
{
    public partial class KitapEkleme : Form
    {
        public KitapEkleme()
        {
            InitializeComponent();
        }

        private void KitapEkleme_Load(object sender, EventArgs e)
        {

        }
        ErrorProvider EP = new ErrorProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrEmpty(textBox1.Text))
                {

                    MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    MSConnection.Open();

                    MySqlCommand MSC = new MySqlCommand("INSERT INTO kitaplar(Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok,Kitap_Bilgi,Kitap_Fiyat) VALUES (@KitapAdı,@KitapSayfa,@KitapYazarı,@KitapStok,@KitapBilgi,@KitapFiyat)", MSConnection);

                    MSC.Parameters.AddWithValue("KitapAdı", textBox3.Text);
                    MSC.Parameters.AddWithValue("KitapSayfa", textBox1.Text);
                    MSC.Parameters.AddWithValue("KitapYazarı", textBox2.Text);
                    MSC.Parameters.AddWithValue("KitapStok", numericUpDown1.Value);
                    MSC.Parameters.AddWithValue("KitapBilgi", richTextBox1.Text);
                    MSC.Parameters.AddWithValue("KitapFiyat", textBox4.Text);
                    MSC.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Gerekli Bilgilerin Hepsini Doldurduğunuzdan Emin Olun!");
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < textBox1.Text.Count(); i++)
                {
                    if (!char.IsDigit(textBox1.Text[i]))
                    {
                        EP.SetError(textBox1, "Sadece Sayı Girişi Yapılabilir!");
                        button1.Enabled = false;
                    }
                    else
                    {
                        button1.Enabled = true;
                    }
                }
            }
            catch (Exception eg)
            {

                MessageBox.Show(eg.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < textBox4.Text.Count(); i++)
                {
                    if (!char.IsDigit(textBox4.Text[i]))
                    {
                        EP.SetError(textBox4, "Sadece Sayı Girişi Yapılabilir!");
                        button1.Enabled = false;
                    }
                    else
                    {
                        button1.Enabled = true;
                    }
                }
            }
            catch (Exception eg)
            {

                MessageBox.Show(eg.Message);
            }
        }
    }
}
