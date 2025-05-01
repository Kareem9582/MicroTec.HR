namespace MicroTec.Hr.Domain.Custom_Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string entityName, object key)
            : base($"{entityName} with identifier '{key}' was not found.")
        {
        }
    }
}
