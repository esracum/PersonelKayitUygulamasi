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

namespace Personel_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=qwerty;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            MskMaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();

        }

        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Grafikler frg = new Grafikler();
            frg.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(Perad,PerSoyad, PerSehir, PerMaas,  PerDurum,PerMeslek)values(@p1,@p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", txtmeslek.Text);
            



            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void dataGridView1_DefaultCellStyleChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void txtmeslek_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {   
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel where perid = @k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelleme = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad =@a2,Persehir = @a3, Permaas =@a4,Perdurum=@a5, Permeslek=@a6 where perid=@a7",baglanti);
            komutguncelleme.Parameters.AddWithValue("@a1",txtad.Text);
            komutguncelleme.Parameters.AddWithValue("@a2",txtsoyad.Text);
            komutguncelleme.Parameters.AddWithValue("@a3",cmbsehir.Text);
            komutguncelleme.Parameters.AddWithValue("@a4",MskMaas.Text);
            komutguncelleme.Parameters.AddWithValue("@a5",label8.Text);
            komutguncelleme.Parameters.AddWithValue("@a6",txtmeslek.Text);
            komutguncelleme.Parameters.AddWithValue("@a7",txtid.Text);
            komutguncelleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme yapıldı");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Formistatistik fr = new Formistatistik();
            fr.Show();
        }
    }
}
