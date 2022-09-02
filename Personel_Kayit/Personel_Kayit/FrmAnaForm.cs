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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HQPDE46;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtPersonelid.Text = "";
            txtPersonelad.Text = "";
            txtSoyad.Text = "";
            TxtMeslek.Text = "";
            cmbSehir.Text = "";
            maskedmaaş.Text = "";
            rdBtnEvli.Checked = false;
            rdBtnBekar.Checked = false;
            txtPersonelad.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
           

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,Permaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtPersonelad.Text);
            komut.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", maskedmaaş.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void rdBtnEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void rdBtnBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnBekar.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtPersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPersonelad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedmaaş.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                rdBtnEvli.Checked = true;
            }
            if (label8.Text == "False")
            {
                rdBtnBekar.Checked=true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtPersonelid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silidni");
        }

        private void BtnGuıncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelleme = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelleme.Parameters.AddWithValue("@a1",txtPersonelad.Text);
            komutguncelleme.Parameters.AddWithValue("@a2",txtSoyad.Text);
            komutguncelleme.Parameters.AddWithValue("@a3", cmbSehir.Text);
            komutguncelleme.Parameters.AddWithValue("@a4", maskedmaaş.Text);
            komutguncelleme.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelleme.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            komutguncelleme.Parameters.AddWithValue("@a7", txtPersonelid.Text);

            komutguncelleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Verileri Güncellendi");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatitlik fr =new Frmİstatitlik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frmGrafikler = new FrmGrafikler();
            frmGrafikler.Show();
        }
    }
}
