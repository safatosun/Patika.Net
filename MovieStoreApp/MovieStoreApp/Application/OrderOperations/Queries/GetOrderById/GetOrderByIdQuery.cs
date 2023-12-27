using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.OrderOperations.Queries.GetOrderById
{
    public class GetOrderByIdQuery
    {
        public int OrderId { get; set; }
        public OrderViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            var order = _dbContext.Orders.Include(o=>o.Movie).Include(o=>o.Customer).SingleOrDefault(o=>o.Id==OrderId);
            
            if (order is null)
                throw new InvalidOperationException("The order could not find.");

            var orderVm = _mapper.Map<OrderViewModel>(order);

            return orderVm; 
        }

    }

    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public int Price { get; set; }
        public DateTime OrderTime { get; set; }
    }

}
