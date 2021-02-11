using GoogleBooks.Services.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using GoogleBooks.DomainModel.Entities;

namespace GoogleBooks.Services.Concrete
{
    public class GoogleBookService : IGoobleBookService
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

                        //var result1 = JsonConvert.DeserializeObject(jsonString);

                        //result = JsonConvert.SerializeObject(new EnumerableQuery<KeyValuePair<string, JToken>>((IEnumerable<KeyValuePair<string, JToken>>)result1).SelectMany(y => y.Value).ToList(), new KeyValuePairConverter());
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
