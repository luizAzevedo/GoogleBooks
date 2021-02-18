using GoogleBooks.DomainModel.Entities;
using GoogleBooks.Service.Abstract;
using System.Collections.Generic;
using System.Web.Http;

namespace GoogleBooks.WebApi.Controllers
{
    [RoutePrefix("api/book")]
    public class FavoritesController : ApiController
    {
        private ICreateBookFavoriteService createBookFavoriteService;
        private IListBookFavoriteService listBookFavoriteService;
        private IDeleteBookFavoriteService deleteBookFavoriteService;
        public FavoritesController(ICreateBookFavoriteService createBookFavoriteService,
                                   IListBookFavoriteService listBookFavoriteService,
                                   IDeleteBookFavoriteService deleteBookFavoriteService)
        {
            this.createBookFavoriteService = createBookFavoriteService;
            this.listBookFavoriteService = listBookFavoriteService;
            this.deleteBookFavoriteService = deleteBookFavoriteService;
        }

        [Route("favorites")]
        public IList<Book> Get()
        {
            return listBookFavoriteService.Execute();
        }

        [Route("{id}/favorite")]
        public void Post(int id, [FromBody] Book book)
        {
            createBookFavoriteService.Execute(book);
        }


        [Route("{id}/favorite")]
        public void Delete(int id)
        {
            deleteBookFavoriteService.Execute(id.ToString());
        }
    }
}
