using System.Threading.Tasks;

namespace GoogleBooks.Service.Abstract
{
    public interface IListGoobleBookService
    {
        Task<string> Execute(string query, int offset, int count);
    }
}
