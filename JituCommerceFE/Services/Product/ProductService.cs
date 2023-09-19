
using JituCommerceFE.Models;
using JituCommerceFE.Models.Products;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TheJitu_CommerceFE.Models;

namespace JituCommerceFE.Services.Product
{
    public class ProductService : IProductInterface
    {
        private  readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7002";
        public ProductService(HttpClient httpClient)
        {
           
            _httpClient = httpClient;

        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {

            var response = await _httpClient.GetAsync($"{BASEURL}/api/Product");
            var content = await response.Content.ReadAsStringAsync();


            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {
                
                return JsonConvert.DeserializeObject<List<ProductDto>>(results.Result.ToString());

            }
            return new List<ProductDto>();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Product/GetById/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {
                
                return JsonConvert.DeserializeObject<ProductDto>(results.Result.ToString());

            }
            return new ProductDto();
        }

    }
}

