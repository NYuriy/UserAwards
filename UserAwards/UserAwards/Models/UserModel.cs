using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace UserAwards.Models
{
	public class UserModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }
	}
}