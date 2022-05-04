using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapDeposu
{
    public partial class SatisEkran : Form
    {
        public SatisEkran()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void SepetEkle(string kitapadı, int adet, string yazar)
        {
            listBox1.Items.Add(kitapadı + "-" + yazar + "-" + adet);
        }

        private void SatisEkran_Load(object sender, EventArgs e)
        {

            try
            {
               
                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                MSConnection.Open();

                MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi,Kitap_Fiyat FROM kitaplar", MSConnection);
                var kitap = Command.ExecuteReader();
                while (kitap.Read())
                {
                    KitapEkle KE = new KitapEkle(kitap[0].ToString(), kitap[1].ToString(), kitap[2].ToString(), kitap[4].ToString(), Convert.ToInt32(kitap[3]), flowLayoutPanel1, Convert.ToInt32(kitap[5]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    flowLayoutPanel1.Controls.Clear();
                    MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    MSConnection.Open();

                    MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi,Kitap_Fiyat FROM kitaplar", MSConnection);
                    var kitap = Command.ExecuteReader();
                    while (kitap.Read())
                    {
                        KitapEkle KE = new KitapEkle(kitap[0].ToString(), kitap[1].ToString(), kitap[2].ToString(), kitap[4].ToString(), Convert.ToInt32(kitap[3]), flowLayoutPanel1, Convert.ToInt32(kitap[5]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    MSConnection.Open();

                    MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi,Kitap_Fiyat FROM kitaplar WHERE Kitap_Adı LIKE'%" + textBox1.Text + "%'", MSConnection);
                    var kitap = Command.ExecuteReader();
                    kitap.Read();

                    flowLayoutPanel1.Controls.Clear();
                    KitapEkle KE = new KitapEkle(kitap[0].ToString(), kitap[1].ToString(), kitap[2].ToString(), kitap[4].ToString(), Convert.ToInt32(kitap[3]), flowLayoutPanel1, Convert.ToInt32(kitap[5]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Kitap Bulunmuyor 😥");
                }
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        string[] kitap = listBox1.Items[i].ToString().Split('-');

                        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                        connection.Open();
                        // Stok Durumuna Bakma
                        MySqlCommand Command = new MySqlCommand("SELECT  Kitap_Stok FROM kitaplar WHERE Kitap_Adı ='" + kitap[0] +
                            "' and Kitap_Yazarı='" + kitap[1] + "'", connection);
                        var stok = Command.ExecuteReader();
                        stok.Read();
                        int Stok = Convert.ToInt32(stok[0]);
                        connection.Close();


                        // UPDATE
                        connection.Open();
                        Command = new MySqlCommand("UPDATE kitaplar SET Kitap_Stok=" + (Stok - Convert.ToInt32(kitap[2])) + " WHERE Kitap_Adı ='" + kitap[0] +
                            "' and Kitap_Yazarı='" + kitap[1] + "'", connection);
                        Command.ExecuteNonQuery();
                    }
                    listBox1.Items.Clear();
                    MessageBox.Show("Siparişiniz Alındı😊 İlgili Çalışanımız Birazdan Siparişinizi Getirecek😊");
                    this.Close();

                }else if(listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Lütfen Sepete Ürün Ekleyin");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Giris grs = new Giris();
            this.Hide();
            grs.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
