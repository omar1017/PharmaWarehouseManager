
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities
{
    public class Product : AggregateRoot
    {
        public ProductId ProductId { get; private set; }
        public ProductName name {get; private set;}

        public ProductImage image {get; private set;}

        public CompanyName companyName {get; private set;}

        public Description description {get; private set;}

        public Price price {get; private set;}

        public Supplier supplier {get; private set;}

        public string CreatedBy {get; private set;}

        public static Product CreateProduct(ProductName productName,
            ProductImage productImage,
            CompanyName companyName,
            Description description,
            Price price,
            Supplier supplier,
            string createdBy)
        {
            var product = new Product(new ProductId(Guid.NewGuid()),productName, productImage, companyName, description, price, supplier, createdBy);

            return product;
        }
        public Product()
        {
            
        }

        internal Product(
               ProductId productId,
               ProductName productName,
               ProductImage productImage,
               CompanyName companyName,
               Description description,
               Price price,
               Supplier supplier,
               string createdBy
            )
        {
            this.ProductId = productId;
            this.price = price;
            this.name = productName;
            this.image = productImage;
            this.companyName = companyName;
            this.description = description;
            this.supplier = supplier;
            this.CreatedBy = createdBy;
        }
    }
}
