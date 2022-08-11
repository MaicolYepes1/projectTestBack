﻿namespace ServicesAdministration.MODELS.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; } = null!;
        public string? OccupiedCapacity { get; set; }
        public int? ServerId { get; set; }
        public string Umbral { get; set; } = null!;
    }
}
