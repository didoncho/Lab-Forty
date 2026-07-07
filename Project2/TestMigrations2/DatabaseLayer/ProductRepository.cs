using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{

	public class ProductRepository(DataContext context)
	{

		public List<Products> GetAll()
		{
			//GetAll

			EnsureAdded();
			return context.Products.ToList();
		}

		public void EnsureAdded()
		{
			//Create
			context.Products.Add(new Products()
			{
				Name = "Name",
				Orders = []
			});

			context.SaveChanges();
		}


		public Products? GetByName(string name)
		{
			//Get by name
			EnsureAdded();
			return context.Products.FirstOrDefault(n => n.Name == name);
		}

		public Products? Get(int id)
		{
			//Get by name
			EnsureAdded();
			return context.Products.AsNoTracking().FirstOrDefault(n => n.Id == id);
		}

		public void Update(int id, string newName)
		{
			//Get by name
			EnsureAdded();

			var product = Get(id);

			if (product == null)
			{
				return;
			}

			product.Name = newName;
			context.SaveChanges();
		}
	}
}
