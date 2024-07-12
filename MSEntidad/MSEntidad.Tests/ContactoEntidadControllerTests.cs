using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MSEntidad.Api.Controllers;
using MSEntidad.Core.DTOs;
using MSEntidad.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MSEntidad.Tests
{
    public class ContactoEntidadControllerTests
    {
        private readonly Mock<IContactoEntidadService> _serviceMock;
        private readonly Mock<IValidator<ContactoEntidadRequest>> _validatorMock;
        private readonly ContactoEntidadController _controller;

        public ContactoEntidadControllerTests()
        {
            _serviceMock = new Mock<IContactoEntidadService>();
            _validatorMock = new Mock<IValidator<ContactoEntidadRequest>>();
            _controller = new ContactoEntidadController(_serviceMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task GetContactosEntidades_ReturnsOkResult_WithListOfContactos()
        {
            // Arrange
            var contactos = new List<ContactoEntidadResponse> { new ContactoEntidadResponse { Id = 1, Nombres = "Test" } };
            _serviceMock.Setup(service => service.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(contactos);

            // Act
            var result = await _controller.GetContactosEntidades(CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ContactoEntidadResponse>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetContactoEntidadById_ReturnsOkResult_WithContacto()
        {
            // Arrange
            var contacto = new ContactoEntidadResponse { Id = 1, Nombres = "Test" };
            _serviceMock.Setup(service => service.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>())).ReturnsAsync(contacto);

            // Act
            var result = await _controller.GetContactoEntidadById(1, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ContactoEntidadResponse>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }
    }
}
