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
    public partial class personelgiris : Form
    {
        public personelgiris()
        {
            InitializeComponent();
        }
        StaffBusiness sb = new StaffBusiness();
        private MarketEntities me = new MarketEntities();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");

        //private Staff login(string uname, string password)
        //{
        //    var staff = me.Staffs.SingleOrDefault(a => a.Username.Equals(uname));
        //    if (staff != null)
        //    {
        //        if (BCrypt.Net.BCrypt.Verify(password, staff.UserPassword))
        //        {
        //            return staff;
        //        }
        //    }
        //    return null;
        //}
        private void blur1_Click(object sender, EventArgs e)
        {
            yonetimgiris yonetim = new yonetimgiris();
            yonetim.Show();
            this.Hide();
        }

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
            baglanti.Open(); SqlCommand komut = new SqlCommand("select * from Staff where Username='" + txtuser.Text + "'and UserPassword='" + txtpassword.Text + "'", baglanti); SqlDataReader dr = komut.ExecuteReader();
            if (txtuser.Text == "" || txtpassword.Text == "") { MessageBox.Show("Boş Alan Bırakılamaz !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dr.Read()) { personelmenu menu = new personelmenu(); menu.Show(); this.Hide(); }
            else { txtuser.Clear(); txtpassword.Clear(); MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            baglanti.Close();
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            anamenu.Show();
            this.Hide();
        }
    }
}
