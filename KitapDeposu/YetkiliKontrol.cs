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
    public partial class YetkiliKontrol : Form
    {
        public YetkiliKontrol()
        {
            InitializeComponent();
        }

        string Sifre;
        ErrorProvider EP = new ErrorProvider();
        private void YetkiliKontrol_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                connection.Open();

                MySqlCommand Command = new MySqlCommand("SELECT `sifre` FROM `admin_sifre`", connection);
                var sifre = Command.ExecuteReader();
                sifre.Read();
                Sifre = sifre[0].ToString();
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
                if (Sifre == textBox1.Text)
                {
                    YetkiliEkran YE = new YetkiliEkran();
                    this.Hide();
                    YE.ShowDialog();
                    this.Close();
                }
                else
                {
                    EP.SetError(textBox1, "Şifre Yanlış");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
