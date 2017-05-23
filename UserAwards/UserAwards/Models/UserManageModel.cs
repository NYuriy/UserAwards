using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAwards.Models
{
	public class UserManageModel
	{
		public string UserId { get; set; }

		public string UserName { get; set; }

		public bool IsAdmin { get; set; }
	}
}