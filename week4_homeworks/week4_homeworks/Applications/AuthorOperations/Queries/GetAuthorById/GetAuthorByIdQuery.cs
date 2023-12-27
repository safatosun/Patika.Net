using AutoMapper;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById
{
	public class GetAuthorByIdQuery
	{
		public int AuthorId { get; set; }

		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetAuthorByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public AuthorDetailViewModel Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);

			if (author is null)
				throw new InvalidOperationException("The Author could not found.");

			AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);


			return vm;
		}
	}

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthdate { get; set; }
    }

}