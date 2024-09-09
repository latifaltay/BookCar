using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
