using System.Linq;
using System.Runtime.InteropServices;
using Business;
using Data;
using Data.Repositories;
using NUnit.Framework;

namespace Tests.Integration
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
            _context = new DataContext("SqlServerContext");
        }

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        [OneTimeTearDown]
        public void FinalTearDown()
        {
            _context.Database.Connection.Close();
            _context.Database.Delete();
        }

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        [SetUp]
        public void SetupForEachTest()
        {
            _customerRepository = new SqlServerCustomerRepository(_context);
            _customerManager = new CustomerManager(_customerRepository);
        }

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        [TearDown]
        public void TearDownForEachTest()
        {
        }

        #endregion Setup / Tear Down

        [Test]
        public void GetAllCustomers_ReturnsAtLeastOneCustomer()
        {
            // Arrange

            //Act
            var customers = _customerManager.GetAllCustomers();

            //Assert
            Assert.IsTrue(customers.Any());
        }

        [Test]
        public void GetByCustomerName_ReturnsCustomer()
        {
            // Arrange
            var customerName = "Trenton";

            //Act
            var customer = _customerManager.GetCustomerByName(customerName);

            //Assert
            Assert.AreEqual(customerName, customer.CustomerName);
        }

        [Test]
        public void GetCustomerDuration_ReturnsNumberGreaterThanZero()
        {
            // Arrange
            var customer = _customerManager.GetAllCustomers().FirstOrDefault();

            //Act
            var duration = _customerManager.GetCustomerDuration(customer.CustomerName);

            //Assert
            Assert.Greater(0, duration);
        }

        [Test]
        public void GetCustomerDuration_Returns3()
        {
            // Arrange
            var customer = _customerManager.GetAllCustomers().FirstOrDefault();

            //Act
            var duration = _customerManager.GetCustomerDuration(customer.CustomerName);

            //Assert
            Assert.AreEqual(3, duration);
        }

        [Test]
        public void XXXX()
        {
            SystemDateManager.SetSystemDate(12,22,1968);
        }
    }
}