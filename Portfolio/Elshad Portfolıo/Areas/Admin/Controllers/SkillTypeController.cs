using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SkillTypeController : Controller
    {
        private readonly Portfolio_Context context;

        public SkillTypeController(Portfolio_Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var type = context.skillTypes.ToList();
            return View(type);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SkillType skills)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            context.skillTypes.Add(skills);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            SkillType type = context.skillTypes.FirstOrDefault(x => x.Id == id);
            if (type == null) { return NotFound(); }
            return View(type);
        }
        [HttpPost]
        public IActionResult Update(SkillType skills)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SkillType extSkills = context.skillTypes.FirstOrDefault(x => x.Id == skills.Id);
            if (extSkills == null) { return NotFound(); }
            extSkills.Type = skills.Type;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            SkillType skills = context.skillTypes.FirstOrDefault(x => x.Id == id);
            if (skills == null) { return NotFound(); }
            context.skillTypes.Remove(skills);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
