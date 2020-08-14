using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Resources

{
    public class SaveTodoResource
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(520)]
        public string Description { get; set; }

        [Required]
        public DateTime  ExpiryDate { get; set; }

        public decimal Complete { get; set; }
    }
}
