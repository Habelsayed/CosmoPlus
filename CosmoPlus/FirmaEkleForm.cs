using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace CosmoPlus
{
    public partial class FirmaEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public FirmaEkleForm()
        {
            InitializeComponent();
            LoadUlkeComboBox();
            LoadCityComboBox(); // Load cities directly
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan değerler
            string firmaAdi = textBox1.Text.Trim();
            string firmaAdresi = textBox2.Text.Trim();
            string firmaAdresi2 = textBox3.Text.Trim();
            string firmaKodu = textBox4.Text.Trim();
            string ulkeKodu = comboBox1.SelectedValue?.ToString(); // Ülke kodu
            string sehirKodu = comboBox2.SelectedValue?.ToString(); // Şehir kodu

            // Form giriş kontrolü
            if (string.IsNullOrEmpty(firmaAdi) || string.IsNullOrEmpty(firmaKodu) || string.IsNullOrEmpty(ulkeKodu) || string.IsNullOrEmpty(sehirKodu))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Firma ekleme sorgusu
            string insertQuery = "INSERT INTO BSMGR0GEN001 (COMCODE, COMTEXT, ADDRESS1, ADDRESS2, CITYCODE, COUNTRYCODE) " +
                                 "VALUES (@FirmaKodu, @FirmaAdi, @FirmaAdresi, @FirmaAdresi2, @SehirKodu, @UlkeKodu)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Parametrelerin bağlanması
                        insertCommand.Parameters.AddWithValue("@FirmaKodu", firmaKodu);
                        insertCommand.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                        insertCommand.Parameters.AddWithValue("@FirmaAdresi", firmaAdresi);
                        insertCommand.Parameters.AddWithValue("@FirmaAdresi2", firmaAdresi2);
                        insertCommand.Parameters.AddWithValue("@SehirKodu", sehirKodu);
                        insertCommand.Parameters.AddWithValue("@UlkeKodu", ulkeKodu);

                        // Sorguyu çalıştır
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Firma başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Firma eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Seçilen şehir veya ülke kodu geçersiz. Lütfen doğru veriler seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Verileri göster formuna geçiş
            ViewData vd = new ViewData("BSMGR0GEN001");
            vd.Show();
            this.Hide();
        }

        private void LoadUlkeComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ülke verilerini al ve ComboBox'a ekle
                    string query = "SELECT COUNTRYCODE, COUNTRYTEXT FROM BSMGR0GEN003";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable countries = new DataTable();
                    adapter.Fill(countries);

                    comboBox1.DataSource = countries;
                    comboBox1.DisplayMember = "COUNTRYTEXT"; // Ülke ismi
                    comboBox1.ValueMember = "COUNTRYCODE"; // Ülke kodu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ülke verileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCityComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Şehir verilerini al ve ComboBox'a ekle
                    string query = "SELECT CITYCODE, CITYTEXT FROM BSMGR0GEN004";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable cities = new DataTable();
                    adapter.Fill(cities);

                    comboBox2.DataSource = cities;
                    comboBox2.DisplayMember = "CITYTEXT"; // Şehir ismi
                    comboBox2.ValueMember = "CITYCODE"; // Şehir kodu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şehir verileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Geri dönüş
            ViewData vd = new ViewData("BSMGR0GEN001");
            vd.Show();
            this.Hide();
        }
    }
}
