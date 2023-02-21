using System.Text.Json;

namespace AdaptItAcademy.WebAPI.Error_handlers
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ErrorDetails(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
