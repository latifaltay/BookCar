using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Dtos
{
	public class TokenResponseDto(string token, DateTime expireDate)
	{
        public string Token { get; set; } = token;
        public DateTime ExpireDate { get; set; } = expireDate;
    }
}
