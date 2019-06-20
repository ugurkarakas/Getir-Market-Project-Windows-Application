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
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        private void rapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'MarketDataSet.Product' table. You can move, or remove it, as needed.
            this.ProductTableAdapter.Fill(this.MarketDataSet.Product);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yonetimenu menu = new yonetimenu();
            menu.Show();
            this.Hide();
        }
    }
}
