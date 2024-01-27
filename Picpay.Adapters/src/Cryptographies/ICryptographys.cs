namespace Picpay.Adapters.Cryptographies;

public interface ICryptographys
{
    string GenenateSalt();

    (string HashedPassword, string Salt) Hash(string password, string salt);

    (string HashedPassword, string Salt) HashPassword(string password);

    bool VerifyPassword(string password, string storedHashedPassword, string storedSalt);
}
