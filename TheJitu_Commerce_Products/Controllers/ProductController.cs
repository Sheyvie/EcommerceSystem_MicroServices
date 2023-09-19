using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheJitu_Commerce_Products.Models;
using TheJitu_Commerce_Products.Models.Dtos;
using TheJitu_Commerce_Products.Services.IServices;

namespace TheJitu_Commerce_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductsInterface _productService;
        private readonly ResponseDto _responseDto;
        public ProductController( IMapper mapper , IProductsInterface productService)
        {
            _mapper = mapper;
            _productService = productService;
            _responseDto = new ResponseDto();

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllProducts()
        {
            var products = await  _productService.GetProductsAsync();
            if (products == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);


            }

            _responseDto.Result = products;
            return Ok(_responseDto);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<ResponseDto>> AddProduct(ProductRequestDto productRequest)
        {
            var newProduct = _mapper.Map<Products>(productRequest);
            var response = await _productService.AddProductAsync(newProduct);
            if (string.IsNullOrWhiteSpace(response))
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);


            }

            _responseDto.Result = response;
            return Ok(_responseDto);
        }
        [HttpGet("GetByName/{productName}")]
        public async Task<ActionResult<ResponseDto>> GetProduct(string productName)
        {
            var product = await _productService.GetProductByNameAsync(productName);
            if (product == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);


            }

            _responseDto.Result = product;
            return Ok(_responseDto);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> UpdateProduct(Guid id, ProductRequestDto  productRequestDto)
        {
            var product = await  _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);


            }
            var updated = _mapper.Map(productRequestDto, product);
            var response =await _productService.UpdateProductAsync(updated);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> DeleteProduct(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);


            }
            
            var response = await _productService.DeleteProductAsync(product);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }
    }
}
