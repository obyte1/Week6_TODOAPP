using System.ComponentModel.DataAnnotations;

namespace Week6_TODO_APP.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
