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
    public partial class urunsil : Form
    {
        public urunsil()
        {
            InitializeComponent();
        }
        ProductBusiness pb = new ProductBusiness();
        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var Products = (from p in db.Products
                            select new
                            { p.ProductID, p.BarcodeNo, p.ProductName, p.ProductPicture, p.Brand, p.Price, p.ExpirationDate, p.ProductionPlace, p.Contents, p.Weights, p.Stock }).ToList();
            dgvProducts.DataSource = Products;
        }
        private void urunsil_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = pb.List();
            ListProducts();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            pb.Delete(Convert.ToInt32(txtid.Text));
            ListProducts();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Silme İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txturunad.Clear(); txtbarkodno.Clear(); txtbarkodno.Focus();
        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Product p = pb.Read(Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value));
            txtid.Text = p.ProductID.ToString();
            txtbarkodno.Text = p.BarcodeNo;
            txturunad.Text = p.ProductName;
        }

        private void btnurun_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.Show();
            this.Hide();
        }

        private void btnmusteri_Click(object sender, EventArgs e)
        {
            musteriler urun = new musteriler();
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

        private void btnmusteriekle_Click(object sender, EventArgs e)
        {
            musteriekle urun = new musteriekle();
            urun.Show();
            this.Hide();
        }

        private void btnmusteriguncelle_Click(object sender, EventArgs e)
        {
            musteriguncelle urun = new musteriguncelle();
            urun.Show();
            this.Hide();
        }

        private void btnmusterisil_Click(object sender, EventArgs e)
        {
            musterisil urun = new musterisil();
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
