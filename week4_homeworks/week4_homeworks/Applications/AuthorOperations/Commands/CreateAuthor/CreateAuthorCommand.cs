using AutoMapper;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;

namespace week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommand
	{
		public CreateAuthorModel Model { get; set; }

		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var author = _dbContext.Authors.FirstOrDefault(a => a.Name == Model.Name);

			if (author is not null)
				throw new InvalidOperationException("Author is already exists.");

			author = _mapper.Map<Author>(Model);

			_dbContext.Authors.Add(author);
			_dbContext.SaveChanges();

		}

	}

    public class CreateAuthorModel 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }

}