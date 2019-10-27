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
    public class ProductService : BaseService, IService<ProductDTO>
    {
        /*
* Arayüz ve Data layer arasında DTO nesneleri aracılığıyla veri taşınması ve businees logic işlevini görür.
*/

        public List<ProductDTO> List()
        {
            using (Repository<Product> repository = new Repository<Product>())
            {
                var products = repository.List();

                //List<Product> -> List<ProductDTO>

                List<ProductDTO> productList = new List<ProductDTO>();

                foreach (var item in products)
                {
                    ProductDTO product = Mapper.Map<Product, ProductDTO>(item);

                    product.ProductName = item.ProductName;
                    product.CategoryName = item.Category.CategoryName;
                    product.SupplierName = item.Supplier.CompanyName;
                    product.UnitName = item.Unit.UnitName;
                    product.RecordStatusName = item.RecordStatus.RecordStatusName;
                    // Ternary If
                    product.CreatedByName = item.CreatedBy != null ? item.Employee.FirstName + " " + item.Employee.LastName : "-";

                    productList.Add(product);
                }

                return productList;
            }
        }

        public int Save(ProductDTO productDTO)
        {
            using (Repository<Product> repository = new Repository<Product>())
            {
                Product productEntity = Mapper.Map<ProductDTO, Product>(productDTO);

                productEntity.RecordStatusId = 1;
                productEntity.CreatedDate = DateTime.Now;

                int affected = repository.Save(productEntity);

                return affected;
            }
        }

        public int Update(ProductDTO productDTO)
        {
            using (Repository<Product> repository = new Repository<Product>())
            {
                Product productEntity = Mapper.Map<ProductDTO, Product>(productDTO);

                productEntity.ModifiedDate = DateTime.Now;

                int affected = repository.Update(productEntity);

                return affected;
            }
        }

        public bool Delete(int productId)
        {
            using (Repository<Product> repository = new Repository<Product>())
            {
                return repository.Delete(productId);
            }
        }

        public ProductDTO Get(int id)
        {
            using (Repository<Product> repository = new Repository<Product>())
            {
                var entity = repository.Get(id);

                var dto = Mapper.Map<Product, ProductDTO>(entity);

                dto.CategoryName = entity.Category.CategoryName;
                dto.SupplierName = entity.Supplier.CompanyName;
                dto.UnitName = entity.Unit.UnitName;
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }
        }
    }
}
