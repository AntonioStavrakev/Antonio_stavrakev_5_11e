using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Data.Models
{
	public class Book
	{
		[Key]
		public int BookId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Title { get; set; }

		[MaxLength(50)]
		public string Author { get; set; }

		public ICollection<Reader> Readers { get; set; } = new List<Reader>();
		public ICollection<Genre> Genres { get; set; } = new List<Genre>();
	}
}
