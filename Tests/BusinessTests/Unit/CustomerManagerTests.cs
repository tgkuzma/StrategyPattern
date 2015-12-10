using System;
using System.Collections.Generic;
using Business;
using Business.Interfaces;
using Models;
using Moq;
using NUnit.Framework;

namespace Tests.BusinessTests.Unit
{
    [TestFixture]
    public class CustomerManagerTests
    {
        private Mock<ICustomerRepository> _mockCustomerRepository;
        private CustomerManager _customerManager;

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
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerManager = new CustomerManager(_mockCustomerRepository.Object);
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
        public void GetAllCustomers_CallsRepositoryOnce()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetAll()).Returns(new List<Customer>());

            //Act
            _customerManager.GetAllCustomers();

            //Assert
            _mockCustomerRepository.Verify(x => x.GetAll(), Times.Once);
        }


        [Test]
        public void GetCustomerById_CallsRepositoryOnce()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Customer());

            //Act
            _customerManager.GetCustomerById(1);

            //Assert
            _mockCustomerRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetCustomerByName_ThrowsErrorForNullArgument()
        {
            // Arrange

            //Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => _customerManager.GetCustomerByName(string.Empty));
            Assert.That(ex.Message, Does.Contain("is required"));
        }

        [Test]
        public void GetCustomerByName_CallsRepositoryOnce()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetByCustomerName(It.IsAny<string>())).Returns(new Customer());

            //Act
            _customerManager.GetCustomerByName("x");

            //Assert
            _mockCustomerRepository.Verify(x => x.GetByCustomerName(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddCustomer_CallsRepositoryTwice()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.Add(It.IsAny<Customer>()));

            //Act
            _customerManager.AddCustomer(new Customer());

            //Assert
            _mockCustomerRepository.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
            _mockCustomerRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteCustomer_CallsRepositoryTwice()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.Delete(It.IsAny<Customer>()));

            //Act
            _customerManager.DeleteCustomer(new Customer());

            //Assert
            _mockCustomerRepository.Verify(x => x.Delete(It.IsAny<Customer>()), Times.Once);
            _mockCustomerRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetCustomerDuration_WithInvalidId_CallsRepositoryOnce_ThrowsErrorForNoCustomerFound()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetById(It.IsAny<int>()));

            //Act

            ////Assert
            var ex = Assert.Throws<ApplicationException>(() => _customerManager.GetCustomerDuration(1));
            Assert.That(ex.Message, Does.Contain("does not exist"));
            _mockCustomerRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetCustomerDuration_WithValidId_CallsRepositoryTwice()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Customer
            {
                Id = 1,
                DateActive = DateTime.Now,
                CustomerName = "Bob LeBlaw",
                Address = "Anywhere"
            });

            //Act
            _customerManager.GetCustomerDuration(1);

            ////Assert
            _mockCustomerRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            _mockCustomerRepository.Verify(x => x.GetCustomerDuration(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GetCustomerDuration_WithName_CallsRepositoryOnce()
        {
            // Arrange
            _mockCustomerRepository.Setup(x => x.GetCustomerDuration(It.IsAny<string>()));

            //Act
            _customerManager.GetCustomerDuration("x");

            ////Assert
            _mockCustomerRepository.Verify(x => x.GetCustomerDuration(It.IsAny<string>()), Times.Once);
        }
    }
}