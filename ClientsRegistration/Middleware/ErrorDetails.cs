using System.Text.Json;

namespace ClientsRegistration.Api.Middleware
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
