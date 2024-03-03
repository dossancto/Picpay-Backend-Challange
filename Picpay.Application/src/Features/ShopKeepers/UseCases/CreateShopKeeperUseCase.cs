using Picpay.Adapters.Cryptographies;

using Picpay.Domain.Features.Mercant.Entities;

using Picpay.Application.Features.Accounts.UseCases;
using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.ShopKeepers.UseCases;

/// <summary>
/// This class is responsible for creating a ShopKeeper using a given repository.
/// </summary>
public class CreateShopKeeperUseCase : IUseCase
{
    private readonly IShopKeeperRepository _shopKeeperRepository;
    private readonly ICryptographys _cryptographys;

    private const decimal INITIAL_CASH = 1500;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateShopKeeperUseCase"/> class.
    /// </summary>
    public CreateShopKeeperUseCase(IShopKeeperRepository ShopKeeperRepository, ICryptographys cryptographys)
    {
        _shopKeeperRepository = ShopKeeperRepository;
        _cryptographys = cryptographys;
    }

    /// <summary>
    /// Executes the creation of a ShopKeeper.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the ShopKeeper to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<ShopKeeper> Execute(CreateShopKeeper dto)
    {
        var (password, salt) = _cryptographys.HashPassword(dto.Password);

        var entity = dto.ToModel(salt);

        entity.HashedPassword = password;
        entity.Balance = INITIAL_CASH;

        return _shopKeeperRepository.Save(entity);
    }
}

/// <summary>
/// Represents a data object for creating a ShopKeeper
/// </summary>
public record CreateShopKeeper : CreteAccount
{
    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    public new ShopKeeper ToModel(string salt)
    => new()
    {
        Fullname = Fullname,
        CPF = CPF,
        Email = Email,
        HashedPassword = string.Empty,
        Salt = salt,
        Balance = 0m
    };
}

