using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Carts.DeleteItems
{
    internal sealed class DeleteItemsCommandHandler(ICartRepository cartRepository) : ICommandHandler<DeleteItemsCommand>
    {
        public async Task<Result> Handle(DeleteItemsCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.cartId);

            if (cart is null) { }

            cart.RemoveItem(request.lineItemId);

            await cartRepository.SaveChangeAsync();

            return Result.Success();
        }
    }
}
