namespace Lunatic.UI.Services.Responses
{
    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public string? ValidationErrors { get; set; } = default!;
        public bool Success { get; set; } = default!;
    }
}
