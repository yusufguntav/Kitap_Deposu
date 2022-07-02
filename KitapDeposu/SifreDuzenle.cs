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
    public partial class SifreDuzenle : Form
    {
        public SifreDuzenle()
        {
            InitializeComponent();
        }

        ErrorProvider EP = new ErrorProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != textBox2.Text)
                {
                    EP.SetError(textBox2, "Şifreler Aynı Değil!");
                }
                else if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                {
                    EP.SetError(textBox1, "Şifre Kısmı Boş Geçilemez!");
                    EP.SetError(textBox2, "Şifre Kısmı Boş Geçilemez!");
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    EP.SetError(textBox1, "Şifre Kısmı Boş Geçilemez!");
                }
                else
                {
                    MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE `admin_sifre` SET `sifre`='" + textBox1.Text + "'", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Şifre Değiştirildi!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SifreDuzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
