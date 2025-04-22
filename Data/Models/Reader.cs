using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Data.Models
{
	public class Reader
	{
		[Key]
		public int ReaderId { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstAndLastName { get; set; }

		[Required]
		[Range(10,80)]
		public int Age { get; set; }

		[Required]
		[MaxLength(20)]
		public string Email { get; set; }

		[Required]
		[StringLength(10)]
		public string PhoneNumber { get; set; }

		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
