using _BusinessLayer;
using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class yonetimenu : Form
    {
        public yonetimenu()
        {
            InitializeComponent();
            pieChart1.InnerRadius = 100;
            pieChart1.LegendLocation = LiveCharts.LegendLocation.Right;
            SeriesCollection series = new SeriesCollection();
            foreach (var p in pb.ProductsStockByCategory())
            {
                series.Add(new PieSeries
                {
                    Title = p.CategoryName,
                    Values = new ChartValues<int> {(int)p.Stock},
                    DataLabels = true
                });
            }
            pieChart1.Series = series;
        }
        ProductBusiness pb = new ProductBusiness();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            anamenu.Show();
            this.Hide();
        }

        private void btnurun_Click(object sender, EventArgs e)
        {
            basvurular basvuru = new basvurular();
            basvuru.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personeller category = new personeller();
            category.ShowDialog();
        }

        private void btnurunguncelle_Click(object sender, EventArgs e)
        {
            personelsil category = new personelsil();
            category.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satislar satis = new satislar();
            satis.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kasa kasacik = new kasa();
            kasacik.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yoneticidetay yonetici = new yoneticidetay();
            yonetici.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rapor rap = new rapor();
            rap.Show(); this.Hide();
        }
    }
}
