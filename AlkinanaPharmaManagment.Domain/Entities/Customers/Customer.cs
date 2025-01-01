using AlkinanaPharmaManagment.Shared.Abstraction.Domain;


namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public class Customer : AggregateRoot
    {
        public CustomerId CustomerId { get; private set; }

        public CustomerName customerName{get; private set; }

        public Pharma pharma {get; private set; }

        public Address address { get; private set; }

        public static Customer CreateCustomer(CustomerName customerName, Address address, Pharma pharma)
        {
            var customer = new Customer(new CustomerId(Guid.NewGuid()),
                customerName,
                pharma,
                address);
  
            return customer;
        }

        public Customer()
        {
            
        }

        internal Customer(
                CustomerId customerId,
                CustomerName customerName,
                Pharma pharma,
                Address address
            ) {
            CustomerId = customerId;
            this.customerName = customerName;
            this.pharma = pharma;
            this.address = address;
        }

    }
}
