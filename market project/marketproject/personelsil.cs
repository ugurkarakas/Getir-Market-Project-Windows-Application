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
using System.Net.Mail;
namespace marketproject
{
    public partial class personelsil : Form
    {
        public personelsil()
        {
            InitializeComponent();
        }
        StaffBusiness sb = new StaffBusiness();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void ListStaff()
        {
            MarketEntities db = new MarketEntities();
            var Staff = (from c in db.Staffs select new { c.StaffID, c.FirstName, c.LastName, c.Mail,}).ToList(); dgvCustomers.DataSource = Staff;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sb.Delete(Convert.ToInt32(txtid.Text));
            ListStaff();
            MessageBox.Show("Personeli Başarıyla İşten Çıkardınız. E-mail Adresine Detaylı Bilgi Gönderilmiştir.", "İstafa İşlemi Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MailMessage mesajat = new MailMessage();
            SmtpClient istemci = new SmtpClient();/*getirholding@outlook.com*//*Getirdegetirelim*/
            istemci.Credentials = new System.Net.NetworkCredential("getirholding@outlook.com", "Getirdegetirelim");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajat.To.Add(txtmail.Text);
            mesajat.From = new MailAddress("getirholding@outlook.com");
            mesajat.Subject = "Getir | Personel Başvuru Hakkında !";
            mesajat.Attachments.Add(new Attachment(@"C:\Users\User\Desktop\market project\mailresim\istencikarma.jpg"));
            mesajat.Body = "Sayın " + txtisim.Text + " " + txtsoyisim.Text + " Yönetim Kurulu İle Yapmış Olduğumuz Görüşmeler Neticesinde Şirketimizde Göstermiş Olduğunuz Katkının Bizim İçin Yeterli Olmadığını ve Bu Yüzden İşten Çıkarılmış Olduğunuzu Belirtmek İstiyoruz. Şirket İçindeki Bütün Bilgileriniz Silinmiştir. Bundan Sonraki Kariyerinizde Başarılar Dileriz.";
            istemci.Send(mesajat);
            txtisim.Clear(); txtsoyisim.Clear(); txtid.Clear(); txtmail.Clear(); txtisim.Focus();
        }

        private void personelsil_Load(object sender, EventArgs e)
        {
            ListStaff();
        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Staff c = sb.Read(Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["StaffID"].Value));
            txtid.Text = c.StaffID.ToString();
            txtisim.Text = c.FirstName;
            txtsoyisim.Text = c.LastName;
            txtmail.Text = c.Mail;
        }
    }
}
