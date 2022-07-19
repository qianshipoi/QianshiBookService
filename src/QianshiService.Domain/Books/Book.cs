using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace QianshiService.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishTime { get; set; }

        public float Price { get; set; }
    }
}
