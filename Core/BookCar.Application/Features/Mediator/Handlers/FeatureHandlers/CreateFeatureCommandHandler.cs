using BookCar.Application.Features.Mediator.Commands.FeatureCommands;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.CarFeatureInterfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler(IRepository<Feature> _repository, ICarFeatureRepository ICarFeatureRepository) : IRequestHandler<CreateFeatureCommand>
    {
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
			var feature = new Feature
			{
				Name = request.Name
			};
			await _repository.CreateAsync(feature);

			ICarFeatureRepository.AddNewFeatureToAllCars(feature);
		}
    }
}
