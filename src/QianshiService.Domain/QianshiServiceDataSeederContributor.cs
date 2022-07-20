using QianshiService.Authors;
using QianshiService.Books;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace QianshiService
{
    public class QianshiServiceDataSeederContributor
     : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public QianshiServiceDataSeederContributor(
            IRepository<Book, Guid> bookRepository, 
            IAuthorRepository authorRepository, 
            AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishTime = new DateTime(1949, 6, 8),
                    Price = 19.84f
                }, autoSave: true);

                await _bookRepository.InsertAsync(new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishTime = new DateTime(1995, 9, 27),
                    Price = 42.0f
                }, autoSave: true);
            }

            if(await _authorRepository.GetCountAsync() <= 0)
            {
                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "栗山未来",
                        new DateTime(2001, 06, 25),
                        "kuriyama balabala..."
                    ));


                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "千矢",
                        new DateTime(1999, 06, 25),
                        "qianshi balabala..."
                    ));
            }
        }
    }
}
