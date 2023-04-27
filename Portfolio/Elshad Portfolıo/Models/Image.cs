

namespace Elshad_Portfolıo.Models
{
    public class Image:BaseClass
    {
        
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Images { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
