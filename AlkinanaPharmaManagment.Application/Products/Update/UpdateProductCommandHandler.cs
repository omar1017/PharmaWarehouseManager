using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand, ProductId>
    {
        public async Task<Result<ProductId>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           
            await productRepository.UpdateAsync(request.Product);

            await productRepository.SaveChangeAsync();

            return request.Product.ProductId;
        }
    }
}
