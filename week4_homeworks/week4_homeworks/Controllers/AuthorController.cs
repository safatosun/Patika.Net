using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using week4_homeworks.DBOperations;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthors;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById;
using week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor;
using week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor;
using week4_homeworks.Applications.AuthorOperations.Commands.DeleteAuthor;

[ApiController]
[Route("authors")]
public class AuthorController : ControllerBase
{
	private readonly IBookStoreDbContext _context; 
	private readonly IMapper _mapper;
	public AuthorController(IBookStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult Get()
	{
		GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
		return Ok(query.Handle());
	}
	
	[HttpGet("{id:int}")]
	public IActionResult GetById([FromRoute]int id)
	{
		GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
        query.AuthorId = id;
        
		GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
		validator.ValidateAndThrow(query);

		var author = query.Handle();

        return Ok(author);
	}
	
	[HttpPost]
	public IActionResult Create([FromBody] CreateAuthorModel newAuthor)
	{
		CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

		command.Model = newAuthor;
		
		CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();

		return StatusCode(201);
	}
	
	[HttpPut("{id}")]
	public IActionResult Update(int id, [FromBody] UpdateAuthorModel updatedAuthor)
	{
		UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
		
		command.AuthorId = id;
		command.Model = updatedAuthor;
		
		UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
		
		command.AuthorId = id;
		
		DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
}