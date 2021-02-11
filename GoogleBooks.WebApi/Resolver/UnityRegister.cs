using GoogleBooks.DomainModel.Repositories.Abstract;
using GoogleBooks.DomainModel.Repositories.Concrete;
using GoogleBooks.Services.Abstract;
using GoogleBooks.Services.Concrete;
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
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IGoobleBookService, GoogleBookService>("GoogleBookService", TypeLifetime.Scoped);
            container.RegisterType<IGoobleBookService, GoogleBookService>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}