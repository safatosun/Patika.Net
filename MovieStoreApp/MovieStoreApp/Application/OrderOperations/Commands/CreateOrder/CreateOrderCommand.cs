using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public CreateOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {

            var customer = _dbContext.Customers.Include(c=>c.Orders).SingleOrDefault(c=>c.Id == Model.CustomerId);

            if (customer is null)
                throw new InvalidOperationException("The Customer could not find.");

            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == Model.MovieId);

            if (movie is null)
                throw new InvalidOperationException("The movie could not find.");

            var order = new Order
            {
                CustomerId = customer.Id,
                MovieId = movie.Id,
                OrderTime = DateTime.Now.Date,
                Price = movie.Price
            };

            customer.Orders.Add(order);
            _dbContext.SaveChanges();   

        }

    }

    public class CreateOrderModelDto
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }

}
