using BookCar.Application.Features.Mediator.Queries.ReviewQueries;
using BookCar.Application.Features.Mediator.Results.ReviewResults;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.ReviewHandlers
{
	internal class GetReviewByCarIdQueryHandler(IReviewRepository _repository) : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				CarId = x.CarId,
				Comment = x.Comment,
				CustomerImage = x.CustomerImage,
				CustomerName = x.CustomerName,
				RatingValue = x.RatingValue,
				ReviewDate = x.ReviewDate,
				ReviewId = x.ReviewId
			}).ToList();
		}
	}
}
