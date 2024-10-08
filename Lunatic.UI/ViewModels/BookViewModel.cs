﻿using Lunatic.UI.Payload;

namespace Lunatic.UI.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; } 
        public string Description { get; set; } = string.Empty;
        public float AverageScore { get; set; }
        public List<Guid>? Ratings { get; set; } 
        public string Genres { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
    }
}
