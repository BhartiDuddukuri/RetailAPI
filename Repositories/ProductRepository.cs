using Microsoft.EntityFrameworkCore;
using RetailAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products
                .Include(e => e.Category).Include(e => e.Status)
                .ToListAsync();
        }

        public  List<ProductInfo> GetProductsCount()
        {
            string sql = "exec GetProductCount";
            List<ProductInfo> result = new List<ProductInfo>();
            result = appDbContext.ProductInfo.FromSqlRaw(sql).ToList();
            return result;
        }

        public async Task<Product> GetProductByID(int productID)
        {
            return await appDbContext.Products
                .Include(e => e.Category).Include(e => e.Status)
                .FirstOrDefaultAsync(e => e.ProductID == productID);
        }

        public async Task<Product> SellProduct(int ProductID)
        {
            var result = await appDbContext.Products
                 .FirstOrDefaultAsync(e => e.ProductID == ProductID);

            if (result != null)
            {
                result.StatusID = 1;
                await appDbContext.SaveChangesAsync();
                return await appDbContext.Products
               .Include(e => e.Category).Include(e => e.Status)
               .FirstOrDefaultAsync(e => e.ProductID == ProductID);
            }
            return null;
        }

        public async Task<Product> UpdateProductStatus(int ProductID, int StatusID)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductID == ProductID);

            if (result != null)
            {
                result.StatusID = StatusID;
                await appDbContext.SaveChangesAsync();

                return await appDbContext.Products
                .Include(e => e.Category).Include(e => e.Status)
                .FirstOrDefaultAsync(e => e.ProductID == ProductID);
            }
            return null;
        }
    }
}
