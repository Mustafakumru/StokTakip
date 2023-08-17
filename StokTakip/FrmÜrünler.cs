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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace StokTakip
{
    public partial class FrmÜrünler : Form
    {
        public FrmÜrünler()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source = mkumru\\MSSQLSERVER01; Initial Catalog = SatısVt; Integrated Security = True");
        private void btnListe_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select * from TBLKATEGORİ", bağlantı);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLKATEGORİ (KATEGORİAD) values (@p1) ", bağlantı);
            cmd.Parameters.AddWithValue("@p1",textBox2.Text);
            cmd.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("KAtegori KAydedildi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("delete from TBLKATEGORİ where KategoriID=@p1", bağlantı);
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("KAtegori Silme İşlemi gerçekleşti");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("update TBLKATEGORİ set KATEGORİAD=@p1 where KategoriID=@p2",bağlantı);
            cmd.Parameters.AddWithValue("p1", textBox2.Text);
            cmd.Parameters.AddWithValue("p2",textBox1.Text);
            cmd.ExecuteNonQuery();
            bağlantı.Close() ;
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
        }

        private void FrmÜrünler_Load(object sender, EventArgs e)
        {

        }
    }
}
