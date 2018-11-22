using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Server.REST.Repositories.Interface.Basic
{
	public interface IBasicRepository
	{
		void SaveChangesAsync();

		void SaveChanges();
	}
}
