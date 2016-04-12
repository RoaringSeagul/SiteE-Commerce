using GrosBrasInc.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GrosBrasInc.Tests;

namespace GrosBrasInc.Tests.Models
{
    /// <summary>
    /// Auteur: Jonathan Koch-Roy
    /// Date: 
    /// Description: 
    /// </summary>
    [TestFixture]
    class OrderTest
    {
        [Test]
        public void ShouldPassTestDeValidation()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = "test",
                LastName = "test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj).Count == 0);
        }

        [Test]
        public void ShouldNotPassTestDeValidationFirstName()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = null,
                LastName = "test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "First name is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationLastName()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = "test",
                LastName = null,
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Last name is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationAddress()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = null,
                City = "test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Address is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationCity()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = null,
                Country = "test",
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "City is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationState()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = null,
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "State is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationPostalCode()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = "test",
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = null,
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Postal code is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationCountry()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = null,
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "435 546-7890",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Country is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationPhone()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = "Test",
                Email = "test@test.ca",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = null,
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Phone is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationEmailAddress()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = "Test",
                Email = null,
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "Test",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Email Address is required");
        }

        [Test]
        public void ShouldNotPassTestDeValidationEmailAddressNotValid()
        {
            var obj = new Order()
            {
                Username = "Test",
                Address = "Test",
                City = "Test",
                Country = "Test",
                Email = "test",
                FirstName = "Test",
                LastName = "Test",
                OrderDate = DateTime.Now,
                OrderId = 1,
                Phone = "Test",
                PostalCode = "test",
                State = "test",
                Total = 12.66f
            };
            Assert.IsTrue(ValidateModel(obj)[0].ErrorMessage == "Email is is not valid.");
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
