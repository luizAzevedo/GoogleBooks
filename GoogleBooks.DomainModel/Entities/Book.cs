using GoogleBooks.DomainModel.Entities.Abstract;

namespace GoogleBooks.DomainModel.Entities
{
    public class Book: BaseEntities
    {
        public string Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Subtitle
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
    }
}
