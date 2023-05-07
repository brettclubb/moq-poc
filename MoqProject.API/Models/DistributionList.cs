using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoqProject.API.Models
{
	public class DistributionList
	{
		public DistributionList()
		{
			Contacts = new List<Contact>();
			Title = "My D/L Title";
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Contact> Contacts { get; set; }
	}
}

