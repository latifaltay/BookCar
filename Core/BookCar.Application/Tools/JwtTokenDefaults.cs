using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssuer = "https://localhost";
		public const string Key = "ThisİsMySecretKey!1234567890Lasi4do!";
		public const int Expire = 3;
    }
}
