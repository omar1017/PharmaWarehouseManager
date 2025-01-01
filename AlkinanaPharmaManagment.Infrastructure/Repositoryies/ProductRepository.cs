using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Repositoryies
{
    internal class ProductRepository : IProductRepository
    {
        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProductId productId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(ProductId productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCompany(string companyName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsBySupplier(string supplierName)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
