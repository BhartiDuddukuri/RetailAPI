using RetailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        List<ProductInfo> GetProductsCount();
        Task<Product> GetProductByID(int productID);
        Task<Product> UpdateProductStatus(int ProductID, int StatusID);
        Task<Product> SellProduct(int ProductID);
    }
}
