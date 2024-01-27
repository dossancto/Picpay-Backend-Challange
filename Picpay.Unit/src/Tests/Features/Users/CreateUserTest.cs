using Picpay.Application.Features.Users.UseCases;

namespace Picpay.Unit.Tests.Features.Users;

public class CreateUserTest
{
    private readonly CreateUserUseCase _createUser;

    public CreateUserTest(CreateUserUseCase createUser)
    {
        _createUser = createUser;
    }

    [Fact]
    public async Task SuccessfullyCreateUser()
    {
        //Given
        var dto = new CreateUser
        {
            Fullname = "John Doe",
            CPF = "00000000000",
            Email = "john@example.com",
            Password = "Password"
        };

        //When
        var createdUser = await _createUser.Execute(dto);

        //Then
        Assert.Equal(250, createdUser.Balance);
    }

}
