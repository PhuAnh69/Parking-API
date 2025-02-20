using System;

namespace HelloWebApi.Models
{
    public class Gate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created_At { get; set; } = DateTime.UtcNow;

        public DateTime Updated_At { get; set; } = DateTime.UtcNow;
    }
}