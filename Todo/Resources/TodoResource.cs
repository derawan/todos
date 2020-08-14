using System;

namespace Todo.Resources
{
    public class TodoResource
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Complete { get; set; }
        public Boolean Status { get; set; }
    }
}
