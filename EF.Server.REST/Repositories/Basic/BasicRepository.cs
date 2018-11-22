using System;
using EF.Server.REST.Repositories.Interface.Basic;
using Microsoft.EntityFrameworkCore;

namespace EF.Server.REST.Repositories.Basic
{
	public class BasicRepository<ContextType> : IDisposable, IBasicRepository
		where ContextType : DbContext 
	{
		public ContextType Context { get; set; }

		public bool Disposed { get; private set; } = false;

		#region Public methods

		/// <summary>
		/// Call with true parameter if you want to save data in the database
		/// </summary>
		/// <param name="save">Represents a Boolean (true or false) value.</param>
		public void TrySave(bool save = false)
		{
			if (save)
			{
				SaveChanges();
			}
		}

		#endregion

		#region Implements IBasicRepository

		public void SaveChangesAsync()
		{
			Context.SaveChangesAsync();
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}

		#endregion

		#region Implements IDisposable

		protected virtual void Dispose(bool disposing)
		{
			if (!this.Disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}

			Disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
