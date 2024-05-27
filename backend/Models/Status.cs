using System.ComponentModel.DataAnnotations;

namespace backend
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Style { get; set; }
    }
}