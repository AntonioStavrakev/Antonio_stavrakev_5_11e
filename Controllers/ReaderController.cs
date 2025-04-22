using Antonio_stavrakev_5_11e.Data;
using Antonio_stavrakev_5_11e.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Controllers
{

		public class ReaderController
		{
			private LibraryContext context;

			public ReaderController()
			{
				context = new LibraryContext();
			}
			
			public ReaderController(LibraryContext dbContext)
			{
				context = dbContext;
			}
			public List<Reader> GetAll()
			{
				return context.Readers.ToList();
			}

			public Reader Get(int id)
			{
				return context.Readers.Find(id);
			}

			public void Add(Reader reader)
			{
				context.Readers.Add(reader);
				context.SaveChanges();
			}

			public void Update(Reader reader)
			{
				var item = context.Readers.Find(reader.ReaderId);
				if (item != null)
				{
					context.Entry(item).CurrentValues.SetValues(reader);
					context.SaveChanges();
				}
			}


			public void Delete(int id)
				{
					var item = context.Readers.Find(id);
					if (item != null)
					{
						context.Readers.Remove(item);
						context.SaveChanges();
					}
				}
			}



}
