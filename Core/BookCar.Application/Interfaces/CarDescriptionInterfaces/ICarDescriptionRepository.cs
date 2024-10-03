﻿using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Interfaces.CarDescriptionInterfaces
{
	public interface ICarDescriptionRepository
	{
		Task<CarDescription> GetCarDescription(int carId);
	}
}
