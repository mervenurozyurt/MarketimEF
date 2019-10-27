using MarketimEF.Data;
using MarketimEF.Data.Repository;
using MarketimEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Service
{
    public class SupplierService : BaseService, IService<SupplierDTO>
    {
        public List<SupplierDTO> List()
        {
            using (Repository<Supplier> repository = new Repository<Supplier>())
            {
                var entities = repository.List();

                List<SupplierDTO> suppliers = new List<SupplierDTO>();

                foreach (var item in entities)
                {
                    SupplierDTO supplier = Mapper.Map<Supplier, SupplierDTO>(item);

                    suppliers.Add(supplier);
                }

                return suppliers;
            }
        }

        public int Save(SupplierDTO supplierDTO)
        {
            using (Repository<Supplier> repository = new Repository<Supplier>())
            {
                var shipper = Mapper.Map<SupplierDTO, Supplier>(supplierDTO);
                shipper.RecordStatusId = 1;
                shipper.CreatedDate = DateTime.Now;

                return repository.Save(shipper);
            }
        }

        public int Update(SupplierDTO supplierDTO)
        {
            using (Repository<Supplier> repository = new Repository<Supplier>())
            {
                var supplier = Mapper.Map<SupplierDTO, Supplier>(supplierDTO);
                supplier.ModifiedDate = DateTime.Now;

                return repository.Update(supplier);
            }
        }

        public bool Delete(int supplierId)
        {
            using (Repository<Supplier> repository = new Repository<Supplier>())
            {
                return repository.Delete(supplierId);
            }
        }

        public SupplierDTO Get(int id)
        {
            using (Repository<Supplier> repository = new Repository<Supplier>())
            {
                var entity = repository.Get(id);

                var dto = Mapper.Map<Supplier, SupplierDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }
        }
    }
}
