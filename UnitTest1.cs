using Antonio_stavrakev_5_11e.Controllers;
using Antonio_stavrakev_5_11e.Data;
using Antonio_stavrakev_5_11e.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Antonio_stavrakev_5_11e.Tests
{
	public class Tests
	{
		private LibraryContext context;
		private ReaderController controller;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<LibraryContext>()
				.UseInMemoryDatabase(databaseName: "LibraryTestDb")
				.Options;

			context = new LibraryContext(options);
			controller = new ReaderController(context);
		}

		[TearDown]
		public void TearDown()
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}

		[Test]
		public void Add_Reader_Should_Add_One()
		{
			var reader = new Reader
			{
				FirstAndLastName = "Антонио Тестов",
				Age = 25,
				Email = "test@test.bg",
				PhoneNumber = "0888123456"
			};

			controller.Add(reader);
			var all = controller.GetAll();

			Assert.That(all.Count, Is.EqualTo(1));  
			Assert.That(all.First().FirstAndLastName, Is.EqualTo("Антонио Тестов")); 
		}

		[Test]
		public void Delete_Reader_Should_Remove_One()
		{
			var reader = new Reader
			{
				FirstAndLastName = "Пешо",
				Age = 30,
				Email = "pesho@mail.bg",
				PhoneNumber = "0888000000"
			};

			controller.Add(reader);
			var addedReader = controller.GetAll().First();

			controller.Delete(addedReader.ReaderId);
			var all = controller.GetAll();

			Assert.That(all.Count, Is.EqualTo(0));  
		}

		[Test]
		public void Update_Reader_Should_Change_Data()
		{
			var reader = new Reader
			{
				FirstAndLastName = "Иван Иванов",
				Age = 22,
				Email = "ivan@abv.bg",
				PhoneNumber = "0888999999"
			};

			controller.Add(reader);
			var added = controller.GetAll().First();

			added.FirstAndLastName = "Иван Петров";
			controller.Update(added);

			var updated = controller.Get(added.ReaderId);
			Assert.That(updated.FirstAndLastName, Is.EqualTo("Иван Петров")); 
		}

		[Test]
		public void GetAll_Should_Return_Empty_List_When_No_Data()
		{
			var all = controller.GetAll();
			Assert.That(all, Is.Empty);  
		}
	}
}
