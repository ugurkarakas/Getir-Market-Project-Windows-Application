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
    public partial class personelkayit : Form
    {
        public personelkayit()
        {
            InitializeComponent();
        }
        JobBusiness job = new JobBusiness();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            txturl.Text = openFileDialog1.FileName;
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            menu geridon = new menu();
            geridon.Show();
            this.Hide();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if (txtisim.Text == "" || txtsoyisim.Text == "" || txtadres.Text == "" || lblcinsiyet.Text == "" || txturl.Text == "" || txttc.Text == "" || txtdeneyim.Text == "" || lblegitim.Text == "" || txtuser.Text == "" || txtpassword.Text == "")
            { MessageBox.Show("Boş Alan Bırakılamaz !", "Başvuru Kaydı Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
            JobApplication jb = new JobApplication
            {
                FirstName = txtisim.Text,
                LastName = txtsoyisim.Text,
                Addres = txtadres.Text,
                Gender = lblcinsiyet.Text,
                Picture = txturl.Text,
                Tc = txttc.Text,
                Phone = txttelefon.Text,
                Mail = txtmail.Text,
                Experience = txtdeneyim.Text,
                Education = lblegitim.Text,
                username = txtuser.Text,
                password = txtpassword.Text,
            };
            job.Create(jb);
            MessageBox.Show("Başvurunuz Başarıyla Tamamlandı! Geri Dönüş Mesajı Mail Adresinize En Yakın Zamanda Gönderilecektir.", "Başvuru Kaydı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            menu menugit = new menu();
            menugit.Show();
            this.Hide();
            }
        }
    }
}