using System;
using System.Collections.Generic;
using EF.Server.REST.Models;

namespace EF.Server.REST.Repositories.Interface
{
	public interface IStudentRepository : IDisposable
	{
		IEnumerable<StudentModel> Get();

		StudentModel Get(int studentId);

		void Insert(StudentModel student);

		void Delete(int studentID);

		void Update(StudentModel student);

		void SaveChangesAsync();

		void SaveChanges();

	}
}
