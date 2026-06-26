using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
	public class UserInformation
	{
		public int Id { get; set; }
		public string Egn { get; set; }
		
		[Required, MaxLength(100)]
		public string Address { get; set; }

		public User User { get; set; }

	}
}
