using AutoMapper;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;

namespace week4_homeworks.Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }

        private readonly IBookStoreDbContext dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDbContext _dbContext, IMapper mapper)
        {
            dbContext = _dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = dbContext.Users.SingleOrDefault(u => u.Email == Model.Email);

            if (user is not null)
            {
                throw new InvalidOperationException("The user already exists");
            }

            user = _mapper.Map<User>(Model );


            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
