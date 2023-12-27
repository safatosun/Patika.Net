using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using week4_homeworks.Common;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.BookOperations.Queries.GetById
{
    public class GetByIdQuery
    {
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public GetByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {

            var book = _dbContext.Books.Include(b=>b.Genre).Where(x => x.Id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Book not found.");
            }

            BookViewModel Model = _mapper.Map<BookViewModel>(book);

            return Model;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }
}