using GoogleBooks.DomainModel.Repositories.Abstract;
using GoogleBooks.Service.Abstract;

namespace GoogleBooks.Service.Concrete
{
    public class DeleteBookFavoriteService : IDeleteBookFavoriteService
    {
        private IBookRepository bookRepository;

        public DeleteBookFavoriteService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Execute(string id)
        {
            bookRepository.Excluir(id);
        }
    }
}
