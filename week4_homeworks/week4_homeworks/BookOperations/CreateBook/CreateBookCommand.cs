using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using week4_homeworks.DBOperations;

namespace week4_homeworks.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}

        private readonly BookStoreDbContext dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext _dbContext, IMapper mapper)
        {
            dbContext = _dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book =  dbContext.Books.SingleOrDefault(x=> x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("The book already exists");
            }
            book = _mapper.Map<Book>(Model);
            
            
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}