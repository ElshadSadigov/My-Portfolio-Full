namespace Elshad_Portfolıo.Models
{
    public class Experience:BaseClass
    {
        [Required]
        public int Order { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string CompanyName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string CompanyLink { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string Position { get; set; }
        public DateTime Accessdate { get; set; }
        public DateTime Releasedate { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Images { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
