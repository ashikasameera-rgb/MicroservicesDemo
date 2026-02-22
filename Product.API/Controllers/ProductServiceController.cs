using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private readonly IProductServiceRepository _repo;

        public ProductServiceController(IProductServiceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _repo.GetAllAsync());

        
        [HttpPost]
        public async Task<IActionResult> Create(ProductServiceDto dto)
        {
            var product = new Product(dto.Name, dto.Price,dto.Stock);
            await _repo.AddAsync(product);
            return Ok(product);
        }

    }
}
