using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Region { get; set; }
		public string PhoneNumber { get; set; }

		public int UserInformationId { get; set; }
		public UserInformation UserInformation { get; set; }

		public List<Order> Orders { get; set; }
	}
}
