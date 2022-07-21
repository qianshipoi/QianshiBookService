using QianshiService.Authors;
using QianshiService.Books;

using Shouldly;

using System;
using System.Linq;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

using Xunit;

namespace QianshiService
{
    public class BookAppService_Tests : QianshiServiceApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IAuthorAppService _authorAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "1984" && b.AuthorName == "千矢");
        }

        [Fact]
        public async Task Should_Create_A_Vaild_Book()
        {
            var authors = await _authorAppService.GetListAsync(new GetAuthorListDto());
            var firstAuthor = authors.Items.First();

            var result = await _bookAppService.CreateAsync(new CreateUpdateBookDto
            {
                AuthorId = firstAuthor.Id,
                Name = "千矢",
                Price = 10,
                PublishDate = DateTime.Now,
                Type = BookType.Biography
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("千矢");
            result.AuthorId.ShouldBe(firstAuthor.Id);
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
           {
               await _bookAppService.CreateAsync(new CreateUpdateBookDto
               {
                   Name = "",
                   Price = 10,
                   PublishDate = DateTime.Now,
                   Type = BookType.Biography
               });
           });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
