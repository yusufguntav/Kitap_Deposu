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
    public partial class KitapDüzenleme : Form
    {
        public KitapDüzenleme()
        {
            InitializeComponent();
        }

        private void KitapDüzenleme_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                MSConnection.Open();

                MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı FROM kitaplar", MSConnection);
                var kitap_adi = Command.ExecuteReader();
                while (kitap_adi.Read())
                {
                    comboBox1.Items.Add(kitap_adi[0]);
                }
                MSConnection.Close();

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
                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                MSConnection.Open();

                MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi,Kitap_Fiyat FROM kitaplar WHERE Kitap_Adı='" + comboBox1.SelectedItem + "'", MSConnection);
                var kitap_adi = Command.ExecuteReader();
                kitap_adi.Read();
                textBox4.Text = kitap_adi[5].ToString();
                textBox3.Text = kitap_adi[0].ToString();
                textBox2.Text = kitap_adi[2].ToString();
                textBox1.Text = kitap_adi[1].ToString();
                numericUpDown1.Value = Convert.ToInt32(kitap_adi[3]);
                richTextBox1.Text = kitap_adi[4].ToString();

                MSConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                MSConnection.Open();

                MySqlCommand Command = new MySqlCommand("UPDATE kitaplar SET Kitap_Adı='" + textBox3.Text + "',Kitap_Sayfa=" + textBox1.Text + ",Kitap_Yazarı='" + textBox2.Text + "',Kitap_Stok=" + numericUpDown1.Value + ",Kitap_Bilgi='" + richTextBox1.Text + "'," + "Kitap_Fiyat = " + textBox4.Text + "  WHERE Kitap_Adı='" + comboBox1.SelectedItem + "'", MSConnection);
                Command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
