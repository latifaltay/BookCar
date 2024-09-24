using BookCar.Application.Features.Mediator.Commands.FeatureCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler(IRepository<Feature> _repository) : IRequestHandler<UpdateFeatureCommand>
    {
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FeatureId);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
