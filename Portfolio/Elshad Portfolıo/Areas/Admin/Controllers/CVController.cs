using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics.Metrics;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class CVController : Controller
    {
        private readonly Portfolio_Context context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CVController(Portfolio_Context context,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            var cvs = context.Cvs.ToList();
            return View(cvs);
        }
        //     #region Create

        //     public IActionResult Create()
        //     {

        //         return View();
        //     }

        //[HttpPost]
        //public IActionResult Create(Cv cv)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    if (cv.CVFile != null)
        //    {
        //        if (cv.CVFile.ContentType != "application/pdf")
        //        {
        //            ModelState.AddModelError("CvFile", "But Pdf can be downloaded");
        //            return View();
        //        }
        //        if (cv.CVFile.Length > 10485760)
        //        {
        //            ModelState.AddModelError("CvFile", "It cannot be more than 10 MB");
        //            return View();
        //        }
        //        cv.CV=FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/cv", cv.CVFile);
        //       context.Cvs.Add(cv);
        //       context.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        //     #endregion



        #region Update
        public IActionResult Update (int id) 
        {
        Cv cv= context.Cvs.FirstOrDefault(x => x.Id == id);
            if (cv is null )
            {
                return NotFound();
            }
            return View(cv);
        }

        [HttpPost]
        public IActionResult Update (Cv cv)
        {
            Cv extCv = context.Cvs.FirstOrDefault(x => x.Id == cv.Id);
            if (extCv is null) { return NotFound(); }
            if (!ModelState.IsValid) return NotFound();
            if (cv.CVFile != null)
            {
                if (cv.CVFile.ContentType != "application/pdf")
                {
                    ModelState.AddModelError("CvFile", "But Pdf can be downloaded");
                    return View();
                }
                if (cv.CVFile.Length > 10485760)
                {
                    ModelState.AddModelError("CvFile", "It cannot be more than 10 MB");
                    return View();
                }
                FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/cv", extCv.CV);
                extCv.CV = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/cv", cv.CVFile);
            }
                context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
