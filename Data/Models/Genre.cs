using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Data.Models
{
	public class Genre
	{
		[Key]
		public int GenreId {  get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
