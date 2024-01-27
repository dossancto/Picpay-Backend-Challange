using Picpay.Adapters.Cryptographies;
namespace Picpay.Infra.Providers;

public class TheWorstCrypt : ICryptographys
{
    public string GenenateSalt()
    => "<somesalt>";

    public (string HashedPassword, string Salt) Hash(string password, string salt)
        => (password + salt, salt);

    public (string HashedPassword, string Salt) HashPassword(string password)
    => Hash(password, GenenateSalt());

    public bool VerifyPassword(string password, string storedHashedPassword, string storedSalt)
      => storedHashedPassword == Hash(password, storedSalt).HashedPassword;
}

