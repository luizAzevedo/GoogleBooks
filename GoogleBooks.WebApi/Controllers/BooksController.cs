using GoogleBooks.Services.Abstract;
using System.Threading.Tasks;
using System.Web.Http;

namespace GoogleBooks.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private IGoobleBookService googleBooksService;
        public BooksController(IGoobleBookService googleBooksService)
        {
            this.googleBooksService = googleBooksService;
        }

        public async Task<string> Get(string p)
        {
            return await googleBooksService.Execute(p, 0, 40);
        }
    }
}
