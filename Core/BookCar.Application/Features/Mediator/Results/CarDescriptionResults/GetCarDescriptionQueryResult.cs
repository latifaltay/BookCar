﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionQueryResult
	{
		public int CarDescriptionId { get; set; }
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
