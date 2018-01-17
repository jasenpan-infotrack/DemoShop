using DemoShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace DemoShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["products"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["products"] = productCategories;
        }

        public void Insert(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }

        public ProductCategory Find(string productCategoryId)
        {
            var result = productCategories.Find(p => p.Id == productCategoryId);
            if (result == null)
            {
                throw new Exception("No Category Found");
            }

            return result;
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string productCategoryId)
        {
            var result = productCategories.Find(p => p.Id == productCategoryId);
            if (result == null)
            {
                throw new Exception("No Category Found");
            }

            productCategories.Remove(result);
        }
    }
}
