namespace Contact_Management_Service.Exceptions
{
    public class NotFoundException : Exception
    {
       public NotFoundException(string message) : base(message) { }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

}
