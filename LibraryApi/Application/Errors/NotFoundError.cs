namespace LibraryApi.Application.Errors
{
    public class NotFoundError(string message) : Exception(message);
}

