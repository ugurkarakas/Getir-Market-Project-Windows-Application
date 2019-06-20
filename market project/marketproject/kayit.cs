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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
            this.Load += kayit_Load;

        }
        CustomerBusiness cb = new CustomerBusiness();
        private void kayit_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            anamenu.Show();
            this.Hide();
        }



        private void btngiris_Click(object sender, EventArgs e)
        {
            if (txtisim.Text == "" || txtsoyisim.Text == "" || txtadres.Text == "" || txtmail.Text==""|| lblbakiye.Text==""|| lblsoru.Text=="" ||txtcevap.Text==""|| lblcinsiyet.Text == "" || txturl.Text == "" || txttc.Text == "" || txttelefon.Text == "" ||txtkullaniciadi.Text==""||txtsifre.Text=="")
            {
                MessageBox.Show("Boş Alan Bırakılamaz !", "Kullanıcı Kaydı Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtisim.Clear(); txtsoyisim.Clear(); txtadres.Clear(); txttelefon.Clear(); txtmail.Clear();
                txtcevap.Clear(); txttc.Clear(); txturl.Clear(); txtkullaniciadi.Clear(); txtsifre.Clear(); lblbakiye.ClearSelected(); lblcinsiyet.ClearSelected(); lblsoru.ClearSelected(); txtisim.Focus();
            }
            else
            {
                Customer c = new Customer
                {
                    FirstName = txtisim.Text,
                    LastName = txtsoyisim.Text,
                    Addres = txtadres.Text,
                    Phone = txttelefon.Text,
                    Mail = txtmail.Text,
                    Gender = lblcinsiyet.Text,
                    quantity = lblbakiye.Text,
                    question = lblsoru.Text,
                    reply = txtcevap.Text,
                    Picture = txturl.Text,
                    Tc = txttc.Text,
                    UserName = txtkullaniciadi.Text,
                    UserPassword = txtsifre.Text,
                };
                cb.Create(c);
                MessageBox.Show("Kayıt Başarıyla Tamamlandı", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu menugit = new menu();
                menugit.Show();
                this.Hide();
            }
        } 

        

        private void btnyukle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            resim.ImageLocation = openFileDialog1.FileName;
            txturl.Text = openFileDialog1.FileName;
        }
    }
}
