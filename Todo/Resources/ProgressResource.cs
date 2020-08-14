using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Resources
{
    public class ProgressResource
    {
        [Required]
        public decimal Progress { get; set; }
    }
}
