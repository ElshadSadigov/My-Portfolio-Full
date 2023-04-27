namespace Elshad_Portfolıo.Models
{
    public class Project:BaseClass
    {
        [Required]
        public int order { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 300, ErrorMessage = "Can be a maximum of 300 characters")]
        public string Description { get; set; }


        [StringLength(maximumLength: 300, ErrorMessage = "Can be a maximum of 300 characters")]
        public string? GithubLink { get; set; }


        [StringLength(maximumLength: 300, ErrorMessage = "Can be a maximum of 300 characters")]
        public string? ProjectLink { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Images { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
