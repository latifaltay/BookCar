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
	public class UpdateReviewHandler(IRepository<Review> _repository) : IRequestHandler<UpdateReviewCommand>
	{
		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewId);
			values.CustomerName = request.CustomerName;
			values.ReviewDate = request.ReviewDate;
			values.CarId = request.CarId;
			values.Comment = request.Comment;
			values.RatingValue = request.RatingValue;
			await _repository.UpdateAsync(values);
		}
	}
}
