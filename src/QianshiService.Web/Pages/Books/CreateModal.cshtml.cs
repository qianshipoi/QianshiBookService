using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using QianshiService.Books;

using System.Threading.Tasks;

namespace QianshiService.Web.Pages.Books
{
    public class CreateModalModel : QianshiServicePageModel
    {
        private readonly IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        public void OnGet()
        {
            Book = new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}
