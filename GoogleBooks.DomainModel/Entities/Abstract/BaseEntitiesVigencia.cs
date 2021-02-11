using System;

namespace GoogleBooks.DomainModel.Entities.Abstract
{
    public abstract class BaseEntities
    {
        public BaseEntities()
        {
            CreationDate = DateTime.Now;
            Status = true;
        }

        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public bool Status { get; set; }
    }
}
