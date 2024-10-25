namespace JogaFacil.Exception.ExceptionBase
{
    public abstract class JogaFacilException : System.Exception
    {
        protected JogaFacilException(string message) : base(message) { }
        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
