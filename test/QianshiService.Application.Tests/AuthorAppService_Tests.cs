using QianshiService.Authors;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace QianshiService
{
    public class AuthorAppService_Tests : QianshiServiceApplicationTestBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorAppService_Tests()
        {
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Authors_Without_Any_Filter()
        {
            var result = await _authorAppService.GetListAsync(new GetAuthorListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(author => author.Name == "千矢");
            result.Items.ShouldContain(author => author.Name == "栗山未来");
        }

        [Fact]
        public async Task Should_Get_Filtered_Authors()
        {
            var result = await _authorAppService.GetListAsync(new GetAuthorListDto
            {
                Filter = "千矢"
            });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(author => author.Name == "千矢");
            result.Items.ShouldNotContain(author => author.Name == "栗山未来");
        }

        [Fact]
        public async Task Should_Create_A_New_Author()
        {
            var authorDto = await _authorAppService.CreateAsync(new CreateAuthorDto
            {
                 Name = "张三",
                 BirthDate = DateTime.Now,
                 ShortBio = "zhangsan balabala..."
            });

            authorDto.Id.ShouldNotBe(Guid.Empty);
            authorDto.Name.ShouldBe("张三");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Author()
        {
            await Assert.ThrowsAsync<AuthorAlreadyExistsException>((Func<Task>)(async () =>
            {
                await _authorAppService.CreateAsync(new CreateAuthorDto
                {
                    Name = "千矢",
                    BirthDate= DateTime.Now,
                    ShortBio = "qianshi balabala..."
                });
            }));
        }
    }
}
