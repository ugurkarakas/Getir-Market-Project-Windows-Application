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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }
        ProductCategoryBusiness pcb = new ProductCategoryBusiness();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        bool durum;
        private void kategoriengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from ProductCategory",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                if(txtcategory.Text==read["CategoryName"].ToString() || txtcategory.Text=="")
                    {
                    durum = false;
                  }
            }baglanti.Close();
        }
        private void btnsat_Click(object sender, EventArgs e)
        {
            kategoriengelle();
            if (durum == true)
            {


                ProductCategory pc = new ProductCategory
                {
                    CategoryName = txtcategory.Text,
                };
                pcb.Create(pc);
                MessageBox.Show("Kayıt Başarıyla Tamamlandı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information); txtcategory.Clear(); txtcategory.Focus();
            }
            else {
                MessageBox.Show("Veritabanında Aynı İsimli Başka Bir Kategori Bulunmaktadır !              " +
                    "Lütfen Başka Bir Kategori İsmi Giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcategory.Clear(); txtcategory.Focus();
            }
        }
    }
}
