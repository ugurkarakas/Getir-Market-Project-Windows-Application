using _BusinessLayer;
using _DataLayer;
using marketproject.Bridge;
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
    public partial class satislar : Form
    {
        public satislar()
        {
            InitializeComponent();
        }
        SaleBusiness sb = new SaleBusiness();

        ProductsB modelwithproducts = new ProductsB
        {
            ProductObject = new SalesObject()
        };
        private void ListSales()
        {
            MarketEntities db = new MarketEntities();
            var Sale = (from p in db.Sales
                            select new
                            {
                                p.ProductID,
                                p.BarcodeNo,
                                p.CustomerFirstName,
                                p.CustomerLastName,
                                p.DateTimee,
                                p.Price,
                                p.ProductName,
                                p.TotalPrice,
                            }).ToList(); dgvCustomers.DataSource = Sale;
        }

        private void satislar_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = sb.List();
            ListSales();
        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Sale c = sb.Read(Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["ProductID"].Value));
            txtid.Text = c.ProductID.ToString();
            txtuser.Text = c.CustomerFirstName;
            txtlastuser.Text = c.CustomerLastName;
            txtbarcode.Text = c.BarcodeNo;
            txtproduct.Text = c.ProductName;
            txtmiktar.Text = c.quantity.ToString();
            txturunfiyati.Text = c.Price.ToString();
            txttoplamfiyat.Text = c.TotalPrice.ToString();
            txttarih.Text = c.DateTimee;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yonetimenu pmenu = new yonetimenu();
            pmenu.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = modelwithproducts.Show();
            Sale prod = modelwithproducts.Bastaki;
            txtid.Text = prod.ProductID.ToString();
            txtproduct.Text = prod.ProductName;
            txtuser.Text = prod.CustomerFirstName;
            txtbarcode.Text = prod.BarcodeNo;
            txtmiktar.Text = prod.quantity.ToString();
            txtlastuser.Text = prod.CustomerLastName;
            txttarih.Text = prod.DateTimee;
            txturunfiyati.Text = prod.Price.ToString();
            txttoplamfiyat.Text = prod.TotalPrice.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = modelwithproducts.Show();
            Sale prod = modelwithproducts.Onceki;
            txtid.Text = prod.ProductID.ToString();
            txtproduct.Text = prod.ProductName;
            txtuser.Text = prod.CustomerFirstName;
            txtbarcode.Text = prod.BarcodeNo;
            txtmiktar.Text = prod.quantity.ToString();
            txtlastuser.Text = prod.CustomerLastName;
            txttarih.Text = prod.DateTimee;
            txturunfiyati.Text = prod.Price.ToString();
            txttoplamfiyat.Text = prod.TotalPrice.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = modelwithproducts.Show();
            Sale prod = modelwithproducts.Mevcut;
            txtid.Text = prod.ProductID.ToString();
            txtproduct.Text = prod.ProductName;
            txtuser.Text = prod.CustomerFirstName;
            txtbarcode.Text = prod.BarcodeNo;
            txtmiktar.Text = prod.quantity.ToString();
            txtlastuser.Text = prod.CustomerLastName;
            txttarih.Text = prod.DateTimee;
            txturunfiyati.Text = prod.Price.ToString();
            txttoplamfiyat.Text = prod.TotalPrice.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = modelwithproducts.Show();
            Sale prod = modelwithproducts.Sonraki;
            txtid.Text = prod.ProductID.ToString();
            txtproduct.Text = prod.ProductName;
            txtuser.Text = prod.CustomerFirstName;
            txtbarcode.Text = prod.BarcodeNo;
            txtmiktar.Text = prod.quantity.ToString();
            txtlastuser.Text = prod.CustomerLastName;
            txttarih.Text = prod.DateTimee;
            txturunfiyati.Text = prod.Price.ToString();
            txttoplamfiyat.Text = prod.TotalPrice.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = modelwithproducts.Show();
            Sale prod = modelwithproducts.Sondaki;
            txtid.Text = prod.ProductID.ToString();
            txtproduct.Text = prod.ProductName;
            txtuser.Text = prod.CustomerFirstName;
            txtbarcode.Text = prod.BarcodeNo;
            txtmiktar.Text = prod.quantity.ToString();
            txtlastuser.Text = prod.CustomerLastName;
            txttarih.Text = prod.DateTimee;
            txturunfiyati.Text = prod.Price.ToString();
            txttoplamfiyat.Text = prod.TotalPrice.ToString();
        }
    }
}
