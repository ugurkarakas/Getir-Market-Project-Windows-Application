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
    public partial class urunler : Form
    {
        public urunler()
        {
            InitializeComponent();
            this.Load += urunler_Load;
        }
        ProductBusiness pb = new ProductBusiness();
      
        
        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var Products = (from p in db.Products
                             select new
                             {
 p.ProductID, p.BarcodeNo, p.ProductName, p.ProductPicture, p.Brand, p.Price, p.ExpirationDate, p.ProductionPlace, p.Contents, p.Weights, p.Stock, p.CategoryName}).ToList(); dgvProducts.DataSource = Products; }    SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        


        private void btnmusteri_Click(object sender, EventArgs e)
        {
            musteriler musteri = new musteriler();
            musteri.Show();
            this.Hide();
        }
   
        private void urunler_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = pb.List();
            ListProducts();
        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
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
            resim.ImageLocation = p.ProductPicture;
            txtstok.Text = p.Stock.ToString();
            txtkategori.Text = p.CategoryName;
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
            urunekle urunekle1 = new urunekle();
            urunekle1.Show();
            this.Hide();
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            urunguncelle urung = new urunguncelle();
            urung.Show();
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
            SqlDataAdapter goster = new SqlDataAdapter("Select*from Product where ProductName like '%"+txtara.Text+"%'", baglanti);
            goster.Fill(tablo);
            dgvProducts.DataSource = tablo;
            baglanti.Close();
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
