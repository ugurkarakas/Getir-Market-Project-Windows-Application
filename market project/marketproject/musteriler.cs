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
using System.Data.SqlClient;
namespace marketproject
{
    public partial class musteriler : Form
    {
        public musteriler()
        {
            InitializeComponent();
            this.Load += musteriler_Load;
        }

        CustomerBusiness cb = new CustomerBusiness();
                                                                                                                                                                                                                     SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
    
       
        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var Customers = (from c in db.Customers
                             select new
                             { c.CustomerID, c.FirstName, c.Addres, c.Phone, c.Mail, c.Gender, c.quantity, c.question, c.reply, c.Picture, c.Tc, c.UserName, c.UserPassword }).ToList();
            dgvCustomers.DataSource = Customers;
        }
       

        private void musteriler_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = cb.List();
            ListProducts();
        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Customer c = cb.Read(Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["CustomerID"].Value));
            txtid.Text = c.CustomerID.ToString();
            txtisim.Text = c.FirstName;
            txtsoyisim.Text = c.LastName;
            txtadres.Text = c.Addres;
            txttelefon.Text = c.Phone;
            txtmail.Text = c.Mail;
            txtcinsiyet.Text = c.Gender;
            txtbakiye.Text = c.quantity;
            txtsoru.Text = c.question;
            txtcevap.Text = c.reply;
            txturl.Text = c.Picture;
            resim.ImageLocation = c.Picture;
            txttc.Text = c.Tc;
            txtkullaniciadi.Text = c.UserName;
            txtsifre.Text = c.UserPassword;
        }

        private void btnmusteri_Click(object sender, EventArgs e)
        {
            musteriler musteri = new musteriler();
            musteri.Show();
            this.Hide();
        }

        private void btnmusteriekle_Click(object sender, EventArgs e)
        {
            musteriekle musteri = new musteriekle();
            musteri.Show();
            this.Hide();
        }

        private void btnmusteriguncelle_Click(object sender, EventArgs e)
        {
            musteriguncelle musteri = new musteriguncelle();
            musteri.Show();
            this.Hide();
        }

        private void btnmusterisil_Click(object sender, EventArgs e)
        {
            musterisil musteri = new musterisil();
            musteri.Show();
            this.Hide();
        }

       
        private void btnurun_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.Show();
            this.Hide();
        }

        private void btnurunekle_Click(object sender, EventArgs e)
        {
            urunekle urun = new urunekle();
            urun.Show();
            this.Hide();
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            urunguncelle urun = new urunguncelle();
            urun.Show();
            this.Hide();
        }

        private void btnurunsil_Click(object sender, EventArgs e)
        {
            urunsil urun = new urunsil();
            urun.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personelmenu pm = new personelmenu(); pm.Show(); this.Hide();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter goster = new SqlDataAdapter("Select*from Customer where FirstName like '%" + txtara.Text + "%'", baglanti);
            goster.Fill(tablo);
            dgvCustomers.DataSource = tablo;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kategori category = new kategori();
            category.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kategorislem category = new kategorislem();
            category.ShowDialog();
        }
    }
}
