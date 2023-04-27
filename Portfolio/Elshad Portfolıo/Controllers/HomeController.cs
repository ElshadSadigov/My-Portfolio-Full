using Elshad_Portfolıo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Elshad_Portfolıo.Controllers
{
	public class HomeController : Controller
	{
		private readonly Portfolio_Context context;

		public HomeController(Portfolio_Context context)
		{
			this.context = context;
		}

	

		public IActionResult Index()
		{
			IndexViewModel IndexVM = new IndexViewModel
			{
				Images = context.Images.OrderBy(X => X.Id).Take(1).ToList(),
				Cv = context.Cvs.OrderBy(X => X.Id).Take(1).ToList(),
				Settings = context.settings.ToList(),
				rows=context.abouts.ToList(),
				aboutImages=context.AboutImages.Take(1).ToList(),
				Experiences=context.experiences.OrderByDescending(x=>x.Id).ToList(),
				projects=context.projects.OrderByDescending(x => x.Id).Take(3).ToList(),
				SoftSkills=context.softSkills.OrderByDescending(x => x.Id).ToList(),
				FrontEnd=context.hardSkills.OrderBy(x => x.Id).Include(x=>x.Type).Where(x=>x.Type.Type=="Front End").ToList(),
				BackEnd=context.hardSkills.OrderByDescending(x => x.Id).Include(x=>x.Type).Where(x=>x.Type.Type=="Back End").ToList(),

			};
			return View(IndexVM);
		}

		
	}
}