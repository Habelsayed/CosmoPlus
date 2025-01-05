namespace CosmoPlus
{
    partial class MateryalEkleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFirma = new System.Windows.Forms.ComboBox();
            this.comboBoxMalzemeTipi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMateryalKodu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.radioSatinalinan = new System.Windows.Forms.RadioButton();
            this.radioUretilen = new System.Windows.Forms.RadioButton();
            this.comboBoxStokBirimi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericNetAgirlik = new System.Windows.Forms.NumericUpDown();
            this.comboBoxNetAgirlikBirimi = new System.Windows.Forms.ComboBox();
            this.numericBrutAgirlik = new System.Windows.Forms.NumericUpDown();
            this.comboBoxBrutAgirlikBirimi = new System.Windows.Forms.ComboBox();
            this.comboBoxUrunAgaci = new System.Windows.Forms.ComboBox();
            this.comboBoxRota = new System.Windows.Forms.ComboBox();
            this.buttonEkle = new System.Windows.Forms.Button();
            this.buttonGeri = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBoxPasif = new System.Windows.Forms.CheckBox();
            this.textBoxMalzemeAciklama = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericNetAgirlik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBrutAgirlik)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yeni Materyal ";
            // 
            // comboBoxFirma
            // 
            this.comboBoxFirma.FormattingEnabled = true;
            this.comboBoxFirma.Location = new System.Drawing.Point(278, 65);
            this.comboBoxFirma.Name = "comboBoxFirma";
            this.comboBoxFirma.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFirma.TabIndex = 1;
            // 
            // comboBoxMalzemeTipi
            // 
            this.comboBoxMalzemeTipi.FormattingEnabled = true;
            this.comboBoxMalzemeTipi.Location = new System.Drawing.Point(278, 105);
            this.comboBoxMalzemeTipi.Name = "comboBoxMalzemeTipi";
            this.comboBoxMalzemeTipi.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMalzemeTipi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "COMCODE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "MATDOCTYPE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "MATDOCNUM";
            // 
            // textBoxMateryalKodu
            // 
            this.textBoxMateryalKodu.Location = new System.Drawing.Point(278, 145);
            this.textBoxMateryalKodu.Name = "textBoxMateryalKodu";
            this.textBoxMateryalKodu.Size = new System.Drawing.Size(121, 20);
            this.textBoxMateryalKodu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Malzeme Stok Birimi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tedarik Tipi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Geçerlilik Bitiş";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Geçerlilik Başlangıç";
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(278, 186);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBaslangic.TabIndex = 11;
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Location = new System.Drawing.Point(278, 226);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBitis.TabIndex = 12;
            // 
            // radioSatinalinan
            // 
            this.radioSatinalinan.AutoSize = true;
            this.radioSatinalinan.Location = new System.Drawing.Point(278, 266);
            this.radioSatinalinan.Name = "radioSatinalinan";
            this.radioSatinalinan.Size = new System.Drawing.Size(77, 17);
            this.radioSatinalinan.TabIndex = 13;
            this.radioSatinalinan.TabStop = true;
            this.radioSatinalinan.Text = "Satinalinan";
            this.radioSatinalinan.UseVisualStyleBackColor = true;
            // 
            // radioUretilen
            // 
            this.radioUretilen.AutoSize = true;
            this.radioUretilen.Location = new System.Drawing.Point(417, 269);
            this.radioUretilen.Name = "radioUretilen";
            this.radioUretilen.Size = new System.Drawing.Size(61, 17);
            this.radioUretilen.TabIndex = 14;
            this.radioUretilen.TabStop = true;
            this.radioUretilen.Text = "Uretilen";
            this.radioUretilen.UseVisualStyleBackColor = true;
            // 
            // comboBoxStokBirimi
            // 
            this.comboBoxStokBirimi.FormattingEnabled = true;
            this.comboBoxStokBirimi.Location = new System.Drawing.Point(278, 307);
            this.comboBoxStokBirimi.Name = "comboBoxStokBirimi";
            this.comboBoxStokBirimi.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStokBirimi.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Rota Var Mı?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 519);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ürün Ağacı Var Mı?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 472);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Brüt Ağırlık Birimi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 424);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 25);
            this.label12.TabIndex = 19;
            this.label12.Text = "Brüt Ağırlık";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 382);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(171, 25);
            this.label13.TabIndex = 20;
            this.label13.Text = "Net Ağırlık Birimi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 25);
            this.label14.TabIndex = 21;
            this.label14.Text = "Net Ağırlık";
            // 
            // numericNetAgirlik
            // 
            this.numericNetAgirlik.Location = new System.Drawing.Point(279, 344);
            this.numericNetAgirlik.Name = "numericNetAgirlik";
            this.numericNetAgirlik.Size = new System.Drawing.Size(120, 20);
            this.numericNetAgirlik.TabIndex = 22;
            // 
            // comboBoxNetAgirlikBirimi
            // 
            this.comboBoxNetAgirlikBirimi.FormattingEnabled = true;
            this.comboBoxNetAgirlikBirimi.Location = new System.Drawing.Point(279, 386);
            this.comboBoxNetAgirlikBirimi.Name = "comboBoxNetAgirlikBirimi";
            this.comboBoxNetAgirlikBirimi.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNetAgirlikBirimi.TabIndex = 23;
            // 
            // numericBrutAgirlik
            // 
            this.numericBrutAgirlik.Location = new System.Drawing.Point(280, 429);
            this.numericBrutAgirlik.Name = "numericBrutAgirlik";
            this.numericBrutAgirlik.Size = new System.Drawing.Size(120, 20);
            this.numericBrutAgirlik.TabIndex = 24;
            // 
            // comboBoxBrutAgirlikBirimi
            // 
            this.comboBoxBrutAgirlikBirimi.FormattingEnabled = true;
            this.comboBoxBrutAgirlikBirimi.Location = new System.Drawing.Point(278, 476);
            this.comboBoxBrutAgirlikBirimi.Name = "comboBoxBrutAgirlikBirimi";
            this.comboBoxBrutAgirlikBirimi.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBrutAgirlikBirimi.TabIndex = 25;
            // 
            // comboBoxUrunAgaci
            // 
            this.comboBoxUrunAgaci.FormattingEnabled = true;
            this.comboBoxUrunAgaci.Location = new System.Drawing.Point(278, 523);
            this.comboBoxUrunAgaci.Name = "comboBoxUrunAgaci";
            this.comboBoxUrunAgaci.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUrunAgaci.TabIndex = 26;
            // 
            // comboBoxRota
            // 
            this.comboBoxRota.FormattingEnabled = true;
            this.comboBoxRota.Location = new System.Drawing.Point(278, 564);
            this.comboBoxRota.Name = "comboBoxRota";
            this.comboBoxRota.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRota.TabIndex = 27;
            // 
            // buttonEkle
            // 
            this.buttonEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEkle.Location = new System.Drawing.Point(230, 664);
            this.buttonEkle.Name = "buttonEkle";
            this.buttonEkle.Size = new System.Drawing.Size(125, 32);
            this.buttonEkle.TabIndex = 28;
            this.buttonEkle.Text = "Ekle";
            this.buttonEkle.UseVisualStyleBackColor = true;
            this.buttonEkle.Click += new System.EventHandler(this.buttonEkle_Click);
            // 
            // buttonGeri
            // 
            this.buttonGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGeri.Location = new System.Drawing.Point(361, 664);
            this.buttonGeri.Name = "buttonGeri";
            this.buttonGeri.Size = new System.Drawing.Size(125, 32);
            this.buttonGeri.TabIndex = 29;
            this.buttonGeri.Text = "Geri";
            this.buttonGeri.UseVisualStyleBackColor = true;
            this.buttonGeri.Click += new System.EventHandler(this.buttonGeri_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 610);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 25);
            this.label15.TabIndex = 30;
            this.label15.Text = "Pasif Mi?";
            // 
            // checkBoxPasif
            // 
            this.checkBoxPasif.AutoSize = true;
            this.checkBoxPasif.Location = new System.Drawing.Point(280, 616);
            this.checkBoxPasif.Name = "checkBoxPasif";
            this.checkBoxPasif.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPasif.TabIndex = 31;
            this.checkBoxPasif.UseVisualStyleBackColor = true;
            // 
            // textBoxMalzemeAciklama
            // 
            this.textBoxMalzemeAciklama.Location = new System.Drawing.Point(692, 105);
            this.textBoxMalzemeAciklama.Name = "textBoxMalzemeAciklama";
            this.textBoxMalzemeAciklama.Size = new System.Drawing.Size(100, 20);
            this.textBoxMalzemeAciklama.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(434, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(252, 25);
            this.label16.TabIndex = 33;
            this.label16.Text = "Malzeme Kısa Açıklaması";
            // 
            // MateryalEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 708);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxMalzemeAciklama);
            this.Controls.Add(this.checkBoxPasif);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonGeri);
            this.Controls.Add(this.buttonEkle);
            this.Controls.Add(this.comboBoxRota);
            this.Controls.Add(this.comboBoxUrunAgaci);
            this.Controls.Add(this.comboBoxBrutAgirlikBirimi);
            this.Controls.Add(this.numericBrutAgirlik);
            this.Controls.Add(this.comboBoxNetAgirlikBirimi);
            this.Controls.Add(this.numericNetAgirlik);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxStokBirimi);
            this.Controls.Add(this.radioUretilen);
            this.Controls.Add(this.radioSatinalinan);
            this.Controls.Add(this.dateTimePickerBitis);
            this.Controls.Add(this.dateTimePickerBaslangic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMateryalKodu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMalzemeTipi);
            this.Controls.Add(this.comboBoxFirma);
            this.Controls.Add(this.label1);
            this.Name = "MateryalEkleForm";
            this.Text = "MateryalEkleForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericNetAgirlik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBrutAgirlik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFirma;
        private System.Windows.Forms.ComboBox comboBoxMalzemeTipi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMateryalKodu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.RadioButton radioSatinalinan;
        private System.Windows.Forms.RadioButton radioUretilen;
        private System.Windows.Forms.ComboBox comboBoxStokBirimi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericNetAgirlik;
        private System.Windows.Forms.ComboBox comboBoxNetAgirlikBirimi;
        private System.Windows.Forms.NumericUpDown numericBrutAgirlik;
        private System.Windows.Forms.ComboBox comboBoxBrutAgirlikBirimi;
        private System.Windows.Forms.ComboBox comboBoxUrunAgaci;
        private System.Windows.Forms.ComboBox comboBoxRota;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.Button buttonGeri;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBoxPasif;
        private System.Windows.Forms.TextBox textBoxMalzemeAciklama;
        private System.Windows.Forms.Label label16;
    }
}