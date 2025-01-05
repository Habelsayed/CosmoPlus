using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace CosmoPlus
{
    public partial class ViewData : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private string _tableName; // Hangi tabloyu göstereceğimizi tutar

        private Dictionary<string, string> tableDisplayNames = new Dictionary<string, string>
        {
            { "BSMGR0GEN001", "FİRMALAR" },
            { "BSMGR0GEN003", "ÜLKELER" },
            { "BSMGR0GEN004", "ŞEHİRLER" },
            { "BSMGR0GEN005", "BİRİMLER" },
            { "BSMGR0GEN002", "DİLLER" },
            { "BSMGR0MAT001", "MALZEME TİPLERİ" },
            { "BSMGR0BOM001", "ÜRÜN AĞACI TİPLERİ" },
            { "BSMGR0ROT001", "ROTA TİPLERİ" },
            { "BSMGR0WCM001", "İŞ MERKEZİ TİPLERİ" },
            { "BSMGR0OPR001", "OPERASYON TİPLERİ" },
            { "BSMGR0CCM001", "MALİYET MERKEZLERİ" },
            { "BSMGR0MATHEAD", "Materyal" },
            { "BSMGR0WCMHEAD", "İş Merkezi" },
            { "BSMGR0ROTOPRCONTENT", "Rota Yönetimi" },
            { "BSMGR0CCMHEAD", "Maliyet" }
        };

        public ViewData(string tableName)
        {
            InitializeComponent();
            _tableName = tableName;
            UpdateLabel(_tableName);
        }

        // Label'i güncelle
        public void UpdateLabel(string tableName)
        {
            if (tableDisplayNames.ContainsKey(tableName))
            {
                label1.Text = tableDisplayNames[tableName];
            }
            else
            {
                label1.Text = "Bilinmeyen Tablo";
            }
        }

        private void ViewData_Load(object sender, EventArgs e)
        {
            // Label'i güncelle
            UpdateLabel(_tableName);


            // Attach event for handling Expand/Collapse
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        // Verileri yüklemek için buton
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM {_tableName}"; // Sorguyu oluştur

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    // Add Expand/Collapse column for Materyal table
                    if (_tableName == "BSMGR0MATHEAD" && !dataGridView1.Columns.Contains("Expand"))
                    {
                        DataGridViewButtonColumn expandButton = new DataGridViewButtonColumn();
                        expandButton.HeaderText = "Expand";
                        expandButton.Name = "Expand";
                        expandButton.Text = ">";
                        expandButton.UseColumnTextForButtonValue = true;
                        dataGridView1.Columns.Add(expandButton);
                    }
                    // Verileri DataGridView'e bağla
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle DataGridView Button Clicks
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_tableName == "BSMGR0MATHEAD" && e.ColumnIndex == dataGridView1.Columns["Expand"].Index)
            {
                // Get the primary key values for the clicked row
                string matDocNum = dataGridView1.Rows[e.RowIndex].Cells["MATDOCNUM"].Value?.ToString();
                string matDocType = dataGridView1.Rows[e.RowIndex].Cells["MATDOCTYPE"].Value?.ToString();

                if (string.IsNullOrEmpty(matDocNum) || string.IsNullOrEmpty(matDocType))
                {
                    MessageBox.Show("Malzeme bilgisi eksik. Lütfen doğru verileri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch and display the linked data
                ShowLinkedData(matDocNum, matDocType);
            }
        }

        private void ShowLinkedData(string matDocNum, string matDocType)
        {
            string query = @"SELECT LANCODE, MATSTEXT 
                     FROM BSMGR0MATTEXT 
                     WHERE MATDOCNUM = @MATDOCNUM AND MATDOCTYPE = @MATDOCTYPE";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@MATDOCNUM", matDocNum);
                    command.Parameters.AddWithValue("@MATDOCTYPE", matDocType);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable linkedData = new DataTable();
                    adapter.Fill(linkedData);

                    if (linkedData.Rows.Count > 0)
                    {
                        // Show data in a new form or panel
                        Form linkedDataForm = new Form
                        {
                            Text = "Ek Bilgiler",
                            Size = new Size(400, 300),
                            StartPosition = FormStartPosition.CenterParent
                        };

                        DataGridView linkedDataGrid = new DataGridView
                        {
                            Dock = DockStyle.Fill,
                            DataSource = linkedData,
                            ReadOnly = true
                        };

                        linkedDataForm.Controls.Add(linkedDataGrid);
                        linkedDataForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bu malzeme için ek açıklama bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek veriler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteRecordFromMainTable(string comCode, int selectedRowIndex)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "DELETE FROM BSMGR0GEN001 WHERE COMCODE = @COMCODE";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@COMCODE", comCode);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // DataGridView'den satırı sil
                                dataGridView1.Rows.RemoveAt(selectedRowIndex);
                            }
                            else
                            {
                                MessageBox.Show("Silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Seçilen satırı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string comCode = dataGridView1.Rows[selectedRowIndex].Cells["COMCODE"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteRecordFromMainTable(comCode, selectedRowIndex);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            switch (_tableName)
            {
                case "BSMGR0GEN001": // FİRMALAR
                    FirmaEkleForm firmaEkleForm = new FirmaEkleForm();
                    firmaEkleForm.ShowDialog();
                    break;

                case "BSMGR0GEN003": // ÜLKELER
                    UlkeEkleForm ulkeEkleForm = new UlkeEkleForm();
                    ulkeEkleForm.ShowDialog();
                    break;

                case "BSMGR0GEN002": // DİLLER
                    DilEkleForm dilEkleForm = new DilEkleForm();
                    dilEkleForm.ShowDialog();
                    break;

                case "BSMGR0GEN004": // ŞEHİRLER
                    SehirEkleForm sehirEkleForm = new SehirEkleForm();
                    sehirEkleForm.ShowDialog();
                    break;

                case "BSMGR0GEN005": // BİRİMLER
                    BirimEkleForm birimEkleForm = new BirimEkleForm();
                    birimEkleForm.ShowDialog();
                    break;

                case "BSMGR0CCM001": // MALİYET MERKEZLERİ
                    MaliyetMerkeziEkleForm maliyetMerkeziEkleForm = new MaliyetMerkeziEkleForm();
                    maliyetMerkeziEkleForm.ShowDialog();
                    break;

                case "BSMGR0MAT001": // MALZEME TİPLERİ
                    MalzemeTipiEkleForm malzemeTipiEkleForm = new MalzemeTipiEkleForm();
                    malzemeTipiEkleForm.ShowDialog();
                    break;

                case "BSMGR0BOM001": // ÜRÜN AĞACI TİPLERİ
                    UrunAgaciTipiEkleForm urunAgaciTipiEkleForm = new UrunAgaciTipiEkleForm();
                    urunAgaciTipiEkleForm.ShowDialog();
                    break;

                case "BSMGR0ROT001": // ROTA TİPLERİ
                    RotaTipiEkleForm rotaTipiEkleForm = new RotaTipiEkleForm();
                    rotaTipiEkleForm.ShowDialog();
                    break;

                case "BSMGR0WCM001": // İŞ MERKEZİ TİPLERİ
                    IsMerkeziTipiEkleForm isMerkeziTipiEkleForm = new IsMerkeziTipiEkleForm();
                    isMerkeziTipiEkleForm.ShowDialog();
                    break;

                case "BSMGR0OPR001": // OPERASYON TİPLERİ
                    OperasyonTipiEkleForm operasyonTipiEkleForm = new OperasyonTipiEkleForm();
                    operasyonTipiEkleForm.ShowDialog();
                    break;

                case "BSMGR0MATHEAD":
                    MateryalEkleForm materyalEklaForm = new MateryalEkleForm();
                    materyalEklaForm.ShowDialog();
                    break;

                default:
                    MessageBox.Show("Bu tablo için bir form tanımlı değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Close();
        }

        
    }
}
