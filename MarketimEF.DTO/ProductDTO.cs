using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class ProductDTO : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte CategoryId { get; set; }
        public int SupplierId { get; set; }
        public byte UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public byte RecordStatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }

        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string UnitName { get; set; }
        public string RecordStatusName { get; set; }
        public string CreatedByName { get; set; }
    }
}
