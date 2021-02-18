using GoogleBooks.DomainModel.Entities;
using GoogleBooks.DomainModel.Repositories.Abstract;
using GoogleBooks.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace GoogleBooks.Service.Concrete
{
    public class ListBookFavoriteService : IListBookFavoriteService
    {
        private IBookRepository bookRepository;

        public ListBookFavoriteService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IList<Book> Execute()
        {
            return bookRepository.Books.ToList();
        }
    }
}
