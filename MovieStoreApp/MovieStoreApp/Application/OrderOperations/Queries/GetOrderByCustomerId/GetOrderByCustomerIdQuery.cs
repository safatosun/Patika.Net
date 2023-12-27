using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderById;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.OrderOperations.Queries.GetOrderByCustomerId
{
    public class GetOrderByCustomerIdQuery
    {
        public int CustomerId { get; set; }
        public OrderViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByCustomerIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CustomerOrderViewModel> Handle()
        {
            var order = _dbContext.Orders.Include(o => o.Movie).Include(o => o.Customer).Where(o=>o.CustomerId == CustomerId).ToList();

            if (order is null)
                throw new InvalidOperationException("The order could not find.");

            var orderVm = _mapper.Map<List<CustomerOrderViewModel>>(order);

            return orderVm;
        }
    }

    public class CustomerOrderViewModel
    {
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public int Price { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
