﻿

using Microsoft.AspNetCore.Identity;

namespace JobBoard.Models
{
	public class AppUser:IdentityUser 
	{
		[Required]
		[StringLength(maximumLength:30,ErrorMessage ="Maksimum 30 simvol ola biler")]
		public string FullName { get; set; }

	}
}
