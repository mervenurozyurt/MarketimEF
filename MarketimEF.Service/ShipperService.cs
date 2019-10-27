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
    public class ShipperService : BaseService, IService<ShipperDTO>
    {
        public bool Delete(int id)
        {
            using (Repository<Shipper> repository = new Repository<Shipper>())
            {
                return repository.Delete(id);
            }
        }

        public List<ShipperDTO> List()
        {
            using (Repository<Shipper> repository = new Repository<Shipper>())
            {
                var shippers = repository.List();

                List<ShipperDTO> shipperList = new List<ShipperDTO>();

                foreach (var item in shippers)
                {
                    ShipperDTO shipper = Mapper.Map<Shipper, ShipperDTO>(item);

                    shipperList.Add(shipper);
                }

                return shipperList;
            }
        }

        public int Save(ShipperDTO obj)
        {
            using (Repository<Shipper> repository = new Repository<Shipper>())
            {
                var shipper = Mapper.Map<ShipperDTO, Shipper>(obj);
                shipper.RecordStatusId = 1;
                shipper.CreatedDate = DateTime.Now;

                return repository.Save(shipper);
            }
        }

        public int Update(ShipperDTO obj)
        {
            using (Repository<Shipper> repository = new Repository<Shipper>())
            {
                var shipper = Mapper.Map<ShipperDTO, Shipper>(obj);
                shipper.ModifiedDate = DateTime.Now;

                return repository.Update(shipper);
            }
        }

        public ShipperDTO Get(int id)
        {
            using (Repository<Shipper> repository = new Repository<Shipper>())
            {
                var entity = repository.Get(id);

                var dto = Mapper.Map<Shipper, ShipperDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }
        }
    }
}
