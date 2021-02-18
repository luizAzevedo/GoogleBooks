using GoogleBooks.Service.Abstract;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GoogleBooks.Service.Concrete
{
    public class ListGoogleBookService : IListGoobleBookService
    {
        public async Task<string> Execute(string query, int offset, int count)
        {
            var result = string.Empty;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await cliente.GetAsync($"volumes?q={query}&startIndex={offset}&maxResults={count}");

                    response.EnsureSuccessStatusCode();

                    using (HttpContent content = response.Content)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }

            }

            return result;

        }
    }
}
