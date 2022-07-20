using AutoMapper;

using QianshiService.Books;

namespace QianshiService.Web;

public class QianshiServiceWebAutoMapperProfile : Profile
{
    public QianshiServiceWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<BookDto, CreateUpdateBookDto>();
    }
}
