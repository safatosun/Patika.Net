using AutoMapper;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommand
	{
		public int AuthorId { get; set; }
		public UpdateAuthorModel Model { get; set; }

		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public UpdateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);

			if (author is null)
				throw new InvalidOperationException("Author could not found.");

			_mapper.Map(Model, author);

			_dbContext.SaveChanges();
		}

	}

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }

}