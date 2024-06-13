namespace Lunatic.UI.Services.Responses.Favorites
{
    public class AddToFavoritesResponse : Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
