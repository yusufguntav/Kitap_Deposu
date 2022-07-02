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
    public partial class AktifSiparisler : Form
    {
        public AktifSiparisler()
        {
            InitializeComponent();
        }

        private void SiparisNumaraAl()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            richTextBox1.Text = "";
            MySqlConnection Connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
            Connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT SiparisNumara FROM aktif_siparisler", Connection);
            var siparisler = command.ExecuteReader();
            while (siparisler.Read())
            {
                comboBox1.Items.Add(siparisler[0]);
            }
        }
        private void AktifSiparisler_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.ReadOnly = true;
                SiparisNumaraAl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                Connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Siparis FROM aktif_siparisler WHERE SiparisNumara=" + comboBox1.SelectedItem, Connection);
                var siparisler = command.ExecuteReader();
                siparisler.Read();
                richTextBox1.Text = siparisler[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sipariş Teslimi
            try
            {

                if (comboBox1.SelectedItem != null)
                {
                    MySqlConnection Connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM aktif_siparisler WHERE SiparisNumara=" + comboBox1.SelectedItem, Connection);
                    command.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Lütfen Sipariş Numarasını Seçiniz");
                }

                SiparisNumaraAl();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                // Sipariş İptali

                int satir_sayisi = richTextBox1.Lines.Count() - 1;
                for (int i = 0; i < satir_sayisi; i++)
                {
                    string[] siparis_bilgi = richTextBox1.Lines[i].Split('"');

                    MySqlConnection Connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    Connection.Open();

                    // Stok durumuna bakma
                    MySqlCommand Command = new MySqlCommand("SELECT  Kitap_Stok FROM kitaplar WHERE Kitap_Adi ='" + siparis_bilgi[1] + "' and Kitap_Yazari='" + siparis_bilgi[3] + "'", Connection);
                    var stok = Command.ExecuteReader();
                    stok.Read();
                    int Stok = Convert.ToInt32(stok[0]);
                    Connection.Close();

                    Connection.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE `kitaplar` SET `Kitap_Stok`=" + (Stok + Convert.ToInt32(siparis_bilgi[5])) + " WHERE Kitap_Adi ='" + siparis_bilgi[1] + "' and Kitap_Yazari='" + siparis_bilgi[3] + "'", Connection);
                    command.ExecuteNonQuery();
                    Connection.Close();

                }
                button1.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
