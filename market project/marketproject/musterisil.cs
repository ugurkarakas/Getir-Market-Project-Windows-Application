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
    public partial class musterisil : Form
    {
        public musterisil()
        {
            InitializeComponent();
            this.Load += musterisil_Load;
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
        

        private void musterisil_Load(object sender, EventArgs e)
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
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            cb.Delete(Convert.ToInt32(txtid.Text));
            ListCustomers();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Silme İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtisim.Clear(); txtsoyisim.Clear(); txtisim.Focus();
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

        private void button3_Click(object sender, EventArgs e)
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
