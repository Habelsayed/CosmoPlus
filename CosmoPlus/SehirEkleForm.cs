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
    public partial class SehirEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public SehirEkleForm()
        {
            InitializeComponent();
            LoadFirmaCombobox();
        }

        private void SehirEkleForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadFirmaCombobox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //// İlk sorgu için SqlCommand ve DataReader
                    //string query = "SELECT COMTEXT FROM BSMGR0GEN001";
                    //using (SqlCommand command = new SqlCommand(query, connection))
                    //using (SqlDataReader reader = command.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        comboBox1.Items.Add(reader["COMTEXT"].ToString());
                    //    }
                    //}

                    // İkinci sorgu için SqlCommand ve DataReader
                    string query2 = "SELECT COUNTRYTEXT FROM BSMGR0GEN003";
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            comboBox2.Items.Add(reader2["COUNTRYTEXT"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewData vd = new ViewData("BSMGR0GEN004");  // Burada "BSMGR0GEN001" istediğiniz tablo adını temsil eder
            vd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  string COMTEXT = comboBox1.SelectedItem?.ToString();
            string CITYCODE = textBox1.Text.Trim();
            string CITYTEXT = textBox2.Text.Trim();
            string COUNTRYTEXT = comboBox2.SelectedItem?.ToString();
            string COUNTRYCODE = "";
            // string COMCODE = "";
         

            if (string.IsNullOrEmpty(CITYCODE) || string.IsNullOrEmpty(CITYTEXT) || string.IsNullOrEmpty(COUNTRYTEXT))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string KodQuery = "SELECT COUNTRYCODE FROM BSMGR0GEN003 WHERE COUNTRYTEXT = @COUNTRYTEXT";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand KodCommand = new SqlCommand(KodQuery, connection);
                    KodCommand.Parameters.Add("@COUNTRYTEXT", SqlDbType.NVarChar).Value = COUNTRYTEXT;

                    SqlDataReader reader = KodCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        COUNTRYCODE = reader["COUNTRYCODE"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("COUNTRYCODE değeri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    reader.Close();

                    string insertQuery = "INSERT INTO BSMGR0GEN004 (CITYCODE, CITYTEXT, COUNTRYCODE) VALUES (@CITYCODE, @CITYTEXT, @COUNTRYCODE)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    insertCommand.Parameters.Add("@CITYCODE", SqlDbType.NVarChar).Value = CITYCODE;
                    insertCommand.Parameters.Add("@CITYTEXT", SqlDbType.NVarChar).Value = CITYTEXT;
                    insertCommand.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar).Value = COUNTRYCODE;

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Şehir başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Şehir eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ViewData vd = new ViewData("BSMGR0GEN004");
            vd.Show();
            this.Hide();
        }
    }
}
