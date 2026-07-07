using Business;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
	public class ProductService(ProductRepository productRepository)
	{
		public List<Products> GetAllProducts()
		{
			return productRepository.GetAll();
		}

		public Products? GetProductByName(string name)
		{
			return  productRepository.GetByName(name);
		}

		public Products? GetProductById(int id)
		{
			return productRepository.Get(id);
		}
	}
}
