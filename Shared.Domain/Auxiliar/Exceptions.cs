using System.Net;

namespace Shared.Domain.Auxiliar
{
    public class StatusCodeException(string? message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
    {
        public virtual HttpStatusCode StatusCode { get; private set; } = statusCode;
    }

    public class NotFoundException(string? message) : StatusCodeException(message, HttpStatusCode.NotFound) { }
    public class AlreadyExistsException(string? message) : StatusCodeException(message, HttpStatusCode.Conflict) { }
    public class UnauthorizedException(string? message) : StatusCodeException(message, HttpStatusCode.Unauthorized) { }
}
