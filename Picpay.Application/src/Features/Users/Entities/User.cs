
namespace Picpay.Application.Features.Users.Entities;

/// <summary>
/// User
/// </summary>
public class User
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
    
}
    