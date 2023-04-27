namespace Elshad_Portfolıo.Models
{
	public class About : BaseClass
	{
		[Required]
		[StringLength(maximumLength: 1500, ErrorMessage = "Can be a maximum of 1500 characters")]
		public string Row { get; set; }
	}
}
