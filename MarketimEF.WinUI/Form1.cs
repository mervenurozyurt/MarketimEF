using MarketimEF.Service;
using System;
using System.Windows.Forms;

namespace MarketimEF.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ProductService service = new ProductService())
            {
                var products = service.List();

                dataGridView1.DataSource = products;
            }
        }
    }
}
