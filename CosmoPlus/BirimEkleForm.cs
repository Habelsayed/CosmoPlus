using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmoPlus
{
    public partial class BirimEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public BirimEkleForm()
        {
            InitializeComponent();
           // LoadFirmaCombobox();
        }
       // private void LoadFirmaCombobox()
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

        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
           // string COMTEXT = comboBox1.SelectedItem?.ToString();
            string UNITCODE = textBox1.Text.Trim();
            string UNITTEXT = textBox2.Text.Trim();
           // string COMCODE = "";

            if (string.IsNullOrEmpty(UNITCODE) || string.IsNullOrEmpty(UNITTEXT))//|| string.IsNullOrEmpty(COMTEXT
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
                string insertQuery = "INSERT INTO BSMGR0GEN005 (UNITCODE, UNITTEXT) " +
                                     "VALUES (@UNITCODE, @UNITTEXT)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

               // insertCommand.Parameters.Add("@COMCODE", SqlDbType.NVarChar).Value = COMCODE;
                insertCommand.Parameters.Add("@UNITCODE", SqlDbType.NVarChar).Value =UNITCODE;
                insertCommand.Parameters.Add("@UNITTEXT", SqlDbType.NVarChar).Value = UNITTEXT;

                int rowsAffected = insertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("BİRİM başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("BİRİRM eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ViewData vd = new ViewData("BSMGR0GEN005");
        vd.Show();
            this.Hide();
    }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData("BSMGR0GEN005");
            vd.Show();
            this.Hide();
        }
    }
}
