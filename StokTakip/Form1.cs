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

namespace StokTakip
{
    public partial class Btnçıkış : Form
    {
        public Btnçıkış()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı =new SqlConnection("Data Source = mkumru\\MSSQLSERVER01; Initial Catalog = SatısVt; Integrated Security = True");
        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnkategori_Click(object sender, EventArgs e)
        {
            FrmÜrünler fr = new FrmÜrünler();
            fr.Show();

              
        }

        private void btnMüşteriler_Click(object sender, EventArgs e)
        {
            frmMüşteriler fr =new frmMüşteriler();
            fr.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Btnçıkış_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("select KATEGORİAD , count(*) from TBLKATEGORİ  inner join TBLURUNLER on TBLKATEGORİ.KategoriID=TBLURUNLER.KATEGORİ group by KATEGORİAD ", bağlantı);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(rdr[0], rdr[1]);
            }
            bağlantı.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
