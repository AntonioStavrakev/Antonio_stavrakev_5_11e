using Antonio_stavrakev_5_11e.Data;
using Antonio_stavrakev_5_11e.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Controllers
{

		public class BookController
		{
			private LibraryContext context;

			public BookController()
			{
				context = new LibraryContext();
			}
			public BookController(LibraryContext dbContext)
			{
				context = dbContext;
			}

			public List<Book> GetAll()
			{
				return context.Books.ToList();
			}

			public Book Get(int id)
			{
				return context.Books.Find(id);
			}

			public void Add(Book book)
			{
				context.Books.Add(book);
				context.SaveChanges();
			}

		public void Update(Book book)
		{
			var item = context.Books.Find(book.BookId);
			if (item != null)
			{
				context.Entry(item).CurrentValues.SetValues(book);
				context.SaveChanges();
			}
		}


		public void Delete(int id)
			{
				var item = context.Books.Find(id);
				if (item != null)
				{
					context.Books.Remove(item);
					context.SaveChanges();
				}
			}
		}
	

}
