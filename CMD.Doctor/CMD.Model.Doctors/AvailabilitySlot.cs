using System;

namespace CMD.Model.Doctors
{
    public class AvailabilitySlot
    {
        public int Id { get; set; }
        public DateTime SlotDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public float SlotDuration { get; set; }
        public string Description { get; set; }
    }
}