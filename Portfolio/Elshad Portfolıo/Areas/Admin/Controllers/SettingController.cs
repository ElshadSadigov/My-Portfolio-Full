using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly Portfolio_Context context;

        public SettingController(Portfolio_Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var setting = context.settings.ToList();
            return View(setting);
        }

        #region Update

        public IActionResult Update(int id)
        {
            Setting setting=context.settings.FirstOrDefault(x=>x.Id==id);
            if (setting==null) { return NotFound(); }
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting) 
        {
            Setting extSetting = context.settings.FirstOrDefault(x => x.Id == setting.Id);
            if (extSetting == null) { return NotFound(); }


            extSetting.Value = setting.Value;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        #endregion
    }
}
