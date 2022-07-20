using AutoMapper;

using QianshiService.Authors;
using QianshiService.Books;

namespace QianshiService;

public class QianshiServiceApplicationAutoMapperProfile : Profile
{
    public QianshiServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();
    }
}
