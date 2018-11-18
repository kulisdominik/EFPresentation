using Microsoft.Extensions.Configuration;

namespace EF.Server.REST.Data.Initializers
{
	public interface IDbInitializer
	{
		void Initialize(IConfiguration configuration);
	}
}
