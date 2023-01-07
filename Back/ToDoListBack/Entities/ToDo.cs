using System.Text.Json.Serialization;

namespace Entities
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsPerformed { get; set; }
        public string Description { get; set; } = string.Empty;


        public DateTime DateCreate { get; set; }
    }
}