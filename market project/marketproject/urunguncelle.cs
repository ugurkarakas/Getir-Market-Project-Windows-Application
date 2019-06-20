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
    public partial class urunguncelle : Form
    {
        public urunguncelle()
        {
            InitializeComponent();
            this.Load += urunguncelle_Load;
        }
        ProductBusiness pb = new ProductBusiness();
        ProductCategoryBusiness pcb = new ProductCategoryBusiness();

        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var Products = (from p in db.Products
                select new
                { p.ProductID, p.BarcodeNo, p.ProductName, p.ProductPicture, p.Brand, p.Price, p.ExpirationDate, p.ProductionPlace, p.Contents, p.Weights, p.Stock, p.CategoryName }).ToList(); dgvProducts.DataSource = Products; }  SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        private void urunguncelle_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = pb.List();
            ListProducts();
            kategorigetir();
        }
       private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from ProductCategory", baglanti);
            SqlDataReader read = getir.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read["CategoryName"].ToString());
            }
            baglanti.Close();
        }
        private void btnkayit_Click(object sender, EventArgs e)
        {
            Product p = pb.Read(Convert.ToInt32(txtid.Text));
            p.ProductID = Convert.ToInt32(txtid.Text);
            p.BarcodeNo = txtbarkodno.Text;
            p.ProductName = txturunad.Text;
            p.ProductPicture = txtresimurl.Text;
            p.Brand = txtmarka.Text;
            p.Price = txturunfiyat.Text;
            p.ExpirationDate = txtdatetime.Text;
            p.ProductionPlace = txturetimyeri.Text;
            p.Contents = txticindekiler.Text;
            p.Weights = txtagirlik.Text;
            p.Stock = Convert.ToInt32(txtstok.Text);
            p.CategoryName = listBox1.Text;
            pb.Update(p);
           
            ListProducts();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Product p = pb.Read(Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value));
            txtid.Text = p.ProductID.ToString();
            txtbarkodno.Text = p.BarcodeNo.ToString();
            txturunad.Text = p.ProductName;
            txtresimurl.Text = p.ProductPicture;
            txtmarka.Text = p.Brand;
            txturunfiyat.Text = p.Price;
            txtdatetime.Text = p.ExpirationDate;
            txturetimyeri.Text = p.ProductionPlace;
            txticindekiler.Text = p.Contents;
            txtagirlik.Text = p.Weights;
            txtstok.Text = p.Stock.ToString();
            resim.ImageLocation = p.ProductPicture;
            listBox1.Text = p.CategoryName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            resim.ImageLocation = openFileDialog1.FileName;
            txtresimurl.Text = openFileDialog1.FileName;
        }

        private void btnurun_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.Show();
            this.Hide();
        }

        private void btnurunekle_Click(object sender, EventArgs e)
        {
            urunekle urunekle = new urunekle();
            urunekle.Show();
            this.Hide();
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            urunguncelle urunguncelle = new urunguncelle();
            urunguncelle.Show();
            this.Hide();
        }

        private void btnurunsil_Click(object sender, EventArgs e)
        {
            urunsil urunsil = new urunsil();
            urunsil.Show();
            this.Hide();
        }

        private void btnmusteri_Click(object sender, EventArgs e)
        {
            musteriler urun = new musteriler();
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

        private void lblcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personelmenu pm = new personelmenu(); pm.Show(); this.Hide();
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
