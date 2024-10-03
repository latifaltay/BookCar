using BookCar.Application.Features.Mediator.Commands.ReviewCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewHandler(IRepository<Review> _repository) : IRequestHandler<CreateReviewCommand>
	{
		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CustomerImage = request.CustomerImage,
				CarId = request.CarId,
				Comment = request.Comment,
				CustomerName = request.CustomerName,
				RatingValue = request.RatingValue,
				ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
			});
		}
	}
}
