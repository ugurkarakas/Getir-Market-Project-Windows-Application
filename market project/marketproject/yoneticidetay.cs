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
    public partial class yoneticidetay : Form
    {
        public yoneticidetay()
        {
            InitializeComponent();
        }
        GovernanceBusiness gb = new GovernanceBusiness();
        private void ListGovernance()
        {
            MarketEntities db = new MarketEntities();
            var Governances = (from p in db.Governances
                            select new
                            {
                                p.GovernanceID,
                                p.FirstName,
                                p.LastName,
                                p.Gender,
                                p.UserName,
                                p.UserPassword,}).ToList(); dgvProducts.DataSource = Governances;
        }

        private void yoneticidetay_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = gb.List();
            ListGovernance();

        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Governance p = gb.Read(Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["GovernanceID"].Value));
            txtid.Text = p.GovernanceID.ToString();
            txtad.Text = p.FirstName;
            txtsoyad.Text = p.LastName;
            lst1.Text = p.Gender;
            txtusername.Text = p.UserName;
            txtpassword.Text = p.UserPassword;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtad.Clear(); lst1.ClearSelected(); txtid.Clear(); txtpassword.Clear(); txtsoyad.Clear(); txtusername.Clear(); txtad.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Governance p = gb.Read(Convert.ToInt32(txtid.Text));
            p.GovernanceID = Convert.ToInt32(txtid.Text);
            p.UserPassword = txtpassword.Text;
            p.UserName = txtusername.Text;
            p.FirstName = txtad.Text;
            p.LastName = txtsoyad.Text;
            p.Gender = lst1.Text;
            gb.Update(p);

            ListGovernance();
            MessageBox.Show("Yönetici Bilgileri Başarıyla Güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gb.Delete(Convert.ToInt32(txtid.Text));
            ListGovernance();
            MessageBox.Show("Yönetici Kaydı Başarıyla Silindi", "Silme İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtad.Clear(); lst1.ClearSelected(); txtpassword.Clear(); txtsoyad.Clear(); txtid.Clear(); txtusername.Clear(); txtad.Focus();
        }

        private void btnurun_Click(object sender, EventArgs e)
        {
            yoneticiekle ekley = new yoneticiekle();
            ekley.Show(); this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yonetimenu menum = new yonetimenu();
            menum.Show(); this.Hide();
        }
    }
}
