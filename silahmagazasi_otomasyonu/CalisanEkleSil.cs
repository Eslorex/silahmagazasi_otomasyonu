﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace silahmagazasi_otomasyonu
{
    public partial class CalisanEkleSil : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ESLOREX\\SQLEXPRESS;Initial Catalog=silahmagaza;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        public CalisanEkleSil()
        {
            InitializeComponent();
        }

        private void Ekleme_butonu_Click(object sender, EventArgs e)
        {
            string ekle_sorgu = "INSERT INTO calisanlar(depoNo, magazaNo, aylik_maas,baslangic_tarihi,calisanTelNo,calisanPozisyon) VALUES (@depoNo, @magazaNo, @aylik_maas,@baslangic_tarihi,@calisanTelNo,@calisanPozisyon)";
            komut = new SqlCommand(ekle_sorgu, baglanti);
            komut.Parameters.AddWithValue("@depoNo", depono_textbox.Text);
            komut.Parameters.AddWithValue("@magazaNo", magazano_textbox.Text);
            komut.Parameters.AddWithValue("@aylik_maas", calisanmaas_textbox.Text);
            komut.Parameters.AddWithValue("@baslangic_tarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@calisanTelNo", ctelno_textbox.Text);
            komut.Parameters.AddWithValue("@calisanPozisyon", cpozisyon_textbox.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void CalisanEkleSil_Load(object sender, EventArgs e)
        {

        }

        private void ctelno_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EkleSil f1 = new EkleSil();
            f1.ShowDialog();
            this.Close();
        }

        private void sil_buton_Click(object sender, EventArgs e)
        {
            string sil_sorgu = "DELETE FROM calisanlar WHERE calisanNo = @calisanNo";
            komut = new SqlCommand(sil_sorgu, baglanti);
            komut.Parameters.AddWithValue("@depoNo", Convert.ToInt32(calisanid_textbox.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
