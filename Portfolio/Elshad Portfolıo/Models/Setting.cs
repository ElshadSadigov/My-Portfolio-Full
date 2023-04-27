namespace Elshad_Portfolıo.Models
{
    public class Setting:BaseClass
    {
        [StringLength(maximumLength: 50)]
        public string Key { get; set; }
        [StringLength(maximumLength: 1500)]
        public string Value { get; set; }
    }
}
