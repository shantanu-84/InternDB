using System.ComponentModel.DataAnnotations;

namespace InternDB.Data
{
    public class Attendance
    {
        public int Id { get; set; }
        
        [Required]
        public int InternId { get; set; }
        public Intern Intern { get; set; } = null!;
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public DateTime CheckInTime { get; set; }
        
        public DateTime? CheckOutTime { get; set; }
        
        [StringLength(200)]
        public string? Notes { get; set; }
        
        [Required]
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
    
    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        HalfDay
    }
}
