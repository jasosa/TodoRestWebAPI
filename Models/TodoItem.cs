using System;
using System.ComponentModel.DataAnnotations;

namespace TodoAppRestAPI.Models
{
    public class TodoItem
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }

        public bool IsDone { get; set; }
    }
}
