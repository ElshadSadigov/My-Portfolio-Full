using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ExperienceController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly Portfolio_Context context;

        public ExperienceController(IWebHostEnvironment webHostEnvironment,Portfolio_Context context )
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }
        public IActionResult Index()
        {
            var experience = context.experiences.ToList(); 
            return View(experience);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Experience Experience)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (Experience.ImageFile != null)
            {
                if (Experience.ImageFile.ContentType != "image/png" && Experience.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (Experience.ImageFile.Length > 10485760)
                {
                    ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
                    return View();
                }
                Experience.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Experience", Experience.ImageFile);
                context.experiences.Add(Experience);

            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Experience Experience = context.experiences.FirstOrDefault(x => x.Id == id);
            if (Experience == null) { return NotFound(); }

            return View(Experience);
        }
        [HttpPost]
        public IActionResult Update(Experience Experience)
        {
           

            Experience extExperience = context.experiences.FirstOrDefault(x => x.Id == Experience.Id);
            if (extExperience == null) { return NotFound(); }
            if (Experience.ImageFile != null)
            {
                if (Experience.ImageFile.ContentType != "image/png" && Experience.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (Experience.ImageFile.Length > 10485760)
                {
                    ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
                    return View();
                }
                FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/Experience", extExperience.Images);
                extExperience.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Experience", Experience.ImageFile);
            }
            extExperience.Order = Experience.Order;
            extExperience.Position = Experience.Position;
            extExperience.CompanyName = Experience.CompanyName;
            extExperience.CompanyLink = Experience.CompanyLink;
            extExperience.Accessdate = Experience.Accessdate;
            extExperience.Releasedate = Experience.Releasedate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var porject = context.experiences.FirstOrDefault(x => x.Id == id);
            if (porject == null) { return NotFound(); }
            context.experiences.Remove(porject);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
