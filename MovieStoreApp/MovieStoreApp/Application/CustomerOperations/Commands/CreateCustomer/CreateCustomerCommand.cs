using AutoMapper;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {

        public CreateCustomerModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(c=>c.Email == Model.Email.Trim());
            if (customer is not null)
            {
                throw new InvalidOperationException("The Customer already exists.");
            }

            customer = _mapper.Map<Customer>(Model);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();   
        }


    }

    public class CreateCustomerModelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
