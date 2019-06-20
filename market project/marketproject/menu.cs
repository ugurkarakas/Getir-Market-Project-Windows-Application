using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketproject
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }
        private int İmageNumber = 1;
        private void LoadNextİmage()
        {
            if (İmageNumber == 6)
            {
                İmageNumber = 1;
            }
            pictureBox2.ImageLocation = string.Format(@"images\{0}.jpg", İmageNumber);
            İmageNumber++;
            //Slayt Kodu
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextİmage();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            giris kullanicigiris = new giris();
            kullanicigiris.Show();
            this.Hide();
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            kayit kayityap = new kayit();
            kayityap.Show();
            this.Hide();
        }

        private void btnbasvuru_Click(object sender, EventArgs e)
        {
            personelkayit kayityap = new personelkayit();
            kayityap.Show();
            this.Hide();
        }

        private void btnpgiris_Click(object sender, EventArgs e)
        {
            personelgiris pgirisyap = new personelgiris();
            pgirisyap.Show();
            this.Hide();
        }
    }
}
