namespace Picpay.Application.Features.Transfer.Exceptions;

/// <summary>
/// If the Account does not have sufficient ammount.
/// </summary>
public class TransferInsufientAmmountException : TransferException
{
    private static readonly string DefaultMessage = "The Account does not have sufficient ammount to this transfer.";
    /// <summary>
    /// The account Id of the user that can't transfer.
    /// </summary>
    public string AccountId { get; }

    /// <summary>
    /// The transaction required ammount
    /// </summary>
    public decimal RequiredAmmount { get; }

    /// <summary>
    /// The actual balance of the account
    /// </summary>
    public decimal AccountBalance { get; }

    /// <summary>
    /// Instanciates the excepetion with userid
    /// </summary>
    public TransferInsufientAmmountException(string msg, string accountId,
        decimal requiredAmmount, decimal accountBalance)
      : base(msg)
    {
        AccountId = accountId;
        RequiredAmmount = requiredAmmount;
        AccountBalance = accountBalance;
    }

    /// <summary>
    /// Instanciates the excepetion with userid with a default message
    /// </summary>
    public TransferInsufientAmmountException(string accountId, decimal requiredAmmount,
        decimal accountBalance)
      : this(DefaultMessage, accountId, requiredAmmount, accountBalance) { }
}

