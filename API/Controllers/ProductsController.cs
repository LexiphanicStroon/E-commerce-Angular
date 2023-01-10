using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo; 
        private readonly IGenericRepository<ProductType> _productsTypeRepo; 

        public ProductsController(IGenericRepository<Product> productsRepo, 
        IGenericRepository<ProductBrand> productsBrandRepo, IGenericRepository<ProductType> productsTypeRepo) 
        {
            _productsRepo = productsRepo;
            _productsBrandRepo = productsBrandRepo;
            _productsTypeRepo = productsTypeRepo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        {

            var products = await _productsRepo.ListAllASync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            
            return await _productsRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            return Ok(await _productsBrandRepo.ListAllASync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            return Ok(await _productsTypeRepo.ListAllASync());
        }
    }
}