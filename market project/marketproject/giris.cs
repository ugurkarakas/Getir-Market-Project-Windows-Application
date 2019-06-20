using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace marketproject
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            anamenu.Show();
            this.Hide();
        }

        private void blur1_Click(object sender, EventArgs e)
        {
        }

        private void btngiris1_Click(object sender, EventArgs e)
        {
            getir();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Customer where UserName='" + txtuser.Text + "'and UserPassword='" + txtpassword.Text + "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (txtuser.Text == "" || txtpassword.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dr.Read())
            { anamenu menu = new anamenu(); menu.Show(); this.Hide(); }
            else
            { txtuser.Clear(); txtpassword.Clear(); MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış !", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            baglanti.Close();
        }
        public static string FirstName;
        public static string LastName;
        public static string Picture;
        public static string UserName;
        public static string quantity;
        private void getir()
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select FirstName,LastName,Picture,UserName,quantity from Customer where UserName='" + txtuser.Text + "'and UserPassword='" + txtpassword.Text + "'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                FirstName = dr[0].ToString();
                LastName = dr[1].ToString();
                Picture = dr[2].ToString();
                UserName = dr[3].ToString();
                quantity = dr[4].ToString();
                }
                baglanti.Close();
                //Giriş Yapıldığı Zaman Kullanıcının Kişisel Bilgilerini Sayfa Loadlarında Göstermesi İçin Yapılır.
            }
        }
    }

