namespace Elshad_Portfolıo.Models
{
    public class SoftSkills:BaseClass
    {
        [StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
        public string skill { get; set; }
    }
}
