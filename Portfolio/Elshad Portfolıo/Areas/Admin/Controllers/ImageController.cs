

using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly Portfolio_Context context;

        public ImageController(IWebHostEnvironment webHostEnvironment, Portfolio_Context context )
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Image> images = context.Images.ToList();
            return View(images);
        }

        //#region Create
        //public IActionResult Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Image image)
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
        //        image.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Image", image.ImageFile);
        //        context.Images.Add(image);
        //    }
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //#endregion




        #region Update
        public IActionResult Update(int id) 
        {
            Image image=context.Images.FirstOrDefault(x => x.Id == id);
            if (image is null)
            {
                return NotFound();
            }

            return View(image);
        }
        [HttpPost]

        public IActionResult Update(Image image)
        {
            if (!ModelState.IsValid) { return View(); }
            Image extImage= context.Images.FirstOrDefault(x=>x.Id== image.Id);
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
                FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/Image", extImage.Images);
                extImage.Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Image", image.ImageFile);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion



        //#region Delete
        //public IActionResult Delete(int id)
        //{
        //    var image = context.Images.FirstOrDefault(x => x.Id == id);
        //    if (image is null) { return NotFound(); }
        //    FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/Image", image.Images);
        //    context.Images.Remove(image);
        //    context.SaveChanges();
        //    return RedirectToAction(nameof(Index));

        //}
        //#endregion

    }
}
