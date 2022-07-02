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
    public partial class Sepet : Form
    {
        public Sepet()
        {
            InitializeComponent();
        }


        public void SepetKitapEkle(string KitapAdı)
        {
            listBox1.Items.Add(KitapAdı);
       
        }
        public List<string> SepetEkle = new List<string>();
        private void Sepet_Load(object sender, EventArgs e)
        {
            foreach (var item in SepetEkle)
            {
                MessageBox.Show(item);
            }
        }
    }
}
