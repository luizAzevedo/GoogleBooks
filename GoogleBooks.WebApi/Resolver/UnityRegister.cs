using GoogleBooks.DomainModel.Repositories.Abstract;
using GoogleBooks.DomainModel.Repositories.Concrete;
using GoogleBooks.Service.Abstract;
using GoogleBooks.Service.Concrete;
using Unity;
using Unity.Lifetime;

namespace GoogleBooks.WebApi.Resolver
{
    public class UnityRegister
    {
        public UnityContainer Container()
        {
            var container = new UnityContainer();

            //container.RegisterType<IBookRepository, BookRepository>("BookRepository", TypeLifetime.Scoped);
            //container.RegisterType<IGoobleBookService, GoogleBookService>("GoogleBookService", TypeLifetime.Scoped);

            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ICreateBookFavoriteService, CreateBookFavoriteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeleteBookFavoriteService, DeleteBookFavoriteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IListBookFavoriteService, ListBookFavoriteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IListGoobleBookService, ListGoogleBookService>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}