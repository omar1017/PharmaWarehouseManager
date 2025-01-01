using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Delete
{
    internal sealed class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : ICommandHandler<DeleteCustomerCommand>
    {
        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetAsync(request.customerId);

            if (customer is null)
            {
            }

            await customerRepository.DeleteAsync(customer);

            await customerRepository.SaveChangeAsync();

            return Result.Success();
        }
    }
}
