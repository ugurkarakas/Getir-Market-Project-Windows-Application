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
    public partial class personeller : Form
    {
        public personeller()
        {
            InitializeComponent();
        }
        StaffBusiness sb = new StaffBusiness();

        private void ListStaff()
        {
            MarketEntities db = new MarketEntities();
            var Staff = (from c in db.Staffs
                                  select new
                                  { c.StaffID, c.FirstName, c.LastName, c.Addres, c.Tc, c.Gender, c.Picture, c.Phone, c.Mail, c.Username, c.UserPassword }).ToList();
            dgvCustomers.DataSource = Staff;
        }

        private void btnurun_Click(object sender, EventArgs e)
        {
            basvurular basvuru = new basvurular();
            basvuru.Show();
            this.Hide();
        }

        private void personeller_Load(object sender, EventArgs e)
        {
            ListStaff();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Staff c = sb.Read(Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["StaffID"].Value));
            txtid.Text = c.StaffID.ToString();
            txtisim.Text = c.FirstName;
            txtsoyisim.Text = c.LastName;
            txtadres.Text = c.Addres;
            txttelefon.Text = c.Phone;
            txtmail.Text = c.Mail;
            txtcinsiyet.Text = c.Gender;
            txturl.Text = c.Picture;
            resim.ImageLocation = c.Picture;
            txttc.Text = c.Tc;
            txtkullaniciadi.Text = c.Username;
            txtsifre.Text = c.UserPassword;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff c = sb.Read(Convert.ToInt32(txtid.Text));
            c.StaffID = Convert.ToInt32(txtid.Text);
            c.FirstName = txtisim.Text;
            c.LastName = txtsoyisim.Text;
            c.Addres = txtadres.Text;
            c.Phone = txttelefon.Text;
            c.Mail = txtmail.Text;
            c.Gender = txtcinsiyet.Text;
            c.Picture = txturl.Text;
            c.Tc = txttc.Text;
            c.Username = txtkullaniciadi.Text;
            c.UserPassword = txtsifre.Text;
            sb.Update(c);
            ListStaff();
            MessageBox.Show("Personel Bilgileri Başarıyla Güncellendi.", "Güncelleme İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            resim.ImageLocation = openFileDialog1.FileName;
            txturl.Text = openFileDialog1.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
