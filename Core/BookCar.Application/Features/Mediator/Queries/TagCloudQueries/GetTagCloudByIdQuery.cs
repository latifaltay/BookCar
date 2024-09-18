using MediatR;
using BookCar.Application.Features.Mediator.Results.TagCloudResults;

namespace BookCar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery(int id) : IRequest<GetTagCloudByIdQueryResult>
    {
        public int Id { get; set; } = id;

    }
}
