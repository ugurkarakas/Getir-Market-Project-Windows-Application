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
using System.Net.Mail;
namespace marketproject
{
    public partial class basvurular : Form
    {
        public basvurular()
        {
            InitializeComponent();
        }
        JobBusiness jb = new JobBusiness();
        StaffBusiness sb = new StaffBusiness();
                                                                                                                                                                                                                                                                     SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        private void ListJobStaff()
        {
            MarketEntities db = new MarketEntities();
            var JobApplication = (from c in db.JobApplications
                                  select new
                             { c.Id, c.FirstName, c.LastName, c.Addres, c.Tc, c.Gender, c.Picture, c.Phone, c.Mail, c.Experience, c.Education, c.username,  c.password}).ToList();
            dgvCustomers.DataSource = JobApplication;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yonetimenu ym = new yonetimenu();
            ym.Show();
            this.Hide();
        }
        private void ListProducts()
        {
            MarketEntities db = new MarketEntities();
            var JobApplications = (from c in db.JobApplications
                                  select new
                             { c.Id, c.FirstName, c.LastName, c.Addres, c.Gender, c.Picture, c.Tc, c.Phone, c.Mail,  c.Experience,  c.Education, c.username, c.password }).ToList();
            dgvCustomers.DataSource = JobApplications;
        }
        private void basvurular_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = jb.List();
            ListProducts();
        }


        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            JobApplication c = jb.Read(Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value));
            txtid.Text = c.Id.ToString();
            txtisim.Text = c.FirstName;
            txtsoyisim.Text = c.LastName;
            txtadres.Text = c.Addres;
            txttelefon.Text = c.Phone;
            txtmail.Text = c.Mail;
            txtcinsiyet.Text = c.Gender;
            txtdeneyim.Text = c.Experience;
            txtegitim.Text = c.Education;
            txturl.Text = c.Picture;
            resim.ImageLocation = c.Picture;
            txttc.Text = c.Tc;
            txtkullaniciadi.Text = c.username;
            txtsifre.Text = c.password;
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter goster = new SqlDataAdapter("Select*from JobApplication where FirstName like '%" + txtara.Text + "%'", baglanti);
            goster.Fill(tablo);
            dgvCustomers.DataSource = tablo;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jb.Delete(Convert.ToInt32(txtid.Text));
            ListJobStaff();
            MailMessage mesajat = new MailMessage();
            SmtpClient istemci = new SmtpClient();/*getirholding@outlook.com*//*Getirdegetirelim*/
            istemci.Credentials = new System.Net.NetworkCredential("getirholding@outlook.com", "Getirdegetirelim");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajat.To.Add(txtmail.Text);
            mesajat.From = new MailAddress("getirholding@outlook.com");
            mesajat.Subject = "Getir | Personel Başvuru Hakkında !";
            mesajat.Attachments.Add(new Attachment(@"C:\Users\User\Desktop\market project\mailresim\isreddi.jpg"));
            mesajat.Body = "Sayın "+txtisim.Text+" "+txtsoyisim.Text+" Başvurunuz için teşekkür ederiz. Başvurduğunuz pozisyonla ilgili yapılan iş görüşmeleri neticesinde farklı bir aday ile anlaşma sağlanmıştır. Sürece katılımınız için teşekkür eder kariyerinizde başarılar dileriz.";
            istemci.Send(mesajat);
            MessageBox.Show("Başvuru Kaydı Başarıyla Silindi", "Silme İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtid.Clear(); txtisim.Clear(); txtsoyisim.Clear(); txtadres.Clear(); txttc.Clear(); txttelefon.Clear(); txtmail.Clear(); txtdeneyim.Clear(); txturl.Clear();  txtcinsiyet.Clear(); txtegitim.Clear(); txtkullaniciadi.Clear(); txtsifre.Clear();
            txtisim.Focus();
        }
        private void btnkayit_Click(object sender, EventArgs e)
        {
            Staff c = new Staff
            {
                FirstName = txtisim.Text,
                LastName = txtsoyisim.Text,
                Addres = txtadres.Text,
                Phone = txttelefon.Text,
                Mail = txtmail.Text,
                Gender = txtcinsiyet.Text,       
                Picture = txturl.Text,
                Tc = txttc.Text,
                Username = txtkullaniciadi.Text,
                UserPassword = txtsifre.Text,
            };
            sb.Create(c);
            jb.Delete(Convert.ToInt32(txtid.Text));
            ListJobStaff();
            MailMessage mesajat = new MailMessage();
            SmtpClient istemci = new SmtpClient();/*getirholding@outlook.com*//*Getirdegetirelim*/
            istemci.Credentials = new System.Net.NetworkCredential("getirholding@outlook.com", "Getirdegetirelim");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajat.To.Add(txtmail.Text);
            mesajat.From = new MailAddress("getirholding@outlook.com");
            mesajat.Subject = "Getir | Personel Başvuru Hakkında !";
            mesajat.Attachments.Add(new Attachment(@"C:\Users\User\Desktop\market project\mailresim\isealim.jpg"));
            mesajat.Body = "Sayın " + txtisim.Text + " " + txtsoyisim.Text + " TEBRİKLER İŞE ALINDINIZ. Başvurduğunuz pozisyonla ilgili yapılan iş görüşmeleri neticesinde aramızda olmanız bizim için mutluluk vericidir. Sisteme giriş bilgileriniz şöyledir;  'Kullanıcı Adı:"+txtkullaniciadi.Text+" ve "+"Şifre:"+txtsifre.Text+"'";
            istemci.Send(mesajat);
            MessageBox.Show("Personel Alım İşlemi Başarıyla Tamamlandı", "İşe Alım Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListJobStaff();
            txtid.Clear(); txtisim.Clear(); txtsoyisim.Clear(); txtadres.Clear(); txttc.Clear(); txttelefon.Clear(); txtmail.Clear(); txturl.Clear(); txtdeneyim.Clear(); txtcinsiyet.Clear(); txtegitim.Clear(); txtkullaniciadi.Clear(); txtsifre.Clear();
            txtisim.Focus();
        }
    }
}
