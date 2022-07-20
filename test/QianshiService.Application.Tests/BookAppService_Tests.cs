using QianshiService.Books;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

using Xunit;

namespace QianshiService
{
    public class BookAppService_Tests : QianshiServiceApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "1984");
        }

        [Fact]
        public async Task Should_Create_A_Vaild_Book()
        {
            var result = await _bookAppService.CreateAsync(new CreateUpdateBookDto
            {
                Name = "千矢",
                Price = 10,
                PublishDate = DateTime.Now,
                Type = BookType.Biography
            });

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("千矢"); 
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

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }

    }
}
