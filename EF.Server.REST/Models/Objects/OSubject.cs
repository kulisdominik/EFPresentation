using EF.Server.REST.Models.Basic;
using EF.Server.REST.Models.Relations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Server.REST.Models.Objects
{
	[Table("OSubject")]
	public class OSubject : BasicModel
	{
		public string Name { get; set; }

		public IEnumerable<RStudentSubject> RStudentsSubjects { get; set; }
	}
}
