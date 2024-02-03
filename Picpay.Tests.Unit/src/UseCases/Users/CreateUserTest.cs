using Picpay.Adapters.Cryptographies;
using Picpay.Application.Features.Users.Data;
using Picpay.Application.Features.Users.UseCases;
using Picpay.Domain.Features.Users.Entities;

namespace Picpay.Tests.Unit.UseCases.Users;

public class CreateUserTest
{
    [Fact]
    public async Task Success_Create_ValidInfos()
    {
        // Arrange
        var request = new CreateUser
        {
            Email = "test@example.com",
            CPF = "000",
            Fullname = "John Doe",
            Password = "ALongAndSecurePassword"
        };

        var userRepository = new Mock<IUserRepository>();

        userRepository
          .Setup(x => x.Save(It.IsAny<User>()))
          .ReturnsAsync(new User());

        var cryptographys = new Mock<ICryptographys>();

        cryptographys.Setup(x => x.HashPassword("ALongAndSecurePassword")).Returns(("", ""));

        var usecase = new CreateUserUseCase(userRepository.Object, cryptographys.Object);

        // Act
        await usecase.Execute(request);

        // Assert
        userRepository.Verify(r => r.Save(It.IsAny<User>()));
    }
}
