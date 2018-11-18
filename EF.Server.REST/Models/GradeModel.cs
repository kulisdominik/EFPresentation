using EF.Server.REST.Models.Basic;

namespace EF.Server.REST.Models
{
	/// <summary>
	/// Grading scale
	/// </summary>
	public class GradeModel : BasicModel
	{
		/// <summary>
		/// Full name of the rating
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Numerical value of the rating
		/// </summary>
		public ushort Values { get; set; }
	}
}
