using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ProjectController : Controller
    {
        private readonly Portfolio_Context context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProjectController(Portfolio_Context context,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var project = context.projects.ToList();
            return View(project);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (project.ImageFile!=null)
            {
                if (project.ImageFile.ContentType != "image/png" && project.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (project.ImageFile.Length > 10485760)
                {
                    ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
                    return View();
                }
                project.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Project", project.ImageFile);
                context.projects.Add(project);

            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Project project=context.projects.FirstOrDefault(x => x.Id == id);
            if (project==null) { return NotFound();  }

            return View(project);
        }
        [HttpPost]
        public IActionResult Update(Project project)
        {
          

            Project extproject=context.projects.FirstOrDefault(x=>x.Id==project.Id);
            if (extproject==null) { return NotFound(); }
            if (project.ImageFile!=null)
            {
                if (project.ImageFile.ContentType != "image/png" && project.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (project.ImageFile.Length > 10485760)
                {
                    ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
                    return View();
                }
                FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/Project", extproject.Images);
                extproject.Images= FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Project", project.ImageFile);
            }
            extproject.Title= project.Title;
            extproject.Description= project.Description;
            extproject.GithubLink= project.GithubLink;
            extproject.ProjectLink= project.ProjectLink;
            extproject.order = project.order;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var porject = context.projects.FirstOrDefault(x => x.Id == id);
            if (porject == null) { return NotFound(); }
            context.projects.Remove(porject);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
