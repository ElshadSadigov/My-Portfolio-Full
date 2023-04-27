namespace Elshad_Portfolıo.Models
{
    public class Cv:BaseClass
    {
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? CV { get; set; }
        [NotMapped]
        public IFormFile CVFile { get; set; }
    }
}
