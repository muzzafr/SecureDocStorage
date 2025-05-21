using Xunit;
using Moq;
using SecureDocStorage.Controllers;
using SecureDocStorage.Services;
using SecureDocStorage.Data;
using Microsoft.EntityFrameworkCore;
using SecureDocStorage.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SecureDocStorage.Tests
{
    public class AuthControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationDbContext(options);

            var jwtServiceMock = new Mock<JwtService>(null);
            jwtServiceMock.Setup(x => x.GenerateToken(It.IsAny<int>(), It.IsAny<string>())).Returns("fake-jwt");

            _controller = new AuthController(_context, jwtServiceMock.Object);
        }

        [Fact]
        public async Task Register_ShouldCreateNewUser()
        {
            var dto = new RegisterDto
            {
                Username = "testuser",
                Password = "password123"
            };

            var result = await _controller.Register(dto);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
