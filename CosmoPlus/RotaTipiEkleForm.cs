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

namespace CosmoPlus
{
    public partial class RotaTipiEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public RotaTipiEkleForm()
        {
            InitializeComponent();
            LoadFirmaCombobox();

        }
        private void LoadFirmaCombobox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // İlk sorgu için SqlCommand ve DataReader
                    string query = "SELECT COMTEXT FROM BSMGR0GEN001";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["COMTEXT"].ToString());
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            comboBox2.Items.Add(new KeyValuePair<string, int>("Evet", 1));
            comboBox2.Items.Add(new KeyValuePair<string, int>("Hayır", 0));

            // ComboBox'un DisplayMember ve ValueMember ayarlarını yap
            comboBox2.DisplayMember = "Key"; // Görünen değer
            comboBox2.ValueMember = "Value"; // Veritabanına gönderilecek değer

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string COMTEXT = comboBox1.SelectedItem?.ToString();
            string DOCTYPE = textBox1.Text.Trim();
            string DOCTYPETEXT = textBox2.Text.Trim();
            int ISPASSIVE = (comboBox2.SelectedItem?.ToString() == "Evet") ? 1 : 0;
            string COMCODE = null; // Varsayılan olarak null

            // Sadece DOCTYPE ve DOCTYPETEXT zorunlu alanlar olarak kontrol ediliyor
            if (string.IsNullOrEmpty(DOCTYPE) || string.IsNullOrEmpty(DOCTYPETEXT))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // COMTEXT seçilmişse, COMCODE değerini al
            if (!string.IsNullOrEmpty(COMTEXT))
            {
                string KodQuery = "SELECT COMCODE FROM BSMGR0GEN001 WHERE UPPER(COMTEXT) = UPPER(@COMTEXT)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // COMCODE değerini al
                        SqlCommand ulkeKoduCommand = new SqlCommand(KodQuery, connection);
                        ulkeKoduCommand.Parameters.Add("@COMTEXT", SqlDbType.NVarChar).Value = COMTEXT;
                        COMCODE = ulkeKoduCommand.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(COMCODE))
                        {
                            MessageBox.Show("Seçilen COMTEXT için COMCODE bulunamadı. COMCODE olmadan devam ediliyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("COMCODE alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Veriyi tabloya ekle
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO BSMGR0ROT001 (COMCODE, DOCTYPE, DOCTYPETEXT, ISPASSIVE) " +
                                         "VALUES (@COMCODE, @DOCTYPE, @DOCTYPETEXT, @ISPASSIVE)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    // COMCODE null ise veritabanına NULL gönderilir
                    insertCommand.Parameters.Add("@COMCODE", SqlDbType.NVarChar).Value = (object)COMCODE ?? DBNull.Value;
                    insertCommand.Parameters.Add("@DOCTYPE", SqlDbType.NVarChar).Value = DOCTYPE;
                    insertCommand.Parameters.Add("@DOCTYPETEXT", SqlDbType.NVarChar).Value = DOCTYPETEXT;
                    insertCommand.Parameters.Add("@ISPASSIVE", SqlDbType.Int).Value = ISPASSIVE;

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rota Tipi başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Rota Tipi eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        


        ViewData vd = new ViewData("BSMGR0ROT001");
            vd.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData("BSMGR0ROT001");
            vd.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
