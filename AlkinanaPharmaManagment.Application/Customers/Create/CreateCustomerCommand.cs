using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Create
{
    public record CreateCustomerCommand(CustomerRequest Customer) : ICommand<CustomerId>;

    public record CustomerRequest(CustomerName name,Pharma pharma, Address address);
}
