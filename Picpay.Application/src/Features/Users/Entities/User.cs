namespace Picpay.Application.Features.Users.Entities;

public class User
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string HashedPassword { get; set; } = default!;

    public string Salt { get; set; } = default!;
}
