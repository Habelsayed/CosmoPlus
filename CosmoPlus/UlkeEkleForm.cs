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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CosmoPlus
{
    public partial class UlkeEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public UlkeEkleForm()
        {
            InitializeComponent();
          //  LoadUlkeCombobox();

        }

        
        //private void LoadUlkeCombobox()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // Ulke tablosundan verileri al
        //            string query = "SELECT COMCODE, COMTEXT FROM BSMGR0GEN001"; // Tablo adınızı ve sütun adınızı ayarlayın
        //            SqlCommand command = new SqlCommand(query, connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            // ComboBox'a verileri ekle
        //            while (reader.Read())
        //            {
        //                comboBox1.Items.Add(reader["COMTEXT"].ToString());
        //            }

        //            reader.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
        //    }




        //}

        private void button1_Click(object sender, EventArgs e)
        {
           // string COMTEXT = comboBox1.SelectedItem?.ToString();
            string COUNTRYCODE = textBox1.Text;
            string COUNTRYTEXT = textBox2.Text;
           // string COMCODE = "";

            if (string.IsNullOrEmpty(COUNTRYCODE) || string.IsNullOrEmpty(COUNTRYTEXT))//|| string.IsNullOrEmpty(COMTEXT))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          //  string ulkeKoduQuery = "SELECT COMCODE FROM BSMGR0GEN001 WHERE COMTEXT = @COMTEXT";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //// COMCODE değerini al
                    //SqlCommand ulkeKoduCommand = new SqlCommand(ulkeKoduQuery, connection);
                    //ulkeKoduCommand.Parameters.Add("@COMTEXT", SqlDbType.NVarChar).Value = COMTEXT;
                    //COMCODE = ulkeKoduCommand.ExecuteScalar()?.ToString();

                    //if (string.IsNullOrEmpty(COMCODE))
                    //{
                    //    MessageBox.Show("COMCODE değeri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    // Firma ekleme sorgusu
                    string insertQuery = "INSERT INTO BSMGR0GEN003 ( COUNTRYCODE, COUNTRYTEXT) " +
                                         "VALUES ( @COUNTRYCODE, @COUNTRYTEXT)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                   // insertCommand.Parameters.Add("@COMCODE", SqlDbType.NVarChar).Value = COMCODE;
                    insertCommand.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar).Value = COUNTRYCODE;
                    insertCommand.Parameters.Add("@COUNTRYTEXT", SqlDbType.NVarChar).Value = COUNTRYTEXT;

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ülke başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ülke eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ViewData vd = new ViewData("BSMGR0GEN003");
            vd.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewData vd = new ViewData("BSMGR0GEN003");  // Burada "BSMGR0GEN001" istediğiniz tablo adını temsil eder
            vd.Show();
        }
    }
}
