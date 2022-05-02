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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Form(Satış Ekranı) açma
            this.Hide();
            SatisEkran SE= new SatisEkran();
            SE.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Form(Yetkili Ekranı) açma
            this.Hide();
            YetkiliEkran YE = new YetkiliEkran();
            YE.ShowDialog();
            this.Close();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
