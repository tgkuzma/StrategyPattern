using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using Business;
using Data;
using Data.Repositories;
using NUnit.Framework;

namespace Tests.BusinessTests.Integration
{
    [TestFixture]
    public class SqlServerCustomerRepositoryTests
    {
        private SqlServerCustomerRepository _customerRepository;
        private DataContext _context;
        private CustomerManager _customerManager;

        #region Setup / Tear Down

        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        [OneTimeSetUp]
        public void InitialSetup()
        {
            //_context = new DataContext();
        }

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        [OneTimeTearDown]
        public void FinalTearDown()
        {
            //_context.Database.Delete();
        }

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        [SetUp]
        public void SetupForEachTest()
        {
            //_context.Database.Delete();
            //_customerRepository = new SqlServerCustomerRepository(_context);
            //_customerManager = new CustomerManager(_customerRepository);
        }

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        [TearDown]
        public void TearDownForEachTest()
        {
        }

        #endregion Setup / Tear Down

        //[Test]
        //public void GetAllCustomers_ReturnsAtLeastOneCustomer()
        //{
        //    // Arrange

        //    //Act
        //    var customers = _customerManager.GetAllCustomers();

        //    //Assert
        //    Assert.IsTrue(customers.Any());
        //}

        //[Test]
        //public void GetCustomerDuration_ReturnsDurationForCustomer()
        //{
        //    // Arrange
        //    var customer = _customerManager.GetAllCustomers().FirstOrDefault();

        //    //Act
        //    var duration = _customerManager.GetCustomerDuration(customer.CustomerName);

        //    //Assert
        //    Assert.Greater(duration, 0);

        //}

        //[Test]
        //public void GetCustomerDuration_XXX()
        //{
        //    // Arrange
        //    var dbContext = new DataContext("MySqlContext");

        //    var repository = new MySqlCustomerRepository(dbContext);
        //    var manager = new CustomerManager(repository);
        //    var customer = manager.GetAllCustomers().FirstOrDefault();

        //    //Act
        //    var duration = manager.GetCustomerDuration(customer.CustomerName);

        //    //Assert
        //    Assert.Greater(duration, 0);

        //}
    }
}
