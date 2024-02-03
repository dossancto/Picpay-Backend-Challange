namespace Picpay.Domain.Exceptions;

/// <summary>
/// Represents a not found resource. 
/// </summary>
public class NotFoundException(string msg) : Exception(msg) { }
