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
    public partial class kategorislem : Form
    {
        public kategorislem()
        {
            InitializeComponent();
        }
        ProductCategoryBusiness pcb = new ProductCategoryBusiness();
        private void ListCategory()
        {
            MarketEntities db = new MarketEntities();
            var ProductCategories = (from p in db.ProductCategories
                            select new
                            { p.categoryID, p.CategoryName }).ToList(); dgvProducts.DataSource = ProductCategories;
        }
        private void btnkayit_Click(object sender, EventArgs e)
        {
            ProductCategory p = pcb.Read(Convert.ToInt32(txtid.Text));
            p.categoryID = Convert.ToInt32(txtid.Text);
            p.CategoryName = txtname.Text;          
            pcb.Update(p);
            ListCategory();
            MessageBox.Show("Kategori Adı Başarıyla Güncellendi", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kategorislem_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = pcb.List();
            ListCategory();
        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ProductCategory p = pcb.Read(Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["CategoryId"].Value));
            txtid.Text = p.categoryID.ToString();
            txtname.Text = p.CategoryName.ToString();
        }
    }
}
