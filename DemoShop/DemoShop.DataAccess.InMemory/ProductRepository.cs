using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using DemoShop.Core;
using DemoShop.Core.Models;

namespace DemoShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public Product Find(string productId)
        {
            var result = products.Find(product => product.Id == productId);
            if (result == null)
            {
                throw new Exception("No Product Found");
            }

            return result;
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string productId)
        {
            var result = products.Find(product => product.Id == productId);
            if (result == null)
            {
                throw new Exception("No Product Found");
            }

            products.Remove(result);
        }
    }
}
