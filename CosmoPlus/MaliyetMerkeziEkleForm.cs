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
    public partial class MaliyetMerkeziEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public MaliyetMerkeziEkleForm()
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
            string COMCODE = "";
            if (string.IsNullOrEmpty(DOCTYPE) || string.IsNullOrEmpty(DOCTYPETEXT) || string.IsNullOrEmpty(COMTEXT))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // COMCODE almak için sorgu
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
                        MessageBox.Show("COMCODE değeri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Firma ekleme sorgusu
                    string insertQuery = "INSERT INTO BSMGR0CCM001 (COMCODE, DOCTYPE, DOCTYPETEXT , ISPASSIVE ) " +
                                         "VALUES (@COMCODE, @DOCTYPE, @DOCTYPETEXT , @ISPASSIVE)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    insertCommand.Parameters.Add("@COMCODE", SqlDbType.NVarChar).Value = COMCODE;
                    insertCommand.Parameters.Add("@DOCTYPE", SqlDbType.NVarChar).Value = DOCTYPE;
                    insertCommand.Parameters.Add("@DOCTYPETEXT", SqlDbType.NVarChar).Value = DOCTYPETEXT;
                    insertCommand.Parameters.Add("@ISPASSIVE", SqlDbType.Int).Value = ISPASSIVE;

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(" Maliyet İş Merkezi' başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Maliyet İş Merkezi eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ViewData vd = new ViewData("BSMGR0CCM001");
            vd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData("BSMGR0CCM001");
            vd.Show();
            this.Hide();
        }
    }
}
