using JogaFacil.Exception.ExceptionBase;
using JogaFacil.Exception.Resources;
using System.Net;

namespace JogaFacil.Exception.ExceptionsBase
{
    public class InvalidLoginException : JogaFacilException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID) { }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
