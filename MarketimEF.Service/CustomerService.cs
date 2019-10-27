using MarketimEF.Data;
using MarketimEF.Data.Repository;
using MarketimEF.DTO;
using System;
using System.Collections.Generic;

namespace MarketimEF.Service
{
    public class CustomerService : BaseService, IService<CustomerDTO>
    {
        public bool Delete(int id)
        {
            using (Repository<Customer> repository = new Repository<Customer>())
            {
                return repository.Delete(id);
            }
        }

        public CustomerDTO Get(int id)
        {
            using (Repository<Customer> repository = new Repository<Customer>())
            {
                var entity = repository.Get(id);

                var dto = Mapper.Map<Customer, CustomerDTO>(entity);
                dto.CityName = entity.Town.City.CityName;
                dto.TownName = entity.Town.TownName;

                return dto;
            }
        }

        public List<CustomerDTO> List()
        {
            using (Repository<Customer> repository = new Repository<Customer>())
            {
                var entities = repository.List();

                List<CustomerDTO> customers = new List<CustomerDTO>();

                foreach (var item in entities)
                {
                    CustomerDTO customer = new CustomerDTO
                    {
                        CustomerId = item.CustomerId,
                        CompanyName = item.CompanyName,
                        ContactName = item.ContactName,
                        CityName = item.Town.City.CityName,
                        TownName = item.Town.TownName,
                        Phone = item.Phone
                    };

                    customers.Add(customer);
                }

                return customers;
            }
        }

        public int Save(CustomerDTO obj)
        {
            using (Repository<Customer> repository = new Repository<Customer>())
            {
                var entity = Mapper.Map<CustomerDTO, Customer>(obj);
                entity.RecordStatusId = 1;
                entity.CreatedDate = DateTime.Now;

                return repository.Save(entity);
            }
        }

        public int Update(CustomerDTO obj)
        {
            using (Repository<Customer> repository = new Repository<Customer>())
            {
                var entity = Mapper.Map<CustomerDTO, Customer>(obj);
                entity.ModifiedDate = DateTime.Now;

                return repository.Update(entity);
            }
        }
    }
}
