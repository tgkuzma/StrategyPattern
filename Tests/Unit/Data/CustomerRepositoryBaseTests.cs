using System;
using Data;
using Data.Repositories;
using Models;
using Models.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests.Unit.Data
{
    [TestFixture]
    public class CustomerRepositoryBaseTests
    {
        private CustomerRepositoryBaseTestClass _customerRepositoryBase;

        #region Setup / Tear Down

        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        [OneTimeSetUp]
        public void InitialSetup()
        {
        }

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        [OneTimeTearDown]
        public void FinalTearDown()
        {
        }

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        [SetUp]
        public void SetupForEachTest()
        {
            _customerRepositoryBase = new CustomerRepositoryBaseTestClass(new DataContext());
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
        public void GetByCustomerName_ThrowsErrorsForEmptyName()
        {
            // Arrange

            //Act

            ////Assert
            Assert.Throws<ArgumentException>(() => _customerRepositoryBase.GetCustomerByName(string.Empty));
        }

        [Test]
        public void GetCustomerDuration_ThrowsErrorsForCustomerNotFound()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(x => x.GetCustomerByName(It.IsAny<string>())).Returns((Customer)null);

            //Act

            ////Assert
            Assert.Throws<ApplicationException>(() => _customerRepositoryBase.GetCustomerDuration("some name"));
        }
    }

    internal class CustomerRepositoryBaseTestClass : CustomerRepositoryBase
    {
        public CustomerRepositoryBaseTestClass(DataContext context) : base(context)
        {
        }
    }
}