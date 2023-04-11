namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IsComplete { get; set; }
        public string NIP { get; set; }
        public string Secret { get; set; }
    }
}