using AutoMapper;

using QianshiService.Authors;
using QianshiService.Books;

namespace QianshiService.Web;

public class QianshiServiceWebAutoMapperProfile : Profile
{
    public QianshiServiceWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
    }
}
