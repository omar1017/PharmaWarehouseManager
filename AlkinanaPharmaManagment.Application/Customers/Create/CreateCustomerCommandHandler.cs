using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Customers.Events;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository) : ICommandHandler<CreateCustomerCommand,CustomerId>
    {
        
        async Task<Result<CustomerId>> IRequestHandler<CreateCustomerCommand, Result<CustomerId>>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateCustomer(request.Customer.name, request.Customer.address, request.Customer.pharma);

            customer.Raise(new CustomerCreatedEvent(customer.CustomerId));

            await customerRepository.AddAsync(customer);

            await customerRepository.SaveChangeAsync();

            return customer.CustomerId;
        }
    }
}
