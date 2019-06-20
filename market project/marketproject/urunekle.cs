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
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
            
        }
        ProductBusiness pb = new ProductBusiness();
        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var Products = (from p in db.Products
                   select new
                   { p.ProductID, p.BarcodeNo, p.ProductName, p.ProductPicture, p.Brand, p.Price, p.ExpirationDate, p.ProductionPlace, p.Contents, p.Weights, p.Stock, p.CategoryName }).ToList(); dgvProducts.DataSource = Products; }  SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        private void urunekle_Load(object sender, EventArgs e)
        {
            //dgvProducts.DataSource = pb.List();
            //ListProducts();
            kategorigetir();
        }
        private void btnurun_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.Show();
            this.Hide();
        }
        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from ProductCategory", baglanti);
            SqlDataReader read = getir.ExecuteReader();
            while (read.Read())
            {
                txtkategori.Items.Add(read["CategoryName"].ToString());
            }
            baglanti.Close();
        }

        private void btnurunekle_Click(object sender, EventArgs e)
        {
            urunekle urun = new urunekle();
            urun.Show();
            this.Hide();
        }

        private void btnmusteri_Click(object sender, EventArgs e)
        {
            musteriler musteri = new musteriler();
            musteri.Show();
            this.Hide();
        }

        private void btnmusteriekle_Click(object sender, EventArgs e)
        {
            musteriekle musteriekle = new musteriekle();
            musteriekle.Show();
            this.Hide();
        }

        private void btnmusteriguncelle_Click(object sender, EventArgs e)
        {
            musteriguncelle mguncelle = new musteriguncelle();
            mguncelle.Show();
            this.Hide();
        }

        private void btnmusterisil_Click(object sender, EventArgs e)
        {
            musterisil msil = new musterisil();
            msil.Show();
            this.Hide();
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            Product p = new Product
            {
                BarcodeNo = txtbarkodno.Text,
                ProductName = txturunad.Text,
                ProductPicture = txtresimurl.Text,
                Brand = txtmarka.Text,
                Price = txturunfiyat.Text,
                ExpirationDate = txtdatetime.Text,
                ProductionPlace = txturetimyeri.Text,
                Contents = txticindekiler.Text,
                Weights = txtagirlik.Text,
                Stock = Convert.ToInt32(txtstok.Text),
                CategoryName = txtkategori.Text,

            };
            pb.Create(p);
            ListProducts();
            MessageBox.Show("Ürün Kayıt İşlemi Başarıyla Tamamlandı", "Ürün Kayıdı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txturunad.Clear(); txtbarkodno.Clear(); txtid.Clear(); txtresimurl.Clear(); txtmarka.Clear();
            txturunfiyat.Clear(); txturetimyeri.Clear(); txticindekiler.Clear(); txtagirlik.Clear(); txtstok.Clear(); txturunad.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            resim.ImageLocation = openFileDialog1.FileName;
            txtresimurl.Text = openFileDialog1.FileName;
        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Product p = pb.Read(Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value));
            txtid.Text = p.ProductID.ToString();
            txtbarkodno.Text = p.BarcodeNo;
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
            txtkategori.Text = p.CategoryName;
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            urunguncelle guncelle = new urunguncelle();
            guncelle.Show();
            this.Hide();
        }

        private void btnurunsil_Click(object sender, EventArgs e)
        {
            urunsil urunsil = new urunsil();
            urunsil.Show();
            this.Hide();
        }

        private void resim_Click(object sender, EventArgs e)
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
