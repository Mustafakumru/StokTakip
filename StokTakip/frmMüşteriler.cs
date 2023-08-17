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
    public partial class frmMüşteriler : Form
    {
        public frmMüşteriler()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source = mkumru\\MSSQLSERVER01; Initial Catalog = SatısVt; Integrated Security = True");
        void listele()
        {
              
            SqlCommand cmd = new SqlCommand("Select * from TblMusteri",bağlantı);
            SqlDataAdapter da= new SqlDataAdapter(cmd);    
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;              

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            listele();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyat.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbşehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("insert into TblMusteri (MUŞTERİAD,MusteriSOYAD,MusteriŞehir,MUSTERİBAKİYE) values(@p1,@p2,@p3,@p4)", bağlantı);
            cmd.Parameters.AddWithValue("@p1",TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtSoyat.Text);
            cmd.Parameters.AddWithValue("@p4",decimal.Parse(txtBakiye.Text));
            cmd.Parameters.AddWithValue("@p3",cmbşehir.Text);
            cmd.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Müşteri Kaydı Tamamlandı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand cmd = new SqlCommand("delete TblMusteri where MUSTERID=@p1",bağlantı);
            cmd.Parameters.AddWithValue("@p1", txtİd.Text);
            cmd.ExecuteNonQuery();
            bağlantı.Close ();
            MessageBox.Show("Müşteri Silme İşlemi Gerçekleştirildi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bağlantı.Open ();
            SqlCommand cmd = new SqlCommand("update TblMusteri set MUŞTERİAD=@p1,MusteriSOYAD=@p2,MusteriŞehir=@p3,MUSTERİBAKİYE=@p4  where MUSTERID=@p5",bağlantı);
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyat.Text);
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtBakiye.Text));
            cmd.Parameters.AddWithValue("@p3", cmbşehir.Text);
            cmd.Parameters.AddWithValue("@p5", txtİd.Text);
            cmd.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi");
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from TblMusteri where MUŞTERİAD=@p1",bağlantı);
            cmd.Parameters.AddWithValue("@p1",TxtAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }
    }
}
