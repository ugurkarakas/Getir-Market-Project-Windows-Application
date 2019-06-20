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
    public partial class personelmenu : Form
    {
        public personelmenu()
        {
            InitializeComponent();
        }
        SepetBusiness sepetim = new SepetBusiness();   DataSet daset = new DataSet();   SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
       
        private void hesapla()
        {
            try
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select Sum(TotalPrice)  from Sepet",baglanti);     
                txttoplamfiyatlar.Text = komut.ExecuteScalar()+"";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }
        private void sepetlistele()
        {
            baglanti.Open(); SqlDataAdapter adtr = new SqlDataAdapter("Select * From Sepet", baglanti); adtr.Fill(daset, "Sepet"); dgvProducts.DataSource = daset.Tables["Sepet"];
            dgvProducts.Columns[0].Visible = false; dgvProducts.Columns[1].Visible = false; dgvProducts.Columns[2].Visible = false; baglanti.Close();
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menu m = new menu(); m.Show(); this.Hide();
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
        private void personelmenu_Load(object sender, EventArgs e)
        {
            sepetlistele();
            hesapla();
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Temizle();  baglanti.Open();  SqlCommand komut = new SqlCommand("Select * From Product Where BarcodeNo like'" + txtbarkod.Text + "'", baglanti); SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txturunadi.Text = read["ProductName"].ToString();
                txtsatisfiyati.Text = read["Price"].ToString();
                txtmarka.Text = read["Brand"].ToString();

            }
            baglanti.Close();
        }

        private void Temizle()
        {
            if (txtbarkod.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {


                        if (item != combomiktar)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

     
        private void combomiktar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(combomiktar.Text) * double.Parse(txtsatisfiyati.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }
        private void btnuruncikar_Click(object sender, EventArgs e)
        {
            baglanti.Open(); SqlCommand komut = new SqlCommand("Delete From Sepet Where BarcodeNo='" + dgvProducts.CurrentRow.Cells["BarcodeNo"].Value.ToString() + "'", baglanti); komut.ExecuteNonQuery(); baglanti.Close();  MessageBox.Show("Ürün Sepetten Başarıyla Çıkarıldı.", "İşlem Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information); daset.Tables["Sepet"].Clear(); sepetlistele(); hesapla();
        }

        private void btnsatısiptal_Click(object sender, EventArgs e)
        {
            baglanti.Open(); SqlCommand komut = new SqlCommand("Delete From Sepet", baglanti); komut.ExecuteNonQuery(); baglanti.Close(); MessageBox.Show("Tüm Ürünler Sepetten Başarıyla Çıkarıldı.", "İşlem Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information); daset.Tables["Sepet"].Clear(); sepetlistele(); hesapla();
        }
        private void txtsatisfiyati_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(combomiktar.Text) * double.Parse(txtsatisfiyati.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }
        private void txtad_TextChanged(object sender, EventArgs e)
        {
            Temizle(); baglanti.Open(); SqlCommand komut = new SqlCommand("Select * From Customer Where FirstName like'" + txtad.Text + "'", baglanti); SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtsoyad.Text = read["LastName"].ToString();
            }
            baglanti.Close();
        }
        private void txturunler_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.Show();
            this.Hide();
        }
        private void ListSale()
        {
            MarketEntities db = new MarketEntities();
            var Sepet = (from c in db.Sepets select new { c.BarcodeNo, c.Ad, c.Soyad, c.DateTimee, c.Price, c.ProductID, c.ProductName, c.quantity, c.TotalPrice}).ToList(); dgvProducts.DataSource = Sepet;
        }
        private void btnsatis_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Sale(CustomerFirstName,CustomerLastName,BarcodeNo,ProductName,quantity,Price,TotalPrice,DateTimee) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",baglanti);
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                komut.Parameters.AddWithValue("@p3", dgvProducts.Rows[i].Cells["BarcodeNo"].Value.ToString());
                komut.Parameters.AddWithValue("@p4", dgvProducts.Rows[i].Cells["ProductName"].Value.ToString());
                komut.Parameters.AddWithValue("@p5", int.Parse(dgvProducts.Rows[i].Cells["quantity"].Value.ToString()));
                komut.Parameters.AddWithValue("@p6", int.Parse(dgvProducts.Rows[i].Cells["Price"].Value.ToString()));
                komut.Parameters.AddWithValue("@p7", int.Parse(dgvProducts.Rows[i].Cells["TotalPrice"].Value.ToString()));
                komut.Parameters.AddWithValue("@p8", dateTimePicker1.Text);
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update Product set Stock=Stock-'"+int.Parse(dgvProducts.Rows[i].Cells["quantity"].Value.ToString()) +"'where BarcodeNo='"+ dgvProducts.Rows[i].Cells["BarcodeNo"].Value.ToString() + "'",baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
                daset.Tables["Sepet"].Clear();
                sepetlistele();
                hesapla();
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Delete From Sepet", baglanti); komut3.ExecuteNonQuery(); baglanti.Close(); ListSale(); txttoplamfiyatlar.Clear(); txtbarkod.Focus();
                MessageBox.Show("Satış Başarıyla Tamamlandı", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information); 
               

        }

        private void btnsat_Click(object sender, EventArgs e)
        {
            Sepet c = new Sepet
            {
                Ad = txtad.Text,
                Soyad = txtsoyad.Text,
                BarcodeNo = txtbarkod.Text,
                ProductName = txturunadi.Text,
                Brand = txtmarka.Text,
                quantity = combomiktar.Text,
                Price = txtsatisfiyati.Text,
                TotalPrice = int.Parse(txttoplamfiyat.Text),
                DateTimee = dateTimePicker1.Text,
            };
            sepetim.Create(c);
            daset.Tables["Sepet"].Clear();
            combomiktar.Text = "Adet Seçiniz";
            sepetlistele();
            hesapla();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != combomiktar)
                    {
                        item.Text = "";
                    }
                }
            }
        }
    }
}
