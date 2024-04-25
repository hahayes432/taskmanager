namespace backend
{
    public class Tasks
    {
        public string Name { get; set; }
        public string? Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ActivityId { get; set; }
        public int Status { get; set; }
        public int[] Tags { get; set; }
    }
}