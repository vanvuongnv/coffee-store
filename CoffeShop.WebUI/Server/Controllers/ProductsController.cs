using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.WebUI.Server.Infrastructure.Abstract;
using CoffeShop.WebUI.Shared.Common;
using CoffeShop.WebUI.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] UrlQuery urlQuery)
        {
            var products = await _repository
                .Products
                .Where(x => string.IsNullOrEmpty(urlQuery.Keyword) || x.ProductName.ToLower().Contains(urlQuery.Keyword.ToLower()))
                .Join(_repository.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new ProductDto()
                {
                    Id = product.Id,
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    UnitsInStock = product.UnitsInStock
                })
                .Skip((urlQuery.Page - 1) * urlQuery.PageSize)
                .Take(urlQuery.PageSize)
                .ToListAsync();

            var total = await _repository
                .Products
                .Where(x => string.IsNullOrEmpty(urlQuery.Keyword) || x.ProductName.ToLower().Contains(urlQuery.Keyword.ToLower()))
                .Select(x => x.Id)
                .CountAsync();

            var response = PaginationResponse<ProductDto>.Success(products, total);

            return Ok(response);
        }
    }
}

