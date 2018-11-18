using System;
using System.Collections.Generic;
using System.Linq;
using EF.Server.REST.Contexts;
using EF.Server.REST.Models;
using EF.Server.REST.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EF.Server.REST.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private SchoolContext _context;
		private bool disposed = false;

		public StudentRepository(SchoolContext context)
		{
			_context = context;
		}

		public void Delete(int studentID)
		{
			StudentModel student = _context.Students.Find(studentID);
			_context.Students.Remove(student);
		}

		public IEnumerable<StudentModel> Get()
		{
			return _context.Students.ToList();
		}

		public StudentModel Get(int studentId)
		{
			return _context.Students.Find(studentId);
		}

		public void Insert(StudentModel student)
		{
			_context.Students.Add(student);
		}

		public void SaveChangesAsync()
		{
			_context.SaveChangesAsync();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(StudentModel student)
		{
			_context.Entry(student).State = EntityState.Modified;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
