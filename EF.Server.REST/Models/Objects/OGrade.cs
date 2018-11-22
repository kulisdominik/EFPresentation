using System.ComponentModel.DataAnnotations.Schema;
using EF.Server.REST.Models.Basic;

namespace EF.Server.REST.Models.Objects
{
	/// <summary>
	/// Grading scale
	/// </summary>
	[Table("OGrade")]
	public class OGrade : BasicModel
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
