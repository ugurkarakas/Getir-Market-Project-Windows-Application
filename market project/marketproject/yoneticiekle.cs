using _BusinessLayer;
using _DataLayer;
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
    public partial class yoneticiekle : Form
    {
        public yoneticiekle()
        {
            InitializeComponent();
        }
        GovernanceBusiness gb = new GovernanceBusiness();
        private void btnurun_Click(object sender, EventArgs e)
        {
            Governance p = new Governance
            {
                FirstName = txtad.Text,
                LastName = txtsoyad.Text,
                Gender = lst1.Text,
                UserName = txtusername.Text,
                UserPassword = txtpassword.Text,
            };
            gb.Create(p);
            MessageBox.Show("Kayıt Başarıyla Tamamlandı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            yoneticidetay yonetim = new yoneticidetay();
            yonetim.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yoneticidetay yonetim = new yoneticidetay();
            yonetim.Show();
            this.Hide();
        }
    }
}
