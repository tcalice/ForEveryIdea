using System;

namespace ForEveryAdventure.Api.Models
{
    public class EmergencyContact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}