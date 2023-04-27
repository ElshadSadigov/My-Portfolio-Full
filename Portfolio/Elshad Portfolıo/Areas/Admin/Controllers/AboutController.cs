using Elshad_Portfolıo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AboutController : Controller
	{
		private readonly Portfolio_Context context;

		public AboutController(Portfolio_Context context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var row =context.abouts.ToList();
			return View(row);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(About about) 
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			context.abouts.Add(about);
			context.SaveChanges();
		 return RedirectToAction(nameof(Index));
		}
		public IActionResult Update (int id) { 
		
			About about=context.abouts.FirstOrDefault(a => a.Id == id);
			if (about == null) { return NotFound(); }
			return View(about);
		}
		[HttpPost]
		public IActionResult Update(About about)
		{
			if (!ModelState.IsValid) { return View(); }
			About extAbout=context.abouts.FirstOrDefault(x=> x.Id == about.Id);
			if (extAbout == null) { return NotFound();  }
			extAbout.Row=about.Row;
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int id)
		{
			About deleteAbout = context.abouts.FirstOrDefault(x => x.Id == id);
			if (deleteAbout == null) { return NotFound(); }
			context.abouts.Remove(deleteAbout);
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}


	}
}
