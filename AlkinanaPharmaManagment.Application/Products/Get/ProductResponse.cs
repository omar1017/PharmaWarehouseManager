using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public class ProductResponse
    {
        public ProductId ProductId { get; set; }
        public ProductName ProductName { get; set; }
        public ProductImage ProductImage { get; set; }
        public CompanyName CompanyName { get; set; }
        public Description Description { get; set; }
        public Price Price { get; set; }
        public Supplier Supplier { get; set; }
    }
}