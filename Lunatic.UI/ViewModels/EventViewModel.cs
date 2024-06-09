using System.ComponentModel.DataAnnotations;

namespace Lunatic.UI.ViewModels
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        [Required(ErrorMessage = "Event name is required")]
        [StringLength(50, ErrorMessage = "The Event name should have maximum 50 characters")]
        public string EventName { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The price should be between 1 and 1000")]
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}