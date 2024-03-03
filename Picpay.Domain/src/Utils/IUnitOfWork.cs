namespace Picpay.Domain.Utils;

/// <summary>
/// Defines a Unit Of Work 
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Starts a Transaction
    /// </summary>
    Task Begin();

    /// <summary>
    /// Finish and Dispose the object 
    /// </summary>
    Task Finish();

    /// <summary>
    /// Rollback the transaction
    /// </summary>
    Task Rollback();

    /// <summary>
    /// Applies a Transasction
    /// </summary>
    Task Apply();

    /// <summary>
    /// Run the following code in a sandbox.
    /// If something fails automaticly rollbacks
    /// </summary>
    /// <returns>Returns the function return type </returns>
    public async Task<T> Sandbox<T>(Func<Task<T>> func)
    {
        try
        {
            await Begin();

            var result = await func();

            await Apply();

            return result;
        }
        catch
        {
            await Rollback();
            throw;
        }
        finally
        {
            await Finish();
        }
    }

    /// <summary>
    /// Run the following code in a sandbox.
    /// If something fails automaticly rollbacks
    /// </summary>
    public Task Sandbox(Func<Task> func)
      => Sandbox(async () =>
      {
          await func();
          return true;
      });
}
