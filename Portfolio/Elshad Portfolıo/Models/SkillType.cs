namespace Elshad_Portfolıo.Models
{
    public class SkillType:BaseClass
    {
        [StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
        public string Type { get; set; }

        List<HardSkills>? HardSkills { get; set; }

    }
}
