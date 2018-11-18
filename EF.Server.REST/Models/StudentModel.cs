using EF.Server.REST.Models.Basic;
using System;

namespace EF.Server.REST.Models
{
	/// <summary>
	/// Student instance definition
	/// </summary>
	public partial class StudentModel : BasicModel
	{
		protected StudentModel()
		{
			
		}

		public StudentModel(Guid id, string pesel, string name, DateTime born = default(DateTime))
			: this()
		{
			Id = id;
			PESEL = pesel;
			Name = name;
			Born = born;
		}

		/// <summary>
		/// Personal identity number
		/// </summary>
		public string PESEL { get; set; }

		/// <summary>
		/// Full name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Date of birth
		/// </summary>
		public DateTime Born { get; set; }
	}
}
