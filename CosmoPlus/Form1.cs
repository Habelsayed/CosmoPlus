using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bogus;

namespace CosmoPlus
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0GEN001");//firmalar
            viewData.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0GEN003");//ülkeler
            viewData.Show();
            this.Hide();


        }

        private void label9_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0GEN002");//diller
            viewData.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                // Simgeyi butona ekleme
                

        }

        private void label11_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0GEN004");//şehirler
            viewData.Show();
            this.Hide();
                
        }

        private void label15_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0GEN005");//birim
            viewData.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0CCM001");//maliyet merkezi
            viewData.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0MAT001");//malzeme tipi
            viewData.Show();
            this.Hide();


        }

        private void label10_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0BOM001");//ürün ağacı tipleri
            viewData.Show();
            this.Hide();

        }

        private void label12_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0ROT001");//rota tipleri
            viewData.Show();
            this.Hide();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0WCM001");//iş merkezi tipleri
            viewData.Show();
            this.Hide();


        }

        private void label14_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0OPR001");//operasyon tipi
            viewData.Show();
            this.Hide();

        }

        

        private void label16_Click_1(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0MATHEAD");
            viewData.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0CCMHEAD");
            viewData.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0WCMHEAD");
            viewData.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewData viewData = new ViewData("BSMGR0ROTOPRCONTENT");
            viewData.Show();
            this.Hide();
        }
    }
}
