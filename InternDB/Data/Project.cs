using System.ComponentModel.DataAnnotations;

namespace InternDB.Data
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Required]
        public int InternId { get; set; }
        public Intern Intern { get; set; } = null!;
        
        [Required]
        public ProjectStatus Status { get; set; } = ProjectStatus.Assigned;
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? DueDate { get; set; }
        
        public DateTime? CompletedAt { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
    
    public enum ProjectStatus
    {
        Assigned,
        InProgress,
        Completed,
        OnHold
    }
}
