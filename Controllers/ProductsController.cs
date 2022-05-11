using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAPI.Models;
using RetailAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet, Authorize]
        public   List<ProductInfo> GetProductsCount()
        {
            return (productRepository.GetProductsCount());
        }

        [HttpPatch("{ProductID:int}"), Authorize]

        public async Task<ActionResult<Product>> SellProduct(int ProductID)
        {
            try
            {
                var productToUpdate = await productRepository.GetProductByID(ProductID);

                if (productToUpdate.StatusID == 1)
                {
                    return NotFound($"Product with Id = {ProductID} is already sold");
                }
                if (productToUpdate == null)
                {
                    return NotFound($"Product with Id = {ProductID} not found");
                }

                return await productRepository.SellProduct(ProductID);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating employee record");
            }
        }

        [HttpPatch("{ProductID:int}/{StatusID:int}"), Authorize]
        public async Task<ActionResult<Product>> UpdateProductStatus(int ProductID, int StatusID)
        {
            try
            {
                var productToUpdate = await productRepository.GetProductByID(ProductID);

                if (productToUpdate == null)
                {
                    return NotFound($"Product with Id = {ProductID} not found");
                }

                return await productRepository.UpdateProductStatus(ProductID, StatusID);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating employee record");
            }
        }
    }
}
