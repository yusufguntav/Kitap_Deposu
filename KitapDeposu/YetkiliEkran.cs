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
    public partial class YetkiliEkran : Form
    {
        public YetkiliEkran()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapEkleme KE = new KitapEkleme();
            KE.ShowDialog();

        }

        private void YetkiliEkran_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "Kitap Adı";
                dataGridView1.Columns[1].Name = "Yazarın Adı";
                dataGridView1.Columns[2].Name = "Sayfa Sayısı";
                dataGridView1.Columns[3].Name = "Fiyat";
                dataGridView1.Columns[4].Name = "Stok Durumu";
                dataGridView1.Columns[5].Name = "Bilgi Metni";

                MySqlConnection MSConnection = new MySqlConnection("server=localhost;user id=root;database=kitap_deposu");
                MSConnection.Open();

                MySqlCommand Command = new MySqlCommand("SELECT Kitap_Adı, Kitap_Sayfa, Kitap_Yazarı, Kitap_Stok, Kitap_Bilgi,Kitap_Fiyat FROM kitaplar", MSConnection);
                var kitap = Command.ExecuteReader();
                while (kitap.Read())
                {
                    dataGridView1.Rows.Add(kitap[0], kitap[2], kitap[1], kitap[5], kitap[3], kitap[4]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KitapDüzenleme KD = new KitapDüzenleme();
            KD.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris grs = new Giris();
            this.Hide();
            grs.ShowDialog();
            this.Close();
        }
    }
}
