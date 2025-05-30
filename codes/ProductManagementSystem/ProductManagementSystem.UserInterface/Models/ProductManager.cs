namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductManager : IProductManager
    {
        private readonly string requestUrl = "http://localhost:5171/api/product";
        public async Task<List<ProductViewModel>?> SendGetProductsRequest()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<ProductViewModel>>($"{requestUrl}/all");
        }
        public async Task<ProductViewModel?> SendGetProductReuqest(int id)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<ProductViewModel>($"{requestUrl}/view/{id}");
        }
        public async Task<bool> SendAddProductRequest(ProductViewModel product)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync<ProductViewModel>($"{requestUrl}/add", product);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> SendUpdateProductRequest(ProductViewModel product)
        {
            using var client = new HttpClient();
            var response = await client.PutAsJsonAsync<ProductViewModel>($"{requestUrl}/update/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> SendDeleteProductRequest(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{requestUrl}/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
