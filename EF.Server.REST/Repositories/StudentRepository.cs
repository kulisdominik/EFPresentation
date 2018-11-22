using System;
using System.Collections.Generic;
using System.Linq;
using EF.Server.REST.Contexts;
using EF.Server.REST.Models.Objects;
using EF.Server.REST.Repositories.Basic;
using EF.Server.REST.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EF.Server.REST.Repositories
{
	public class StudentRepository : BasicRepository<ApplicationContext>, IStudentRepository
	{
		public StudentRepository(ApplicationContext context)
		{
			Context = context;
		}

		public IEnumerable<OStudent> Get()
		{
			return Context.Students.ToList();
		}

		public OStudent Get(Guid studentId)
		{
			return Context.Students.Find(studentId);
		}

		public void Insert(OStudent student, bool save)
		{
			Context.Students.Add(student);
			TrySave(save);
		}

		public void Update(OStudent student, bool save)
		{
			Context.Update(student);
			TrySave(save);
		}

		public void Delete(Guid studentID, bool save)
		{
			OStudent student = Context.Students.Find(studentID);
			Context.Students.Remove(student);
			TrySave();
		}

		public void TrySomethingMoreDifficult()
		{
			//Context.Students.Where(item => item.Name == "Dominik Kulis").FirstOrDefault();
			//Context.Students.Where(item => item.Name == "Dominik Kulis").All();
		}
	}
}
