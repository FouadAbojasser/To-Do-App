namespace To_Do_App.Models
{
    public class Duty
    {
        public enum PriorityLevel
        {
            Low,
            Medium,
            High,
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PriorityLevel Priority { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public bool Status { get; set; }

    }

}
