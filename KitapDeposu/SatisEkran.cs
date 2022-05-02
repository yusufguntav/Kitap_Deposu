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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void SatisEkran_Load(object sender, EventArgs e)
        {
            MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
            MSConnection.Open();

            MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi FROM kitaplar", MSConnection);
            var kitap = Command.ExecuteReader();
            kitap.Read();

            KitapEkle KE = new KitapEkle(kitap[0].ToString(), kitap[1].ToString(), kitap[2].ToString(), kitap[4].ToString(),Convert.ToInt32(kitap[3]),flowLayoutPanel1);
           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
