using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketproject
{
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LB0RVOU\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
        DataSet daset = new DataSet();

        private void hesapla()
        {
            try
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select Sum(TotalPrice)  from Sale", baglanti);
                lblkasa.Text = komut.ExecuteScalar() + " TL ";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }
        private void kasa_Load(object sender, EventArgs e)
        {
            hesapla();
        }
    }
}
