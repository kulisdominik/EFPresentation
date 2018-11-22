using System;
using System.Collections.Generic;
using EF.Server.REST.Models.Objects;
using EF.Server.REST.Repositories.Interface.Basic;

namespace EF.Server.REST.Repositories.Interface
{
	public interface IStudentRepository
	{
		IEnumerable<OStudent> Get();

		OStudent Get(Guid studentId);

		void Insert(OStudent student, bool save = true);

		void Delete(Guid studentID, bool save = true);

		void Update(OStudent student, bool save = true);
	}
}
