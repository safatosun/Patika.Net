using FluentAssertions;
using MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _dbContext;

        public DeleteCustomerCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        public void WhenCustomerIsNotFound_InvalidOperationException_ThrowsInvalidOperationException()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);

            command.CustomerId = 0;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("The customer could not find.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Customer_ShouldBeDeleted()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);

            command.CustomerId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == 1);
            customer.Should().BeNull();
        }



    }

}
