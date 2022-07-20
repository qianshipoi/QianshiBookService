
using Volo.Abp.Application.Dtos;

namespace QianshiService.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
