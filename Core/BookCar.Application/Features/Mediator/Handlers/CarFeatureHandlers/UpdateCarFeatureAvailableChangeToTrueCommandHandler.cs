using BookCar.Application.Features.Mediator.Commands.CarFeatureCommands;
using BookCar.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
