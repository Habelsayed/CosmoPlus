using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CosmoPlus
{
    public partial class MateryalEkleForm : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public MateryalEkleForm()
        {
            InitializeComponent();
            LoadFirmaComboBox();
            LoadMalzemeTipiComboBox();
            LoadStokBirimiComboBox();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            // Collect data from the form
            string firmaKodu = comboBoxFirma.SelectedValue?.ToString();
            string malzemeTipi = comboBoxMalzemeTipi.SelectedValue?.ToString();
            string malzemeKodu = textBoxMateryalKodu.Text.Trim();
            string stokBirimi = comboBoxStokBirimi.SelectedValue?.ToString();
            string netAgirlikBirimi = comboBoxNetAgirlikBirimi.SelectedValue?.ToString();
            string brutAgirlikBirimi = comboBoxBrutAgirlikBirimi.SelectedValue?.ToString();
            decimal netAgirlik = numericNetAgirlik.Value;
            decimal brutAgirlik = numericBrutAgirlik.Value;
            bool isPassive = checkBoxPasif.Checked;

            if (string.IsNullOrEmpty(firmaKodu) || string.IsNullOrEmpty(malzemeTipi) || string.IsNullOrEmpty(malzemeKodu))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert into BSMGR0MATHEAD table
                    string queryMatHead = @"
                        INSERT INTO BSMGR0MATHEAD 
                        (COMCODE, MATDOCTYPE, MATDOCNUM, STUNIT, NETWEIGHT, NWUNIT, BRUTWEIGHT, BWUNIT, ISPASSIVE) 
                        VALUES (@COMCODE, @MATDOCTYPE, @MATDOCNUM, @STUNIT, @NETWEIGHT, @NWUNIT, @BRUTWEIGHT, @BWUNIT, @ISPASSIVE)";

                    using (SqlCommand cmdHead = new SqlCommand(queryMatHead, connection))
                    {
                        cmdHead.Parameters.AddWithValue("@COMCODE", firmaKodu);
                        cmdHead.Parameters.AddWithValue("@MATDOCTYPE", malzemeTipi);
                        cmdHead.Parameters.AddWithValue("@MATDOCNUM", malzemeKodu);
                        cmdHead.Parameters.AddWithValue("@STUNIT", stokBirimi);
                        cmdHead.Parameters.AddWithValue("@NETWEIGHT", netAgirlik);
                        cmdHead.Parameters.AddWithValue("@NWUNIT", netAgirlikBirimi);
                        cmdHead.Parameters.AddWithValue("@BRUTWEIGHT", brutAgirlik);
                        cmdHead.Parameters.AddWithValue("@BWUNIT", brutAgirlikBirimi);
                        cmdHead.Parameters.AddWithValue("@ISPASSIVE", isPassive);

                        cmdHead.ExecuteNonQuery();
                    }

                    // Optional: Insert into BSMGR0MATTEXT if there's additional descriptive data
                    string malzemeAciklama = textBoxMalzemeAciklama.Text.Trim();
                    if (!string.IsNullOrEmpty(malzemeAciklama))
                    {
                        string queryMatText = @"
                            INSERT INTO BSMGR0MATTEXT 
                            (MATDOCTYPE, MATDOCNUM, MATSTEXT) 
                            VALUES (@MATDOCTYPE, @MATDOCNUM, @MATSTEXT)";

                        using (SqlCommand cmdText = new SqlCommand(queryMatText, connection))
                        {
                            cmdText.Parameters.AddWithValue("@MATDOCTYPE", malzemeTipi);
                            cmdText.Parameters.AddWithValue("@MATDOCNUM", malzemeKodu);
                            cmdText.Parameters.AddWithValue("@MATSTEXT", malzemeAciklama);

                            cmdText.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Materyal başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirmaComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COMCODE, COMTEXT FROM BSMGR0GEN001";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable firmaTable = new DataTable();
                    adapter.Fill(firmaTable);
                    comboBoxFirma.DataSource = firmaTable;
                    comboBoxFirma.DisplayMember = "COMTEXT";
                    comboBoxFirma.ValueMember = "COMCODE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firma bilgileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMalzemeTipiComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DOCTYPE, DOCTYPETEXT FROM BSMGR0MAT001";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable malzemeTipiTable = new DataTable();
                    adapter.Fill(malzemeTipiTable);
                    comboBoxMalzemeTipi.DataSource = malzemeTipiTable;
                    comboBoxMalzemeTipi.DisplayMember = "DOCTYPETEXT";
                    comboBoxMalzemeTipi.ValueMember = "DOCTYPE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Malzeme tipi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStokBirimiComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UNITCODE, UNITTEXT FROM BSMGR0GEN005";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable stokBirimiTable = new DataTable();
                    adapter.Fill(stokBirimiTable);
                    comboBoxStokBirimi.DataSource = stokBirimiTable.Copy();
                    comboBoxStokBirimi.DisplayMember = "UNITTEXT";
                    comboBoxStokBirimi.ValueMember = "UNITCODE";

                    comboBoxNetAgirlikBirimi.DataSource = stokBirimiTable.Copy();
                    comboBoxNetAgirlikBirimi.DisplayMember = "UNITTEXT";
                    comboBoxNetAgirlikBirimi.ValueMember = "UNITCODE";

                    comboBoxBrutAgirlikBirimi.DataSource = stokBirimiTable.Copy();
                    comboBoxBrutAgirlikBirimi.DisplayMember = "UNITTEXT";
                    comboBoxBrutAgirlikBirimi.ValueMember = "UNITCODE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok birimi yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void buttonGeri_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData("BSMGR0MATHEAD");
            vd.Show();
            this.Hide();
        }

       
    }
}
