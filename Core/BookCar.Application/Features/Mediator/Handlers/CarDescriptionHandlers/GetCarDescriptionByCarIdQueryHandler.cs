using BookCar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using BookCar.Application.Features.Mediator.Results.CarDescriptionResults;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository _repository) : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
	{
		public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarDescription(request.Id);
			return new GetCarDescriptionQueryResult
			{
				CarDescriptionId = values.CarDescriptionId,
				CarId = values.CarId,
				Details = values.Details
			};
		}
	}
}
