using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CosmoPlus
{
    public partial class DilEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public DilEkleForm()
        {
            InitializeComponent();
        //    LoadFirmaCombobox();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DilEkleForm_Load(object sender, EventArgs e)
        {
            
        }
        //private void LoadFirmaCombobox()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            // İlk sorgu için SqlCommand ve DataReader
        //            string query = "SELECT COMTEXT FROM BSMGR0GEN001";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    comboBox1.Items.Add(reader["COMTEXT"].ToString());
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
            
        //}
        //}

            private void button1_Click(object sender, EventArgs e)
        {
          //  string COMTEXT = comboBox1.SelectedItem?.ToString();
            string LANCODE = textBox1.Text.Trim();
            string LANTEXT = textBox2.Text.Trim();
            //  string COMCODE = "";

            if (string.IsNullOrEmpty(LANCODE) || string.IsNullOrEmpty(LANTEXT) ) //|| string.IsNullOrEmpty(COMTEXT))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // COMCODE almak için sorgu
           // string KodQuery = "SELECT COMCODE FROM BSMGR0GEN001 WHERE UPPER(COMTEXT) = UPPER(@COMTEXT)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                try
                {
                    connection.Open();

                    // COMCODE değerini al
                    //SqlCommand ulkeKoduCommand = new SqlCommand(KodQuery, connection);
                    //ulkeKoduCommand.Parameters.Add("@COMTEXT", SqlDbType.NVarChar).Value = COMTEXT;
                    //COMCODE = ulkeKoduCommand.ExecuteScalar()?.ToString();

                    //if (string.IsNullOrEmpty(COMCODE))
                    //{
                    //    MessageBox.Show("COMCODE değeri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    // Firma ekleme sorgusu
                    string insertQuery = "INSERT INTO BSMGR0GEN002 ( LANCODE, LANTEXT) " +
                                         "VALUES ( @LANCODE, @LANTEXT)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                 //   insertCommand.Parameters.Add("@COMCODE", SqlDbType.NVarChar).Value = COMCODE;
                    insertCommand.Parameters.Add("@LANCODE", SqlDbType.NVarChar).Value = LANCODE;
                    insertCommand.Parameters.Add("@LANTEXT", SqlDbType.NVarChar).Value = LANTEXT;

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dil başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dil eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ViewData vd = new ViewData("BSMGR0GEN002");
            vd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData("BSMGR0GEN002");
            vd.Show();
            this.Hide();
        }
    }
}
