using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SoftSkillsController : Controller
    {
        private readonly Portfolio_Context context;

        public SoftSkillsController (Portfolio_Context context)
            {
            this.context = context;
        }
        public IActionResult Index()
        {
            var soft_Skills=context.softSkills.ToList();
            return View(soft_Skills);
        }   
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]  
        public IActionResult Create(SoftSkills skills)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            context.softSkills.Add(skills);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) 
        {
        SoftSkills softSkills=context.softSkills.FirstOrDefault(x => x.Id == id);
            if (softSkills == null) { return NotFound(); }
            return View(softSkills);
        }
        [HttpPost]
        public IActionResult Update(SoftSkills skills)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SoftSkills extSkills=context.softSkills.FirstOrDefault(x=>x.Id==skills.Id);
            if (extSkills == null) { return NotFound(); }
            extSkills.skill=skills.skill;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            SoftSkills skills=context.softSkills.FirstOrDefault(x=>x.Id== id);
            if (skills == null) { return NotFound(); }
            context.softSkills.Remove(skills);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
