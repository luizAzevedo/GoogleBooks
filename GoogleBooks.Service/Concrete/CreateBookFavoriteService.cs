using GoogleBooks.DomainModel.Entities;
using GoogleBooks.DomainModel.Repositories.Abstract;
using GoogleBooks.Service.Abstract;

namespace GoogleBooks.Service.Concrete
{
    public class CreateBookFavoriteService : ICreateBookFavoriteService
    {
        private IBookRepository bookRepository;

        public CreateBookFavoriteService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Execute(Book book)
        {
            bookRepository.Inserir(book);
        }
    }
}
