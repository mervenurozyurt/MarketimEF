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
    public class EmployeeService : BaseService, IService<EmployeeDTO>
    {
        public bool Delete(int id)
        {
            using (Repository<Employee> repository = new Repository<Employee>())
            {
                return repository.Delete(id);
            }
        }

        public EmployeeDTO Get(int id)
        {
            using (Repository<Employee> repository = new Repository<Employee>())
            {
                var entity = repository.Get(id);

                var dto = Mapper.Map<Employee, EmployeeDTO>(entity);
                dto.DepartmentName = entity.Position.Department.DepartmentName;
                dto.PositionName = entity.Position.PositionName;
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }
        }

        public List<EmployeeDTO> List()
        {
            using (Repository<Employee> repository = new Repository<Employee>())
            {
                var entities = repository.List();

                List<EmployeeDTO> employees = new List<EmployeeDTO>();

                foreach (var item in entities)
                {
                    EmployeeDTO customer = new EmployeeDTO
                    {
                        EmployeeId = item.EmployeeId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        MobilePhone = item.MobilePhone,
                        DepartmentName = item.Position.Department.DepartmentName,
                        PositionName = item.Position.PositionName,
                        RecordStatusName = item.RecordStatus.RecordStatusName
                    };

                    employees.Add(customer);
                }

                return employees;
            }
        }

        public int Save(EmployeeDTO obj)
        {
            using (Repository<Employee> repository = new Repository<Employee>())
            {
                var entity = Mapper.Map<EmployeeDTO, Employee>(obj);
                entity.RecordStatusId = 1;
                entity.CreatedDate = DateTime.Now;

                return repository.Save(entity);
            }
        }

        public int Update(EmployeeDTO obj)
        {
            using (Repository<Employee> repository = new Repository<Employee>())
            {
                var entity = Mapper.Map<EmployeeDTO, Employee>(obj);
                entity.ModifiedDate = DateTime.Now;

                return repository.Update(entity);
            }
        }
    }
}
