using GoogleBooks.DomainModel.Entities;
using GoogleBooks.DomainModel.Repositories.Abstract;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace GoogleBooks.DomainModel.Repositories.Concrete
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private GoogleBooksContext googleBooksContext = new GoogleBooksContext();

        public BookRepository(GoogleBooksContext googleBooksContext)
        {
            this.googleBooksContext = googleBooksContext;
        }

        public IQueryable<Book> Books => googleBooksContext.Books.AsQueryable();

        public void Excluir(string Id)
        {
            var result = Books.Where(a => a.Id == Id)
                              .ToList();
            if (!result.Any())
                throw new InvalidOperationException("Livro não localizado!");

            try
            {
                var _book = result.FirstOrDefault();
                _book.Status = false;
                googleBooksContext.Entry(_book).State = EntityState.Modified;

                //googleBooksContext.Books.Remove(result.FirstOrDefault());

                googleBooksContext.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                string msgErro = string.Empty;
                foreach (var erro in googleBooksContext.GetValidationErrors())
                    foreach (var detalheErro in erro.ValidationErrors)
                        msgErro += detalheErro.ErrorMessage + "\n";

                throw new InvalidOperationException(msgErro);
            }
        }

        public void Inserir(Book book)
        {
            var result = Books.Where(a => a.Title.ToUpper() == book.Title.ToUpper() && a.Subtitle == book.Subtitle)
                              .ToList();
            if (result.Any())
                throw new InvalidOperationException("Já existe Livro cadastrado com este título e subtítulo!");

            try
            {
                googleBooksContext.Books.Add(book);
                googleBooksContext.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                string msgErro = string.Empty;
                foreach (var erro in googleBooksContext.GetValidationErrors())
                    foreach (var detalheErro in erro.ValidationErrors)
                        msgErro += detalheErro.ErrorMessage + "\n";

                googleBooksContext.Entry(book).State = EntityState.Detached;

                throw new InvalidOperationException(msgErro);
            }
        }

        public Book Retornar(string Id) => Books.Where(a => a.Id == Id).FirstOrDefault();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                googleBooksContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
