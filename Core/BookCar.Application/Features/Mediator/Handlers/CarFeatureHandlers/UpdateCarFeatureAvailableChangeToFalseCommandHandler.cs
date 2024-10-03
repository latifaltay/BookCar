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
    public class UpdateCarFeatureAvailableChangeToFalseCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseCommand>
    {
        public async Task Handle(UpdateCarFeatureAvailableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToFalse(request.Id);
        }
    }
}
