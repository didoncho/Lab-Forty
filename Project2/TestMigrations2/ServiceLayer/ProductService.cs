using Business;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
	public class ProductService(ProductRepository productRepository)
	{
		public Products[] GetAllProducts()
		{
			return productRepository.GetAll();
		}
	}
}
