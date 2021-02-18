using GoogleBooks.DomainModel.Entities;
using System.Collections.Generic;

namespace GoogleBooks.Service.Abstract
{
    public interface IListBookFavoriteService
    {
        IList<Book> Execute();
    }
}