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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
            MSConnection.Open();

            MySqlCommand MSC = new MySqlCommand("INSERT INTO kitaplar(Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok,Kitap_Bilgi) VALUES (@KitapAdı,@KitapSayfa,@KitapYazarı,@KitapStok,@KitapBilgi)", MSConnection);

            MSC.Parameters.AddWithValue("KitapAdı",textBox3.Text);
            MSC.Parameters.AddWithValue("KitapSayfa",textBox1.Text);
            MSC.Parameters.AddWithValue("KitapYazarı",textBox2.Text);
            MSC.Parameters.AddWithValue("KitapStok",numericUpDown1.Value);
            MSC.Parameters.AddWithValue("KitapBilgi",richTextBox1.Text);
            MSC.ExecuteNonQuery();
            

        }
    }
}
