using API.DTOs;
using API.Filters;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IMapper mapper,IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var product = await  _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product =  _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int Id)
        {
            var product = _productService.GetByIdAsync(Id).Result;
            _productService.Remove(product);
            return NoContent();
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

    }
}
