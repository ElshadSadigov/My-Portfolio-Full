namespace Elshad_Portfolıo.Models
{
    public class HardSkills:BaseClass
    {
         public int TypeId { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
        public string skill { get; set; }
                    
        public SkillType? Type { get; set; }

        
    }
}
