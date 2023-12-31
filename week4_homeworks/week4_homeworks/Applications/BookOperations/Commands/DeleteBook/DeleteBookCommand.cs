﻿using Microsoft.EntityFrameworkCore;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {

        public int BookId { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Book not found.");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }

}
