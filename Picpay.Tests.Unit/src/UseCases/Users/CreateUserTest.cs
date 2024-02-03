using Picpay.Domain.Exceptions;
using Picpay.Adapters.Cryptographies;
using Picpay.Application.Features.Accounts.Validations;
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
            CPF = "66583552078",
            Fullname = "John Doe",
            Password = "S#cur3Password"
        };

        var userRepository = new Mock<IUserRepository>();

        userRepository
          .Setup(x => x.Save(It.IsAny<User>()))
          .ReturnsAsync(new User());

        var cryptographys = new Mock<ICryptographys>();
        var creeateuservalidator = new CreateAccountValidation();

        cryptographys.Setup(x => x.HashPassword("ALongAndSecurePassword")).Returns(("", ""));

        var usecase = new CreateUserUseCase(userRepository.Object, cryptographys.Object, creeateuservalidator);

        // Act
        await usecase.Execute(request);

        // Assert
        userRepository.Verify(r => r.Save(It.IsAny<User>()));
    }
}
