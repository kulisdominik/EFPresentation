using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Server.REST.Models.Basic
{
	/// <summary>
	/// Base model of objects
	/// </summary>
	public class BasicModel
	{
		/// <summary>
		/// Unique identification key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
	}
}
