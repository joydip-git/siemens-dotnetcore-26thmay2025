namespace ProductManagementSystem.UserInterface.Models
{
    //public class ProductApiManager(HttpClient client) : IProductApiManager
    public class ProductApiManager : IProductApiManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _productApiUrl = string.Empty;

        public ProductApiManager(IConfiguration configuration)
        {
            _configuration = configuration;
            //_productApiUrl = _configuration.GetSection("APIRequestUrls").GetValue<string>("ProductAPIUrl") ?? "http://localhost:5030/api/productapi";
            _productApiUrl = _configuration["APIRequestUrls:ProductAPIUrl"] ?? "http://localhost:5030/api/productapi";
        }

        public async Task<IEnumerable<ProductQueryViewModel>?> SendRequestToFetchProducts()
        {
            try
            {
                var client = EmbedJwt();
                var records = await client.GetFromJsonAsync<IEnumerable<ProductQueryViewModel>>($"{_productApiUrl}/all");
                //Dispose() disconnects the HttpClient instance from any unmanaged resource(such as WebSocket of the machine, which is not managed by.NET runtime), before garbage collector can decide to destroy the HttpClient instance
                client.Dispose();
                return records;

                //return await client.GetFromJsonAsync<IEnumerable<ProductQueryViewModel>>($"all");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductQueryViewModel?> SendRequestToFetchProductById(int id)
        {
            ProductQueryViewModel? product = null;
            try
            {
                //Dispose() method of HttpClinet is called at the end of the "using" block
                using (var client = EmbedJwt())
                {
                    product = await client.GetFromJsonAsync<ProductQueryViewModel>($"{_productApiUrl}/get/{id}");
                }
                return product;

                //return await client.GetFromJsonAsync<ProductQueryViewModel>($"get/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToAddProduct(ProductCommandViewModel product)
        {
            try
            {
                using var client = EmbedJwt();
                HttpResponseMessage response = await client.PostAsJsonAsync<ProductCommandViewModel>($"{_productApiUrl}/add", product);
                return response.IsSuccessStatusCode;

                //HttpResponseMessage response = await client.PostAsJsonAsync<ProductCommandViewModel>($"add", product);
                //return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToUpdateProduct(int id, ProductCommandViewModel product)
        {
            try
            {
                using var client = EmbedJwt();
                HttpResponseMessage response = await client.PutAsJsonAsync<ProductCommandViewModel>($"{_productApiUrl}/update/{id}", product);
                return response.IsSuccessStatusCode;


                //HttpResponseMessage response = await client.PutAsJsonAsync<ProductCommandViewModel>($"update/{id}", product);
                //return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToDeleteProduct(int id)
        {
            try
            {
                using var client = EmbedJwt();
                HttpResponseMessage response = await client.DeleteAsync($"{_productApiUrl}/delete/{id}");
                return response.IsSuccessStatusCode;


                //HttpResponseMessage response = await client.DeleteAsync($"delete/{id}");
                //return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private HttpClient EmbedJwt()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthToken.Token);
            return client;
        }
    }
}
