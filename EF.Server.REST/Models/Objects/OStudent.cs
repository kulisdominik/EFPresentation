using EF.Server.REST.Models.Basic;
using EF.Server.REST.Models.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Server.REST.Models.Objects
{
	/// <summary>
	/// Student instance definition
	/// </summary>
	[Table("OStudent")]
	public partial class OStudent : BasicModel
	{
		#region Constructors

		public OStudent()
		{

		}

		public OStudent(string pesel, string name, DateTime born = default(DateTime))
			: this()
		{
			PESEL = pesel;
			Name = name;
			Born = born;
		}

		#endregion

		/// <summary>
		/// Personal identity number
		/// </summary>
		[Required(ErrorMessage = "PESEL is required.")]
		public string PESEL { get; set; }

		/// <summary>
		/// Full name
		/// </summary>
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }

		/// <summary>
		/// Date of birth
		/// </summary>
		public DateTime Born { get; set; }

		/// <summary>
		/// Foreign key between students and subjects
		/// </summary>
		public IEnumerable<RStudentSubject> RStudentsSubjects { get; set; }
	}
}
