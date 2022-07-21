﻿using QianshiService.Authors;
using QianshiService.Permissions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace QianshiService.Books
{
    public class BookAppService : CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public BookAppService(
            IRepository<Book, Guid> repository,
            IAuthorRepository authorRepository)
            : base(repository)
        {
            GetPolicyName = QianshiServicePermissions.Books.Default;
            GetListPolicyName = QianshiServicePermissions.Books.Default;
            CreatePolicyName = QianshiServicePermissions.Books.Create;
            UpdatePolicyName = QianshiServicePermissions.Books.Edit;
            DeletePolicyName = QianshiServicePermissions.Books.Delete;
            _authorRepository = authorRepository;
        }

        public override async Task<BookDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from book in queryable
                        join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
                        where book.Id == id
                        select new { book, author };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException();
            }

            var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);
            bookDto.AuthorName = queryResult.author.Name;

            return bookDto;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from book in queryable
                        join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
                        select new { book, author };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();


            return new PagedResultDto<BookDto>(totalCount, bookDtos);
        }

        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrWhiteSpace())
            {
                return $"book.{nameof(Book.Name)}";
            }

            if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace("authorName", "author.name", StringComparison.OrdinalIgnoreCase);
            }

            return $"book.{sorting}";
        }

    }
}
