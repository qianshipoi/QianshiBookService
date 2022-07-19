using System;

using Volo.Abp.Application.Dtos;

namespace QianshiService.Books
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishTime { get; set; }

        public float Price { get; set; }
    }
}
