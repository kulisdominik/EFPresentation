using EF.Server.REST.Models.Objects;
using System;

namespace EF.Server.REST.Models.Relations
{
	public class RStudentSubject
	{
		public Guid StudentId { get; set; }

		public OStudent Student { get; set; }

		public Guid SubjectId { get; set; }

		public OSubject Subject { get; set; }
	}
}
