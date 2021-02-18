using GoogleBooks.DomainModel.Entities;

namespace GoogleBooks.Service.Abstract
{
    public interface ICreateBookFavoriteService
    {
        void Execute(Book book);
    }
}