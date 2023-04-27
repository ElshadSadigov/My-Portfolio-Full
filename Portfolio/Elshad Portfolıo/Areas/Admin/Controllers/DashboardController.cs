using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
	{

		public IActionResult Index()
		{

			return View();
		}
	}
}
