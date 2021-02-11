using GoogleBooks.DomainModel.Entities;
using System.Linq;

namespace GoogleBooks.DomainModel.Repositories.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        void Inserir(Book book);

        void Excluir(string Id);

        Book Retornar(string Id);
    }
}
