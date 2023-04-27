using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AboutImageController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly Portfolio_Context context;

        public AboutImageController(IWebHostEnvironment webHostEnvironment,Portfolio_Context context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }
        public IActionResult Index()
        {
            List<AboutImage> images = context.AboutImages.ToList();
            return View(images);
        }

        //#region Create
        //public IActionResult Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(AboutImage image)
        //{
        //    if (!ModelState.IsValid) return View();
        //    if (image.ImageFile != null)
        //    {
        //        if (image.ImageFile.ContentType != "image/png" && image.ImageFile.ContentType != "image/jpeg")
        //        {
        //            ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
        //            return View();
        //        }
        //        if (image.ImageFile.Length > 10485760)
        //        {
        //            ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
        //            return View();
        //        }
        //        image.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/About", image.ImageFile);
        //        context.AboutImages.Add(image);
        //    }
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //#endregion




        #region Update
        public IActionResult Update(int id)
        {
            AboutImage image = context.AboutImages.FirstOrDefault(x => x.Id == id);
            if (image is null)
            {
                return NotFound();
            }

            return View(image);
        }

        [HttpPost]

        public IActionResult Update(AboutImage image)
        {
            AboutImage extImage = context.AboutImages.FirstOrDefault(x => x.Id == image.Id);
            if (extImage is null) { return NotFound(); }

            if (image.ImageFile != null)
            {
                if (image.ImageFile.ContentType != "image/png" && image.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (image.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
                    return View();
                }
                FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/About", extImage.Images);
                extImage.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/About", image.ImageFile);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
