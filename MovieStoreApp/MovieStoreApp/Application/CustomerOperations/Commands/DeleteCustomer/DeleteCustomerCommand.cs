using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(c=>c.Id==CustomerId);
            if (customer is null)
                throw new InvalidOperationException("The customer could not find.");

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

        }
    }
}
