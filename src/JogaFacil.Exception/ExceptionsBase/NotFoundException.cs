using JogaFacil.Exception.ExceptionBase;
using System.Net;

namespace JogaFacil.Exception.ExceptionsBase
{
    public class NotFoundException : JogaFacilException
    {
        public NotFoundException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return new List<string>() { Message };
        }
    }
}
