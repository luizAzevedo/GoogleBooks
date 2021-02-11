using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleBooks.Services.Abstract
{
    public interface IGoobleBookService
    {
        Task<string> Execute(string query, int offset, int count);
    }
}
