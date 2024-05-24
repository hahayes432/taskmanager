using System.ComponentModel.DataAnnotations;

namespace backend
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
    }
}