using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class EmployeeDTO : IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public short PositionId { get; set; }
        public decimal Salary { get; set; }
        public byte RecordStatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }

        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string RecordStatusName { get; set; }
    }
}
