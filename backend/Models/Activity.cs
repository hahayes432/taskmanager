using System.ComponentModel.DataAnnotations;

namespace backend
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int? Tags { get; set; }
        public int ActivityType { get; set; }
    }
}