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
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }
        ProductBusiness pb = new ProductBusiness();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            anamenu.Show();
            this.Hide();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            label2.Text = "Kullanıcı :" + giris.FirstName.ToString();
            label1.Text = "Bakiye Miktarı :" + giris.quantity.ToString()+" TL";
            pictureBox3.ImageLocation = giris.Picture.ToString();
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
