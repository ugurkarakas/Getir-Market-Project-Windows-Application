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
    public partial class musteriguncelle : Form
    {
        public musteriguncelle()
        {
            InitializeComponent();
            this.Load += musteriguncelle_Load;
        }
        CustomerBusiness cb = new CustomerBusiness();
        private void ListCustomers()
        {
            MarketEntities db = new MarketEntities();
            var Customers = (from c in db.Customers
                             select new
                             { c.CustomerID, c.FirstName, c.Addres, c.Phone, c.Mail, c.Gender, c.quantity, c.question, c.reply, c.Picture, c.Tc, c.UserName, c.UserPassword }).ToList();
            dgvCustomers.DataSource = Customers;
        }
        private void musteriguncelle_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = cb.List();
            ListCustomers();
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
            lblcinsiyet.Text = c.Gender;
            lblbakiye.Text = c.quantity;
            lblsoru.Text = c.question;
            txtcevap.Text = c.reply;
            txturl.Text = c.Picture;
            resim.ImageLocation = c.Picture;
            txttc.Text = c.Tc;
            txtkullaniciadi.Text = c.UserName;
            txtsifre.Text = c.UserPassword;

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            Customer c = cb.Read(Convert.ToInt32(txtid.Text));
            c.CustomerID = Convert.ToInt32(txtid.Text);
            c.FirstName = txtisim.Text;
            c.LastName = txtsoyisim.Text;
            c.Addres = txtadres.Text;
            c.Phone = txttelefon.Text;
            c.Mail = txtmail.Text;
            c.Gender = lblcinsiyet.Text;
            c.quantity = lblbakiye.Text;
            c.question = lblsoru.Text;
            c.reply = txtcevap.Text;
            c.Picture = txturl.Text;
            c.Tc = txttc.Text;
            c.UserName = txtkullaniciadi.Text;
            c.UserPassword = txtsifre.Text;
            cb.Update(c);
            ListCustomers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            resim.ImageLocation = openFileDialog1.FileName;
            txturl.Text = openFileDialog1.FileName;
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategori category = new kategori();
            category.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kategorislem category = new kategorislem();
            category.ShowDialog();
        }
    }
}
