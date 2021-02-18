using GoogleBooks.Service.Abstract;
using System.Threading.Tasks;
using System.Web.Http;

namespace GoogleBooks.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IListGoobleBookService listGoogleBooksService;
        public BooksController(IListGoobleBookService listGoogleBooksService)
        {
            this.listGoogleBooksService = listGoogleBooksService;
        }

        public async Task<string> Get(string p)
        {
            return await listGoogleBooksService.Execute(p, 0, 40);
        }
    }
}
