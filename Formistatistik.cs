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
    public partial class Formistatistik : Form
    {
        public Formistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=qwerty;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Formistatistik_Load(object sender, EventArgs e)
        {   //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();  
            while( dr1.Read()){
                personelsayisi.Text = dr1[0].ToString();

            }

            baglanti.Close();

            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where perdurum = 1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                evlipersonel.Text = dr2[0].ToString();

            }
            baglanti.Close();

            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where perdurum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                bekarpersonel.Text = dr3[0].ToString();

            }
            baglanti.Close();
            //sehir sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count( Distinct(Persehir)) From Tbl_Personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                toplamsehir.Text = dr4[0].ToString();

            }
            baglanti.Close();

            //ortalama maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select  avg(permaas) From Tbl_Personel ", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                ortalamamaas.Text = dr5[0].ToString();

            }
            baglanti.Close();

            //toplam maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select  sum(permaas) From Tbl_Personel ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                toplammaas.Text = dr6[0].ToString();

            }
            baglanti.Close();



        }
    }
}
