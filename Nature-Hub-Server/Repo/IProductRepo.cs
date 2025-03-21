﻿using Microsoft.AspNetCore.Mvc;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public interface IProductRepo
    {
        Task<ICollection<NatureProduct>> GetAllProducts();

        Task<NatureProduct> AddProduct(NatureProduct product);

        Task<NatureProduct> UpdateProduct(NatureProduct product,int id);

        Task<ICollection<NatureProduct>> GetProductsByCategory(string category);

        Task<NatureProduct> GetProductById(int id);

        Task<bool> DeleteProduct(int id);

        Task<ICollection<NatureProduct>> GetProductsBySearch(string search);

        Task<IEnumerable<string>> GetAllCategories();
    }
}
