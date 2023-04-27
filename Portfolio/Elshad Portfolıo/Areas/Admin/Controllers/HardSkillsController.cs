using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class HardSkillsController : Controller
    {
        private readonly Portfolio_Context context;

        public HardSkillsController(Portfolio_Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var skill = context.hardSkills.Include(x=>x.Type).ToList();

            return View(skill);
        }

        public IActionResult Create()
        {
            ViewBag.type = context.skillTypes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(HardSkills hardSkills)
        {
            ViewBag.type = context.skillTypes.ToList();
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            context.hardSkills.Add(hardSkills);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.type = context.skillTypes.ToList();
            HardSkills hardSkills=context.hardSkills.FirstOrDefault(x=>x.Id==id);
            if (hardSkills==null) { return NotFound(); }

            return View(hardSkills);
        }
        [HttpPost]
        public IActionResult Update(HardSkills hardSkills)
        {
            ViewBag.type = context.skillTypes.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            HardSkills extskill= context.hardSkills.FirstOrDefault(x=>x.Id==hardSkills.Id);
            if (extskill==null) { return NotFound(); }
            extskill.skill=hardSkills.skill;
            extskill.TypeId=hardSkills.TypeId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            HardSkills hardSkills=context.hardSkills.FirstOrDefault(x=>x.Id==id);
            if (hardSkills==null) { return NotFound(); }
            context.hardSkills.Remove(hardSkills);
            context.SaveChanges();  

            return RedirectToAction("index");
        }



    }
}
