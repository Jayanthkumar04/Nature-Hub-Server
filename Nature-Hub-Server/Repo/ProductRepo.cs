﻿using Microsoft.EntityFrameworkCore;
using Nature_Hub_Server.Data;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public class ProductRepo : IProductRepo
    {
        NatureProductsDbContext _repo;
        public ProductRepo(NatureProductsDbContext repo)
        {
            _repo = repo;
            
        }
        public async Task<NatureProduct> AddProduct(NatureProduct product)
        {
            await _repo.NatureProducts.AddAsync(product);

            await _repo.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _repo.NatureProducts.FindAsync(id);

            if(product !=null)
            {
                _repo.NatureProducts.Remove(product);
                await _repo.SaveChangesAsync();
                return true;
            }

            else
            {
                return false;

            }

        }

        public async Task<ICollection<NatureProduct>> GetAllProducts()
        {
            var products = await _repo.NatureProducts.ToListAsync();

            if(products != null)
            {
                return products;
            }
            else
            {
                return new List<NatureProduct>();
            }

        }

        public async Task<NatureProduct> GetProductById(int id)
        {
            var product = await _repo.NatureProducts.FindAsync(id);
            if(product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public async Task<ICollection<NatureProduct>> GetProductsByCategory(string category)
        {
            var catProducts = await _repo.NatureProducts.Where(x => x.ProCategory == category).ToListAsync();

            if(catProducts != null)
            {
                return catProducts;
            }
            else
            {
                return new List<NatureProduct>();
            }
        }

        public async Task<NatureProduct> UpdateProduct(NatureProduct product)
        {
            _repo.NatureProducts.Update(product);
            await _repo.SaveChangesAsync();
            return product;
        }
    }
}
