using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace KamaliProject.Models
{
	public class Account : object
	{
		public Account() : base()
		{
			Username = "Amir";
			Password = "123456";
		}

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}