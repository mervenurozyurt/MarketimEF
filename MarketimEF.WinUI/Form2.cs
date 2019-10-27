using MarketimEF.Data;
using MarketimEF.DTO;
using MarketimEF.Service;
using System;
using System.Windows.Forms;

namespace MarketimEF.WinUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * 1) Arayüzde data işlemi yapıyorum. 
             * 2) Yeniden kullanılabilirlik yok.
             * 3) ProductDTO-> Product || Product->ProductDTO mapping tekrarı var. 
             */
            using (ProductService service = new ProductService())
            {
                ProductDTO productDTO = new ProductDTO
                {
                    ProductName = txtProductName.Text,
                    CategoryId = Convert.ToByte(txtCategoryId.Text),
                    SupplierId = Convert.ToByte(txtSupplierId.Text),
                    UnitId = Convert.ToByte(txtUnitId.Text),
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    UnitsInStock = Convert.ToInt32(txtUnitInStock.Text),
                    RecordStatusId = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                };

                int affected = service.Save(productDTO);
            }
        }
    }
}
