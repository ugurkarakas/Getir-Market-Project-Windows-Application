using _BusinessLayer;
using _DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketproject
{
    public partial class yonetimgiris : Form
    {
        public yonetimgiris()
        {
            InitializeComponent();
        }
        GovernanceBusiness sb = new GovernanceBusiness();
        private MarketEntities me = new MarketEntities();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");

        private void btngiris1_Click(object sender, EventArgs e)
        {
            //var staff = login(txtuser.Text, txtpassword.Text);
            //if (staff == null)
            //{
            //    MessageBox.Show("Şifre Yanlış");
            //}
            //else
            //{
            //    MessageBox.Show("Giriş Başarılı");
            //    personelmenu yonetim = new personelmenu();
            //    yonetim.Show();
            //    this.Hide();

            //}
            baglanti.Open(); SqlCommand komut = new SqlCommand("select * from Governance where UserName='" + txtuser.Text + "'and UserPassword='" + txtpassword.Text + "'", baglanti); SqlDataReader dr = komut.ExecuteReader();
            if (txtuser.Text == "" || txtpassword.Text == "") { MessageBox.Show("Boş Alan Bırakılamaz !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dr.Read()) { yonetimenu menu = new yonetimenu(); menu.Show(); this.Hide(); }
            else { txtuser.Clear(); txtpassword.Clear(); MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            baglanti.Close();
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            personelgiris personelgeri = new personelgiris();
            personelgeri.Show();
            this.Hide();
        }
    }
}
