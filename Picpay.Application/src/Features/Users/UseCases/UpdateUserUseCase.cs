
using Picpay.Application.Features.Users.Data;
using Picpay.Application.Features.Users.Entities;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class is responsible for updating a User using a given repository.
/// </summary>
public class UpdateUserUseCase
{
    private readonly IUserRepository _UserRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateUserUseCase"/> class.
    /// </summary>
    /// <param name="UserRepository">The User repository.</param>
    public UpdateUserUseCase(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    /// <summary>
    /// Executes the update of a User.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be updated.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<User> Execute(UpdateUser dto)
    => _UserRepository.Save(dto.ToModel());
}

  

/// <summary>
/// Represents a data object for updating a User
/// </summary>
public class UpdateUser
{
    
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id {get; set;} = default!;
    

	
    /// <summary>
    /// Fullname
    /// </summary>
    /// <example>Fullname</example>
    public string Fullname {get; set;} = default!;
    

	
    /// <summary>
    /// CPF
    /// </summary>
    /// <example>CPF</example>
    public string CPF {get; set;} = default!;
    

	
    /// <summary>
    /// Email
    /// </summary>
    /// <example>Email</example>
    public string Email {get; set;} = default!;
    

	
    /// <summary>
    /// Password
    /// </summary>
    /// <example>Password</example>
    public string Password {get; set;} = default!;
    

	
    /// <summary>
    /// Salt
    /// </summary>
    /// <example>Salt</example>
    public string Salt {get; set;} = default!;
    

	
    /// <summary>
    /// Balance
    /// </summary>
    /// <example>Balance</example>
    public decimal Balance {get; set;} 
    

    
    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public User ToModel()
    => new()
    {
      Id = Id,
	Fullname = Fullname,
	CPF = CPF,
	Email = Email,
	Password = Password,
	Salt = Salt,
	Balance = Balance
    };
    

}
    